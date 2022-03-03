using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Allergies_API.Migrations
{
    public partial class patientAllergies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient_Allergy_Details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllergyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergy_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Allergy_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Allergy_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Allergy_Clinical_Info = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsAllergyFatal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_Allergy_Details", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient_Allergy_Details");
        }
    }
}
