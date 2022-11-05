using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_46731r.Infrastructure.Migrations
{
    public partial class RenameAndRethinking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComputerCharacteristics_Computers_ComputerId",
                schema: "inventory",
                table: "ComputerCharacteristics");

            migrationBuilder.DropTable(
                name: "LastTimeComputerModified",
                schema: "checksByStaff");

            migrationBuilder.DropTable(
                name: "LastTimeStateChecks",
                schema: "checksByStaff");

            migrationBuilder.DropIndex(
                name: "IX_ComputerCharacteristics_ComputerId",
                schema: "inventory",
                table: "ComputerCharacteristics");

            migrationBuilder.AddColumn<int>(
                name: "ComputerCharacteristicsId",
                schema: "inventory",
                table: "Computers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateTable(
                name: "ComputersCheckedOn",
                schema: "checksByStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: false),
                    CheckedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputersCheckedOn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputersCheckedOn_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalSchema: "inventory",
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputersCheckedOn_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComputersModifiedOn",
                schema: "checksByStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Log = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: false),
                    CheckedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputersModifiedOn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputersModifiedOn_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalSchema: "inventory",
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputersModifiedOn_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "identity",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                schema: "identity",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ComputerCharacteristicsId",
                schema: "inventory",
                table: "Computers",
                column: "ComputerCharacteristicsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComputersCheckedOn_ComputerId",
                schema: "checksByStaff",
                table: "ComputersCheckedOn",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersCheckedOn_UserId",
                schema: "checksByStaff",
                table: "ComputersCheckedOn",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersModifiedOn_ComputerId",
                schema: "checksByStaff",
                table: "ComputersModifiedOn",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersModifiedOn_UserId",
                schema: "checksByStaff",
                table: "ComputersModifiedOn",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_ComputerCharacteristics_ComputerCharacteristicsId",
                schema: "inventory",
                table: "Computers",
                column: "ComputerCharacteristicsId",
                principalSchema: "inventory",
                principalTable: "ComputerCharacteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_ComputerCharacteristics_ComputerCharacteristicsId",
                schema: "inventory",
                table: "Computers");

            migrationBuilder.DropTable(
                name: "ComputersCheckedOn",
                schema: "checksByStaff");

            migrationBuilder.DropTable(
                name: "ComputersModifiedOn",
                schema: "checksByStaff");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                schema: "identity",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_Name",
                schema: "identity",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Computers_ComputerCharacteristicsId",
                schema: "inventory",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "ComputerCharacteristicsId",
                schema: "inventory",
                table: "Computers");

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

            migrationBuilder.CreateTable(
                name: "LastTimeComputerModified",
                schema: "checksByStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CheckedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastTimeComputerModified", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LastTimeComputerModified_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalSchema: "inventory",
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LastTimeComputerModified_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LastTimeStateChecks",
                schema: "checksByStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CheckedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastTimeStateChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LastTimeStateChecks_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalSchema: "inventory",
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LastTimeStateChecks_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerCharacteristics_ComputerId",
                schema: "inventory",
                table: "ComputerCharacteristics",
                column: "ComputerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LastTimeComputerModified_ComputerId",
                schema: "checksByStaff",
                table: "LastTimeComputerModified",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_LastTimeComputerModified_UserId",
                schema: "checksByStaff",
                table: "LastTimeComputerModified",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LastTimeStateChecks_ComputerId",
                schema: "checksByStaff",
                table: "LastTimeStateChecks",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_LastTimeStateChecks_UserId",
                schema: "checksByStaff",
                table: "LastTimeStateChecks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerCharacteristics_Computers_ComputerId",
                schema: "inventory",
                table: "ComputerCharacteristics",
                column: "ComputerId",
                principalSchema: "inventory",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
