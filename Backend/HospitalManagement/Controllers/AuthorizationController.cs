using HospitalManagement.Models;
using HospitalManagement.Repository.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalManagement.Controllers
{
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IToken _tokenService;

        public AuthorizationController(DBContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IToken tokenService)
        {
            this._context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this._tokenService = tokenService;
        }

        [HttpPost]
        [Route("api/[controller]/ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            try
            {
                var status = new Status();
                // check validations
                if (!ModelState.IsValid)
                {
                    status.StatusCode = 0;
                    status.Message = "Please pass all the valid fields";
                    return Ok(status);
                }

                // let's find the user
                var user = await userManager.FindByNameAsync(model.Username);
                if (user is null)
                {
                    status.StatusCode = 0;
                    status.Message = "Invalid username";
                    return Ok(status);
                }

                // check current password
                if (!await userManager.CheckPasswordAsync(user, model.CurrentPassword))
                {
                    status.StatusCode = 0;
                    status.Message = "Invalid current password";
                    return Ok(status);
                }

                // change password here
                var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    status.StatusCode = 0;
                    status.Message = "Failed to change password";
                    return Ok(status);
                }

                status.StatusCode = 1;
                status.Message = "Password has changed successfully";
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while changing the password.");
            }
        }

        [HttpPost]
        [Route("api/[controller]/Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    var userRoles = await userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                    var token = _tokenService.GetToken(authClaims);
                    var refreshToken = _tokenService.GetRefreshToken();
                    var tokenInfo = _context.TokenInfo.FirstOrDefault(a => a.Usename == user.UserName);
                    if (tokenInfo == null)
                    {
                        var info = new TokenInfo
                        {
                            Usename = user.UserName,
                            RefreshToken = refreshToken,
                            RefreshTokenExpiry = DateTime.Now.AddDays(1)
                        };
                        _context.TokenInfo.Add(info);
                    }
                    else
                    {
                        tokenInfo.RefreshToken = refreshToken;
                        tokenInfo.RefreshTokenExpiry = DateTime.Now.AddDays(1);
                    }

                    try
                    {
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }

                    return Ok(new LoginResponse
                    {
                        Name = user.Name,
                        Username = user.UserName,
                        Roles = user.Roles,
                        Token = token.TokenString,
                        RefreshToken = refreshToken,
                        Expiration = token.ValidTo,
                        StatusCode = 1,
                        Message = "Logged in"
                    });
                }

                // login failed condition
                return Ok(new LoginResponse
                {
                    StatusCode = 0,
                    Message = "Invalid Username or Password",
                    Token = "",
                    Expiration = null
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while logging in.");
            }
        }

        [HttpPost]
        [Route("api/[controller]/Registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationModel model)
        {
            try
            {
                var status = new Status();
                if (!ModelState.IsValid)
                {
                    status.StatusCode = 0;
                    status.Message = "Please pass all the required fields";
                    return Ok(status);
                }

                // check if user exists
                var userExists = await userManager.FindByNameAsync(model.UserName);
                if (userExists != null)
                {
                    status.StatusCode = 0;
                    status.Message = "Invalid username";
                    return Ok(status);
                }

                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Email = model.Email,
                    Name = model.Name,
                    Roles = model.Roles
                };

                // create a user here
                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    status.StatusCode = 0;
                    status.Message = "User creation failed";
                    return Ok(status);
                }

                // admin registration
                if (user.Roles == "Admin")
                {
                    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                    if (await roleManager.RoleExistsAsync(UserRoles.Admin))
                    {
                        await userManager.AddToRoleAsync(user, UserRoles.Admin);
                    }

                    status.StatusCode = 1;
                    status.Message = "Admin registration successfully done";
                    return Ok(status);
                }
                else if (user.Roles == "Doctor")
                {
                    if (!await roleManager.RoleExistsAsync(UserRoles.Doctor))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.Doctor));

                    if (await roleManager.RoleExistsAsync(UserRoles.Doctor))
                    {
                        await userManager.AddToRoleAsync(user, UserRoles.Doctor);
                    }

                    status.StatusCode = 1;
                    status.Message = "Successfully registered";
                    return Ok(status);
                }
                else
                {
                    if (!await roleManager.RoleExistsAsync(UserRoles.User))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                    if (await roleManager.RoleExistsAsync(UserRoles.User))
                    {
                        await userManager.AddToRoleAsync(user, UserRoles.User);
                    }

                    status.StatusCode = 1;
                    status.Message = "Successfully registered";
                    return Ok(status);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while registering.");
            }
        }
    }
}
