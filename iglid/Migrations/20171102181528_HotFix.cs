using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace iglid.Migrations
{
    public partial class HotFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "ApplicationUser",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Disputes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    link = table.Column<string>(nullable: false),
                    massage = table.Column<string>(maxLength: 150, nullable: false),
                    matchid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disputes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tournament",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    bestof = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    gameModes = table.Column<int>(nullable: false),
                    maxteams = table.Column<int>(nullable: false),
                    teamcount = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tournament", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tourInv",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    senderId = table.Column<string>(nullable: true),
                    touridid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tourInv", x => x.id);
                    table.ForeignKey(
                        name: "FK_tourInv_ApplicationUser_senderId",
                        column: x => x.senderId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tourInv_tournament_touridid",
                        column: x => x.touridid,
                        principalTable: "tournament",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tourInv_senderId",
                table: "tourInv",
                column: "senderId");

            migrationBuilder.CreateIndex(
                name: "IX_tourInv_touridid",
                table: "tourInv",
                column: "touridid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disputes");

            migrationBuilder.DropTable(
                name: "tourInv");

            migrationBuilder.DropTable(
                name: "tournament");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "ApplicationUser");
        }
    }
}
