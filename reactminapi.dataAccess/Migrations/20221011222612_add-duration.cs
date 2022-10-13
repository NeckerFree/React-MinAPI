using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reactminapi.dataAccess.Migrations
{
    public partial class addduration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Trainings",
                newName: "StartHour");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Trainings",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Trainings");

            migrationBuilder.RenameColumn(
                name: "StartHour",
                table: "Trainings",
                newName: "Time");
        }
    }
}
