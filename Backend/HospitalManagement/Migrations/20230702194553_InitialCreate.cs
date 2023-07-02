using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_DoctorTemp_DoctorTempid",
                table: "Appointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorTemp",
                table: "DoctorTemp");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_DoctorTempid",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "id",
                table: "DoctorTemp");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DoctorTemp");

            migrationBuilder.DropColumn(
                name: "DoctorTempid",
                table: "Appointment");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "DoctorTemp",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DoctorTempUserName",
                table: "Appointment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorTemp",
                table: "DoctorTemp",
                column: "UserName");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_DoctorTemp_DoctorTempUserName",
                table: "Appointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorTemp",
                table: "DoctorTemp");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_DoctorTempUserName",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "DoctorTempUserName",
                table: "Appointment");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "DoctorTemp",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "DoctorTemp",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DoctorTemp",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DoctorTempid",
                table: "Appointment",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorTemp",
                table: "DoctorTemp",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorTempid",
                table: "Appointment",
                column: "DoctorTempid");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_DoctorTemp_DoctorTempid",
                table: "Appointment",
                column: "DoctorTempid",
                principalTable: "DoctorTemp",
                principalColumn: "id");
        }
    }
}
