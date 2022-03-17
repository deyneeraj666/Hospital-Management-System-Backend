using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Procedures_API.Migrations
{
    public partial class ProceduresMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcedureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcedureCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProceduresMaster",
                columns: table => new
                {
                    ProcedureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProcedureName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProceduresMaster", x => x.ProcedureCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "ProceduresMaster");
        }
    }
}
