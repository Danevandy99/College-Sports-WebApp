using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College_Sports_WebApp.Migrations.MySQL
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScoreboardCallouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GamecastLink = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardCallouts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScoreboardEventInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LocationHeadline = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocationDetail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardEventInfo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScoreboardResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FetchDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FilterDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardResults", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScoreboardScoreCell",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Time = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardScoreCell", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScoreboardScoreCellItemRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardScoreCellItemRecord", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScoreboardItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ScoreCellId = table.Column<int>(type: "int", nullable: false),
                    EventInfoId = table.Column<int>(type: "int", nullable: false),
                    CalloutsId = table.Column<int>(type: "int", nullable: false),
                    ScoreboardResultId = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScoreboardScoreCellItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsAway = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TeamName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogoUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    ScoreboardScoreCellId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardScoreCellItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoreboardScoreCellItem_ScoreboardScoreCellItemRecord_Record~",
                        column: x => x.RecordId,
                        principalTable: "ScoreboardScoreCellItemRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreboardScoreCellItem_ScoreboardScoreCell_ScoreboardScoreC~",
                        column: x => x.ScoreboardScoreCellId,
                        principalTable: "ScoreboardScoreCell",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
