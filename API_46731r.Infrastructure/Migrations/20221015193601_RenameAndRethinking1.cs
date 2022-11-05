using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_46731r.Infrastructure.Migrations
{
    public partial class RenameAndRethinking1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerCheckedOnId",
                schema: "inventory",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "ComputerCommentsId",
                schema: "inventory",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "ComputerModifiedOnId",
                schema: "inventory",
                table: "Computers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComputerCheckedOnId",
                schema: "inventory",
                table: "Computers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComputerCommentsId",
                schema: "inventory",
                table: "Computers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComputerModifiedOnId",
                schema: "inventory",
                table: "Computers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
