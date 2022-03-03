using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentScheduling_API.Migrations
{
    public partial class AppointmentScheduleDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAppointmentDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    p_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    physician = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    meetingTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAppointmentDetails", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointmentDetails_id",
                table: "tblAppointmentDetails",
                column: "id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAppointmentDetails");
        }
    }
}
