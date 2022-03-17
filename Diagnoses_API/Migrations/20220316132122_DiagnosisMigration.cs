using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diagnoses_API.Migrations
{
    public partial class DiagnosisMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    diag_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diag_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ddate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosisMaster",
                columns: table => new
                {
                    diag_code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    diag_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisMaster", x => x.diag_code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "DiagnosisMaster");
        }
    }
}
