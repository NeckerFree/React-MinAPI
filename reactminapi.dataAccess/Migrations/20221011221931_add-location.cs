using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reactminapi.dataAccess.Migrations
{
    public partial class addlocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Trainings",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Trainings");
        }
    }
}
