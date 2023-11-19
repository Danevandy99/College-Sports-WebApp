using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College_Sports_WebApp.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class MoreChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AthletesInvolved_Team_teamid",
                table: "AthletesInvolved");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Athlete_athleteId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_League_leagueId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Team_teamId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Competition_Type_status_typeid",
                table: "Competition");

            migrationBuilder.DropForeignKey(
                name: "FK_Competition_Type_typeid",
                table: "Competition");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Type_status_typeid",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_GeoBroadcast_Type_typeid",
                table: "GeoBroadcast");

            migrationBuilder.DropForeignKey(
                name: "FK_LastPlay_Team_teamid",
                table: "LastPlay");

            migrationBuilder.DropForeignKey(
                name: "FK_LastPlay_Type_typeid",
                table: "LastPlay");

            migrationBuilder.DropForeignKey(
                name: "FK_LeagueSeason_Type_typeid",
                table: "LeagueSeason");

            migrationBuilder.DropTable(
                name: "Leader");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "Athlete");

            migrationBuilder.DropIndex(
                name: "IX_LeagueSeason_typeid",
                table: "LeagueSeason");

            migrationBuilder.DropIndex(
                name: "IX_LastPlay_teamid",
                table: "LastPlay");

            migrationBuilder.DropIndex(
                name: "IX_LastPlay_typeid",
                table: "LastPlay");

            migrationBuilder.DropIndex(
                name: "IX_GeoBroadcast_typeid",
                table: "GeoBroadcast");

            migrationBuilder.DropIndex(
                name: "IX_Event_status_typeid",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Competition_status_typeid",
                table: "Competition");

            migrationBuilder.DropIndex(
                name: "IX_Competition_typeid",
                table: "Competition");

            migrationBuilder.DropIndex(
                name: "IX_Category_athleteId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_leagueId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_teamId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_AthletesInvolved_teamid",
                table: "AthletesInvolved");

            migrationBuilder.DropColumn(
                name: "teamid",
                table: "AthletesInvolved");

            migrationBuilder.RenameColumn(
                name: "typeid",
                table: "LeagueSeason",
                newName: "type_type");

            migrationBuilder.RenameColumn(
                name: "typeid",
                table: "LastPlay",
                newName: "type_type");

            migrationBuilder.RenameColumn(
                name: "teamid",
                table: "LastPlay",
                newName: "type_id");

            migrationBuilder.RenameColumn(
                name: "typeid",
                table: "GeoBroadcast",
                newName: "type_type");

            migrationBuilder.RenameColumn(
                name: "status_typeid",
                table: "Event",
                newName: "status_type_type");

            migrationBuilder.RenameColumn(
                name: "typeid",
                table: "Competition",
                newName: "type_type");

            migrationBuilder.RenameColumn(
                name: "status_typeid",
                table: "Competition",
                newName: "type_id");

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

            migrationBuilder.AddColumn<string>(
                name: "type_abbreviation",
                table: "LeagueSeason",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "type_completed",
                table: "LeagueSeason",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "type_description",
                table: "LeagueSeason",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_detail",
                table: "LeagueSeason",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "type_id",
                table: "LeagueSeason",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "type_name",
                table: "LeagueSeason",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_shortDetail",
                table: "LeagueSeason",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_shortName",
                table: "LeagueSeason",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_state",
                table: "LeagueSeason",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_text",
                table: "LeagueSeason",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_abbreviation",
                table: "LastPlay",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "type_completed",
                table: "LastPlay",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "type_description",
                table: "LastPlay",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_detail",
                table: "LastPlay",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_name",
                table: "LastPlay",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_shortDetail",
                table: "LastPlay",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_shortName",
                table: "LastPlay",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_state",
                table: "LastPlay",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_text",
                table: "LastPlay",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_abbreviation",
                table: "GeoBroadcast",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "type_completed",
                table: "GeoBroadcast",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "type_description",
                table: "GeoBroadcast",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_detail",
                table: "GeoBroadcast",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "type_id",
                table: "GeoBroadcast",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "type_name",
                table: "GeoBroadcast",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_shortDetail",
                table: "GeoBroadcast",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_shortName",
                table: "GeoBroadcast",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_state",
                table: "GeoBroadcast",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_text",
                table: "GeoBroadcast",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status_type_abbreviation",
                table: "Event",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "status_type_completed",
                table: "Event",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "status_type_description",
                table: "Event",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status_type_detail",
                table: "Event",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "status_type_id",
                table: "Event",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "status_type_name",
                table: "Event",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status_type_shortDetail",
                table: "Event",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status_type_shortName",
                table: "Event",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status_type_state",
                table: "Event",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status_type_text",
                table: "Event",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status_type_abbreviation",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "status_type_completed",
                table: "Competition",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "status_type_description",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status_type_detail",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "status_type_id",
                table: "Competition",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "status_type_name",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status_type_shortDetail",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status_type_shortName",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status_type_state",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status_type_text",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "status_type_type",
                table: "Competition",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "type_abbreviation",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "type_completed",
                table: "Competition",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "type_description",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_detail",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_name",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_shortDetail",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_shortName",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_state",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type_text",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type_abbreviation",
                table: "LeagueSeason");

            migrationBuilder.DropColumn(
                name: "type_completed",
                table: "LeagueSeason");

            migrationBuilder.DropColumn(
                name: "type_description",
                table: "LeagueSeason");

            migrationBuilder.DropColumn(
                name: "type_detail",
                table: "LeagueSeason");

            migrationBuilder.DropColumn(
                name: "type_id",
                table: "LeagueSeason");

            migrationBuilder.DropColumn(
                name: "type_name",
                table: "LeagueSeason");

            migrationBuilder.DropColumn(
                name: "type_shortDetail",
                table: "LeagueSeason");

            migrationBuilder.DropColumn(
                name: "type_shortName",
                table: "LeagueSeason");

            migrationBuilder.DropColumn(
                name: "type_state",
                table: "LeagueSeason");

            migrationBuilder.DropColumn(
                name: "type_text",
                table: "LeagueSeason");

            migrationBuilder.DropColumn(
                name: "type_abbreviation",
                table: "LastPlay");

            migrationBuilder.DropColumn(
                name: "type_completed",
                table: "LastPlay");

            migrationBuilder.DropColumn(
                name: "type_description",
                table: "LastPlay");

            migrationBuilder.DropColumn(
                name: "type_detail",
                table: "LastPlay");

            migrationBuilder.DropColumn(
                name: "type_name",
                table: "LastPlay");

            migrationBuilder.DropColumn(
                name: "type_shortDetail",
                table: "LastPlay");

            migrationBuilder.DropColumn(
                name: "type_shortName",
                table: "LastPlay");

            migrationBuilder.DropColumn(
                name: "type_state",
                table: "LastPlay");

            migrationBuilder.DropColumn(
                name: "type_text",
                table: "LastPlay");

            migrationBuilder.DropColumn(
                name: "type_abbreviation",
                table: "GeoBroadcast");

            migrationBuilder.DropColumn(
                name: "type_completed",
                table: "GeoBroadcast");

            migrationBuilder.DropColumn(
                name: "type_description",
                table: "GeoBroadcast");

            migrationBuilder.DropColumn(
                name: "type_detail",
                table: "GeoBroadcast");

            migrationBuilder.DropColumn(
                name: "type_id",
                table: "GeoBroadcast");

            migrationBuilder.DropColumn(
                name: "type_name",
                table: "GeoBroadcast");

            migrationBuilder.DropColumn(
                name: "type_shortDetail",
                table: "GeoBroadcast");

            migrationBuilder.DropColumn(
                name: "type_shortName",
                table: "GeoBroadcast");

            migrationBuilder.DropColumn(
                name: "type_state",
                table: "GeoBroadcast");

            migrationBuilder.DropColumn(
                name: "type_text",
                table: "GeoBroadcast");

            migrationBuilder.DropColumn(
                name: "status_type_abbreviation",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "status_type_completed",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "status_type_description",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "status_type_detail",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "status_type_id",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "status_type_name",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "status_type_shortDetail",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "status_type_shortName",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "status_type_state",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "status_type_text",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "status_type_abbreviation",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "status_type_completed",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "status_type_description",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "status_type_detail",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "status_type_id",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "status_type_name",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "status_type_shortDetail",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "status_type_shortName",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "status_type_state",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "status_type_text",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "status_type_type",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "type_abbreviation",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "type_completed",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "type_description",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "type_detail",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "type_name",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "type_shortDetail",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "type_shortName",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "type_state",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "type_text",
                table: "Competition");

            migrationBuilder.RenameColumn(
                name: "type_type",
                table: "LeagueSeason",
                newName: "typeid");

            migrationBuilder.RenameColumn(
                name: "type_type",
                table: "LastPlay",
                newName: "typeid");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "LastPlay",
                newName: "teamid");

            migrationBuilder.RenameColumn(
                name: "type_type",
                table: "GeoBroadcast",
                newName: "typeid");

            migrationBuilder.RenameColumn(
                name: "status_type_type",
                table: "Event",
                newName: "status_typeid");

            migrationBuilder.RenameColumn(
                name: "type_type",
                table: "Competition",
                newName: "typeid");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "Competition",
                newName: "status_typeid");

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

            migrationBuilder.AddColumn<int>(
                name: "teamid",
                table: "AthletesInvolved",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Athlete",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    teamid = table.Column<int>(type: "INTEGER", nullable: false),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    displayName = table.Column<string>(type: "TEXT", nullable: false),
                    fullName = table.Column<string>(type: "TEXT", nullable: false),
                    headshot = table.Column<string>(type: "TEXT", nullable: false),
                    jersey = table.Column<string>(type: "TEXT", nullable: false),
                    shortName = table.Column<string>(type: "TEXT", nullable: false),
                    position_abbreviation = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athlete", x => x.id);
                    table.ForeignKey(
                        name: "FK_Athlete_Team_teamid",
                        column: x => x.teamid,
                        principalTable: "Team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    abbreviation = table.Column<string>(type: "TEXT", nullable: false),
                    completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    detail = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    shortDetail = table.Column<string>(type: "TEXT", nullable: false),
                    shortName = table.Column<string>(type: "TEXT", nullable: false),
                    state = table.Column<string>(type: "TEXT", nullable: false),
                    text = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Leader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    athleteid = table.Column<int>(type: "INTEGER", nullable: false),
                    teamid = table.Column<int>(type: "INTEGER", nullable: false),
                    Competitorid = table.Column<int>(type: "INTEGER", nullable: true),
                    LeaderId = table.Column<int>(type: "INTEGER", nullable: true),
                    abbreviation = table.Column<string>(type: "TEXT", nullable: false),
                    displayName = table.Column<string>(type: "TEXT", nullable: false),
                    displayValue = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    shortDisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    value = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leader_Athlete_athleteid",
                        column: x => x.athleteid,
                        principalTable: "Athlete",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leader_Competitor_Competitorid",
                        column: x => x.Competitorid,
                        principalTable: "Competitor",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Leader_Leader_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Leader",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leader_Team_teamid",
                        column: x => x.teamid,
                        principalTable: "Team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeagueSeason_typeid",
                table: "LeagueSeason",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_LastPlay_teamid",
                table: "LastPlay",
                column: "teamid");

            migrationBuilder.CreateIndex(
                name: "IX_LastPlay_typeid",
                table: "LastPlay",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_GeoBroadcast_typeid",
                table: "GeoBroadcast",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_Event_status_typeid",
                table: "Event",
                column: "status_typeid");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_status_typeid",
                table: "Competition",
                column: "status_typeid");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_typeid",
                table: "Competition",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_Category_athleteId",
                table: "Category",
                column: "athleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_leagueId",
                table: "Category",
                column: "leagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_teamId",
                table: "Category",
                column: "teamId");

            migrationBuilder.CreateIndex(
                name: "IX_AthletesInvolved_teamid",
                table: "AthletesInvolved",
                column: "teamid");

            migrationBuilder.CreateIndex(
                name: "IX_Athlete_teamid",
                table: "Athlete",
                column: "teamid");

            migrationBuilder.CreateIndex(
                name: "IX_Leader_athleteid",
                table: "Leader",
                column: "athleteid");

            migrationBuilder.CreateIndex(
                name: "IX_Leader_Competitorid",
                table: "Leader",
                column: "Competitorid");

            migrationBuilder.CreateIndex(
                name: "IX_Leader_LeaderId",
                table: "Leader",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Leader_teamid",
                table: "Leader",
                column: "teamid");

            migrationBuilder.AddForeignKey(
                name: "FK_AthletesInvolved_Team_teamid",
                table: "AthletesInvolved",
                column: "teamid",
                principalTable: "Team",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Athlete_athleteId",
                table: "Category",
                column: "athleteId",
                principalTable: "Athlete",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_League_leagueId",
                table: "Category",
                column: "leagueId",
                principalTable: "League",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Team_teamId",
                table: "Category",
                column: "teamId",
                principalTable: "Team",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competition_Type_status_typeid",
                table: "Competition",
                column: "status_typeid",
                principalTable: "Type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Competition_Type_typeid",
                table: "Competition",
                column: "typeid",
                principalTable: "Type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Type_status_typeid",
                table: "Event",
                column: "status_typeid",
                principalTable: "Type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeoBroadcast_Type_typeid",
                table: "GeoBroadcast",
                column: "typeid",
                principalTable: "Type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LastPlay_Team_teamid",
                table: "LastPlay",
                column: "teamid",
                principalTable: "Team",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LastPlay_Type_typeid",
                table: "LastPlay",
                column: "typeid",
                principalTable: "Type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueSeason_Type_typeid",
                table: "LeagueSeason",
                column: "typeid",
                principalTable: "Type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
