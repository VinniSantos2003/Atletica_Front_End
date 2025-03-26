using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atletica_Back_End.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Champions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    urlImage = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    imageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    totalKills = table.Column<int>(type: "INTEGER", nullable: false),
                    totalDamage = table.Column<int>(type: "INTEGER", nullable: false),
                    wins = table.Column<int>(type: "INTEGER", nullable: false),
                    losses = table.Column<int>(type: "INTEGER", nullable: false),
                    totalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    totalDuration = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matchs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    winnerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    loserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    duration = table.Column<double>(type: "REAL", nullable: false),
                    totalKills = table.Column<int>(type: "INTEGER", nullable: false),
                    totalDamage = table.Column<int>(type: "INTEGER", nullable: false),
                    totalGold = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matchs_Teams_loserId",
                        column: x => x.loserId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_Teams_winnerId",
                        column: x => x.winnerId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    nick = table.Column<string>(type: "TEXT", nullable: true),
                    teamId = table.Column<Guid>(type: "TEXT", nullable: false),
                    totalKills = table.Column<int>(type: "INTEGER", nullable: false),
                    totalAssists = table.Column<int>(type: "INTEGER", nullable: false),
                    totalDeaths = table.Column<int>(type: "INTEGER", nullable: false),
                    totalMVP = table.Column<int>(type: "INTEGER", nullable: false),
                    totalMinutes = table.Column<double>(type: "REAL", nullable: false),
                    wins = table.Column<int>(type: "INTEGER", nullable: false),
                    losses = table.Column<int>(type: "INTEGER", nullable: false),
                    totalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    teamTotalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    teamTotalKill = table.Column<int>(type: "INTEGER", nullable: false),
                    totalVisionScore = table.Column<int>(type: "INTEGER", nullable: false),
                    totalFirstBlood = table.Column<int>(type: "INTEGER", nullable: false),
                    totalTeamFirstBlood = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_teamId",
                        column: x => x.teamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsedChampions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    win = table.Column<bool>(type: "INTEGER", nullable: false),
                    matchId = table.Column<Guid>(type: "TEXT", nullable: true),
                    playerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    championsId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedChampions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsedChampions_Champions_championsId",
                        column: x => x.championsId,
                        principalTable: "Champions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsedChampions_Matchs_matchId",
                        column: x => x.matchId,
                        principalTable: "Matchs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsedChampions_Players_playerId",
                        column: x => x.playerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_loserId",
                table: "Matchs",
                column: "loserId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_winnerId",
                table: "Matchs",
                column: "winnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_teamId",
                table: "Players",
                column: "teamId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedChampions_championsId",
                table: "UsedChampions",
                column: "championsId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedChampions_matchId",
                table: "UsedChampions",
                column: "matchId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedChampions_playerId",
                table: "UsedChampions",
                column: "playerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsedChampions");

            migrationBuilder.DropTable(
                name: "Champions");

            migrationBuilder.DropTable(
                name: "Matchs");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
