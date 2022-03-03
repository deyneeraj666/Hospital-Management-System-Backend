using Microsoft.EntityFrameworkCore.Migrations;

namespace Allergies_API.Migrations
{
    public partial class Allergy_Master : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergy_Master",
                columns: table => new
                {
                    Allergy_Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Allergy_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Allergy_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Allergen_Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Allerginicity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Iso_Forms_of_Partial_Sequence_of_Allergen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergy_Master", x => x.Allergy_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergy_Master");
        }
    }
}
