using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentScheduling_API.Migrations
{
    public partial class AppointmentScheduleDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "tblAppointmentDetails",
                newName: "physicianId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "physicianId",
                table: "tblAppointmentDetails",
                newName: "username");
        }
    }
}
