using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College_Sports_WebApp.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class RemoveOldResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoreboardItem");

            migrationBuilder.DropTable(
                name: "ScoreboardScoreCellItem");

            migrationBuilder.DropTable(
                name: "PartialScoreboardResults");

            migrationBuilder.DropTable(
                name: "ScoreboardCallouts");

            migrationBuilder.DropTable(
                name: "ScoreboardEventInfo");

            migrationBuilder.DropTable(
                name: "ScoreboardScoreCellItemRecord");

            migrationBuilder.DropTable(
                name: "ScoreboardScoreCell");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Video",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Venue",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ScoreboardResults",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Video",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Venue",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ScoreboardResults",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "PartialScoreboardResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FetchDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FilterDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartialScoreboardResults", x => x.Id);
                });

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
                    LocationDetail = table.Column<string>(type: "TEXT", nullable: false),
                    LocationHeadline = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardEventInfo", x => x.Id);
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
                    Losses = table.Column<int>(type: "INTEGER", nullable: false),
                    Wins = table.Column<int>(type: "INTEGER", nullable: false)
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
                    CalloutsId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventInfoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScoreCellId = table.Column<int>(type: "INTEGER", nullable: false),
                    PartialScoreboardResultId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoreboardItem_PartialScoreboardResults_PartialScoreboardResultId",
                        column: x => x.PartialScoreboardResultId,
                        principalTable: "PartialScoreboardResults",
                        principalColumn: "Id");
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
                    RecordId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAway = table.Column<bool>(type: "INTEGER", nullable: false),
                    LogoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ScoreboardScoreCellId = table.Column<int>(type: "INTEGER", nullable: true),
                    TeamName = table.Column<string>(type: "TEXT", nullable: false)
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
                name: "IX_ScoreboardItem_PartialScoreboardResultId",
                table: "ScoreboardItem",
                column: "PartialScoreboardResultId");

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
    }
}
