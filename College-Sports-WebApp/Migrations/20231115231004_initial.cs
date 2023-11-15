using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College_Sports_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScoreboardCallouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GamecastLink = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardCallouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreboardEventInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationHeadline = table.Column<string>(type: "TEXT", nullable: false),
                    LocationDetail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardEventInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreboardResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FetchDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FilterDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreboardScoreCell",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardScoreCell", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreboardScoreCellItemRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Wins = table.Column<int>(type: "INTEGER", nullable: false),
                    Losses = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardScoreCellItemRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreboardItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScoreCellId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventInfoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CalloutsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScoreboardResultId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoreboardItem_ScoreboardCallouts_CalloutsId",
                        column: x => x.CalloutsId,
                        principalTable: "ScoreboardCallouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreboardItem_ScoreboardEventInfo_EventInfoId",
                        column: x => x.EventInfoId,
                        principalTable: "ScoreboardEventInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreboardItem_ScoreboardResults_ScoreboardResultId",
                        column: x => x.ScoreboardResultId,
                        principalTable: "ScoreboardResults",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScoreboardItem_ScoreboardScoreCell_ScoreCellId",
                        column: x => x.ScoreCellId,
                        principalTable: "ScoreboardScoreCell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoreboardScoreCellItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsAway = table.Column<bool>(type: "INTEGER", nullable: false),
                    TeamName = table.Column<string>(type: "TEXT", nullable: false),
                    LogoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    RecordId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScoreboardScoreCellId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardScoreCellItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoreboardScoreCellItem_ScoreboardScoreCellItemRecord_RecordId",
                        column: x => x.RecordId,
                        principalTable: "ScoreboardScoreCellItemRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreboardScoreCellItem_ScoreboardScoreCell_ScoreboardScoreCellId",
                        column: x => x.ScoreboardScoreCellId,
                        principalTable: "ScoreboardScoreCell",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScoreboardItem_CalloutsId",
                table: "ScoreboardItem",
                column: "CalloutsId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreboardItem_EventInfoId",
                table: "ScoreboardItem",
                column: "EventInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreboardItem_ScoreboardResultId",
                table: "ScoreboardItem",
                column: "ScoreboardResultId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreboardItem_ScoreCellId",
                table: "ScoreboardItem",
                column: "ScoreCellId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreboardScoreCellItem_RecordId",
                table: "ScoreboardScoreCellItem",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreboardScoreCellItem_ScoreboardScoreCellId",
                table: "ScoreboardScoreCellItem",
                column: "ScoreboardScoreCellId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoreboardItem");

            migrationBuilder.DropTable(
                name: "ScoreboardScoreCellItem");

            migrationBuilder.DropTable(
                name: "ScoreboardCallouts");

            migrationBuilder.DropTable(
                name: "ScoreboardEventInfo");

            migrationBuilder.DropTable(
                name: "ScoreboardResults");

            migrationBuilder.DropTable(
                name: "ScoreboardScoreCellItemRecord");

            migrationBuilder.DropTable(
                name: "ScoreboardScoreCell");
        }
    }
}
