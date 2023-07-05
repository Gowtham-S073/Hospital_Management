using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class FinalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_DoctorTemp_DoctorTempUserName",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_DoctorTempUserName",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "DoctorTemp");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "DoctorTemp");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "DoctorTemp");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "DoctorTemp");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "DoctorTemp");

            migrationBuilder.DropColumn(
                name: "DoctorTempUserName",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "Specialization",
                table: "DoctorTemp",
                newName: "Roles");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "DoctorTemp",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Roles",
                table: "DoctorTemp",
                newName: "Specialization");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DoctorTemp",
                newName: "Sex");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DoctorTemp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "DoctorTemp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "DoctorTemp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "DoctorTemp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PhoneNumber",
                table: "DoctorTemp",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "DoctorTempUserName",
                table: "Appointment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorTempUserName",
                table: "Appointment",
                column: "DoctorTempUserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_DoctorTemp_DoctorTempUserName",
                table: "Appointment",
                column: "DoctorTempUserName",
                principalTable: "DoctorTemp",
                principalColumn: "UserName");
        }
    }
}
