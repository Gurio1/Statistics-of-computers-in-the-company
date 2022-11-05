using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_46731r.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "additionals");

            migrationBuilder.EnsureSchema(
                name: "inventory");

            migrationBuilder.EnsureSchema(
                name: "checksByStaff");

            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.CreateTable(
                name: "Computers",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryNumber = table.Column<int>(type: "int", nullable: false),
                    HostName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MAC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                    table.UniqueConstraint("AK_Computers_InventoryNumber", x => x.InventoryNumber);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Force = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerCharacteristics",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Processor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RAM = table.Column<int>(type: "int", nullable: true),
                    MotherBoard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Storage = table.Column<int>(type: "int", nullable: true),
                    ComputerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerCharacteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputerCharacteristics_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalSchema: "inventory",
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "additionals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalSchema: "inventory",
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LastTimeComputerModified",
                schema: "checksByStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    CheckedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "IX_Comments_ComputerId",
                schema: "additionals",
                table: "Comments",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                schema: "additionals",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerCharacteristics_ComputerId",
                schema: "inventory",
                table: "ComputerCharacteristics",
                column: "ComputerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_HostName",
                schema: "inventory",
                table: "Computers",
                column: "HostName",
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

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "identity",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments",
                schema: "additionals");

            migrationBuilder.DropTable(
                name: "ComputerCharacteristics",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "LastTimeComputerModified",
                schema: "checksByStaff");

            migrationBuilder.DropTable(
                name: "LastTimeStateChecks",
                schema: "checksByStaff");

            migrationBuilder.DropTable(
                name: "Computers",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "identity");
        }
    }
}
