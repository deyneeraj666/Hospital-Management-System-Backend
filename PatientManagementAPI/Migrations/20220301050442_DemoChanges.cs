using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientManagementAPI.Migrations
{
    public partial class DemoChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Demographics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Demographics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
