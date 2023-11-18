using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College_Sports_WebApp.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class AddNewScoreboardResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreboardItem_ScoreboardResults_ScoreboardResultId",
                table: "ScoreboardItem");

            migrationBuilder.RenameColumn(
                name: "FilterDate",
                table: "ScoreboardResults",
                newName: "groups");

            migrationBuilder.RenameColumn(
                name: "FetchDateTime",
                table: "ScoreboardResults",
                newName: "eventsDate_date");

            migrationBuilder.RenameColumn(
                name: "ScoreboardResultId",
                table: "ScoreboardItem",
                newName: "PartialScoreboardResultId");

            migrationBuilder.RenameIndex(
                name: "IX_ScoreboardItem_ScoreboardResultId",
                table: "ScoreboardItem",
                newName: "IX_ScoreboardItem_PartialScoreboardResultId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ScoreboardResults",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "eventsDate_seasonType",
                table: "ScoreboardResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DeviceRestrictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    devices = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceRestrictions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    shortName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

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
                name: "Policy",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    createdBy = table.Column<string>(type: "TEXT", nullable: false),
                    createdOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    lastModifiedBy = table.Column<string>(type: "TEXT", nullable: false),
                    lastModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    hasEspnId3Heartbeats = table.Column<string>(type: "TEXT", nullable: false),
                    language = table.Column<string>(type: "TEXT", nullable: false),
                    shortTitle = table.Column<string>(type: "TEXT", nullable: false),
                    trueOriginal = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    simulcastAiringId = table.Column<string>(type: "TEXT", nullable: false),
                    contentCleared = table.Column<string>(type: "TEXT", nullable: false),
                    hasPassThroughAds = table.Column<string>(type: "TEXT", nullable: false),
                    dtcPackages = table.Column<string>(type: "TEXT", nullable: false),
                    airingConcurrency = table.Column<string>(type: "TEXT", nullable: false),
                    isLive = table.Column<string>(type: "TEXT", nullable: false),
                    hasNielsenWatermarks = table.Column<string>(type: "TEXT", nullable: false),
                    artworkLastModified = table.Column<string>(type: "TEXT", nullable: false),
                    allowStartOver = table.Column<string>(type: "TEXT", nullable: false),
                    trackingId = table.Column<string>(type: "TEXT", nullable: false),
                    commercialReplacement = table.Column<string>(type: "TEXT", nullable: false),
                    allowedAccess = table.Column<string>(type: "TEXT", nullable: false),
                    reAir = table.Column<string>(type: "TEXT", nullable: false),
                    killDateTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    sponsored = table.Column<string>(type: "TEXT", nullable: false),
                    liveReplay = table.Column<string>(type: "TEXT", nullable: false),
                    broadcastStartOffset = table.Column<string>(type: "TEXT", nullable: false),
                    nbStartTimestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    feedType = table.Column<string>(type: "TEXT", nullable: false),
                    ratingsId = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    shortName = table.Column<string>(type: "TEXT", nullable: false),
                    canIpAuthenticate = table.Column<string>(type: "TEXT", nullable: false),
                    origination = table.Column<string>(type: "TEXT", nullable: false),
                    iso3166 = table.Column<string>(type: "TEXT", nullable: false),
                    subscription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    priority = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    year = table.Column<int>(type: "INTEGER", nullable: false),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    slug = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    abbreviation = table.Column<string>(type: "TEXT", nullable: false),
                    text = table.Column<string>(type: "TEXT", nullable: false),
                    state = table.Column<string>(type: "TEXT", nullable: false),
                    completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    detail = table.Column<string>(type: "TEXT", nullable: false),
                    shortDetail = table.Column<string>(type: "TEXT", nullable: false),
                    shortName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    fullName = table.Column<string>(type: "TEXT", nullable: false),
                    address_city = table.Column<string>(type: "TEXT", nullable: false),
                    address_state = table.Column<string>(type: "TEXT", nullable: false),
                    capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    indoor = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    source = table.Column<string>(type: "TEXT", nullable: false),
                    dataSourceIdentifier = table.Column<string>(type: "TEXT", nullable: false),
                    headline = table.Column<string>(type: "TEXT", nullable: false),
                    caption = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    premium = table.Column<bool>(type: "INTEGER", nullable: false),
                    ad_sport = table.Column<string>(type: "TEXT", nullable: false),
                    ad_bundle = table.Column<string>(type: "TEXT", nullable: false),
                    tracking_sportName = table.Column<string>(type: "TEXT", nullable: false),
                    tracking_leagueName = table.Column<string>(type: "TEXT", nullable: false),
                    tracking_coverageType = table.Column<string>(type: "TEXT", nullable: false),
                    tracking_trackingName = table.Column<string>(type: "TEXT", nullable: false),
                    tracking_trackingId = table.Column<string>(type: "TEXT", nullable: false),
                    cerebroId = table.Column<string>(type: "TEXT", nullable: false),
                    contributingPartner = table.Column<string>(type: "TEXT", nullable: false),
                    contributingSystem = table.Column<string>(type: "TEXT", nullable: false),
                    lastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    originalPublishDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    timeRestrictions_embargoDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    timeRestrictions_expirationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    deviceRestrictionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    syndicatable = table.Column<bool>(type: "INTEGER", nullable: false),
                    duration = table.Column<int>(type: "INTEGER", nullable: false),
                    keywords = table.Column<string>(type: "TEXT", nullable: false),
                    posterImages_default_href = table.Column<string>(type: "TEXT", nullable: false),
                    posterImages_default_width = table.Column<int>(type: "INTEGER", nullable: false),
                    posterImages_default_height = table.Column<int>(type: "INTEGER", nullable: false),
                    posterImages_full_href = table.Column<string>(type: "TEXT", nullable: false),
                    posterImages_wide_href = table.Column<string>(type: "TEXT", nullable: false),
                    posterImages_square_href = table.Column<string>(type: "TEXT", nullable: false),
                    thumbnail = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    ScoreboardResultId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.id);
                    table.ForeignKey(
                        name: "FK_Video_DeviceRestrictions_deviceRestrictionsId",
                        column: x => x.deviceRestrictionsId,
                        principalTable: "DeviceRestrictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Video_ScoreboardResults_ScoreboardResultId",
                        column: x => x.ScoreboardResultId,
                        principalTable: "ScoreboardResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Audience",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    externalId = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    match = table.Column<string>(type: "TEXT", nullable: false),
                    propertiesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audience", x => x.id);
                    table.ForeignKey(
                        name: "FK_Audience_Properties_propertiesId",
                        column: x => x.propertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeagueSeason",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    year = table.Column<int>(type: "INTEGER", nullable: false),
                    startDate = table.Column<string>(type: "TEXT", nullable: false),
                    endDate = table.Column<string>(type: "TEXT", nullable: false),
                    displayName = table.Column<string>(type: "TEXT", nullable: false),
                    typeid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueSeason", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeagueSeason_Type_typeid",
                        column: x => x.typeid,
                        principalTable: "Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    uid = table.Column<string>(type: "TEXT", nullable: false),
                    location = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    abbreviation = table.Column<string>(type: "TEXT", nullable: false),
                    displayName = table.Column<string>(type: "TEXT", nullable: false),
                    shortDisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    color = table.Column<string>(type: "TEXT", nullable: false),
                    alternateColor = table.Column<string>(type: "TEXT", nullable: false),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    venueid = table.Column<int>(type: "INTEGER", nullable: false),
                    logo = table.Column<string>(type: "TEXT", nullable: false),
                    conferenceId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.id);
                    table.ForeignKey(
                        name: "FK_Team_Venue_venueid",
                        column: x => x.venueid,
                        principalTable: "Venue",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViewingPolicy",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    audienceid = table.Column<int>(type: "INTEGER", nullable: false),
                    actions = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    externalId = table.Column<string>(type: "TEXT", nullable: false),
                    Policyid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewingPolicy", x => x.id);
                    table.ForeignKey(
                        name: "FK_ViewingPolicy_Audience_audienceid",
                        column: x => x.audienceid,
                        principalTable: "Audience",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViewingPolicy_Policy_Policyid",
                        column: x => x.Policyid,
                        principalTable: "Policy",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "League",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    uid = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    abbreviation = table.Column<string>(type: "TEXT", nullable: false),
                    midsizeName = table.Column<string>(type: "TEXT", nullable: false),
                    slug = table.Column<string>(type: "TEXT", nullable: false),
                    seasonId = table.Column<int>(type: "INTEGER", nullable: false),
                    calendarType = table.Column<string>(type: "TEXT", nullable: false),
                    calendarIsWhitelist = table.Column<bool>(type: "INTEGER", nullable: false),
                    calendarStartDate = table.Column<string>(type: "TEXT", nullable: false),
                    calendarEndDate = table.Column<string>(type: "TEXT", nullable: false),
                    calendar = table.Column<string>(type: "TEXT", nullable: false),
                    href = table.Column<string>(type: "TEXT", nullable: false),
                    ScoreboardResultId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.id);
                    table.ForeignKey(
                        name: "FK_League_LeagueSeason_seasonId",
                        column: x => x.seasonId,
                        principalTable: "LeagueSeason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_League_ScoreboardResults_ScoreboardResultId",
                        column: x => x.ScoreboardResultId,
                        principalTable: "ScoreboardResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Athlete",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    fullName = table.Column<string>(type: "TEXT", nullable: false),
                    displayName = table.Column<string>(type: "TEXT", nullable: false),
                    shortName = table.Column<string>(type: "TEXT", nullable: false),
                    headshot = table.Column<string>(type: "TEXT", nullable: false),
                    jersey = table.Column<string>(type: "TEXT", nullable: false),
                    position_abbreviation = table.Column<string>(type: "TEXT", nullable: false),
                    teamid = table.Column<int>(type: "INTEGER", nullable: false),
                    active = table.Column<bool>(type: "INTEGER", nullable: false)
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
                name: "LastPlay",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    typeid = table.Column<int>(type: "INTEGER", nullable: false),
                    text = table.Column<string>(type: "TEXT", nullable: false),
                    scoreValue = table.Column<int>(type: "INTEGER", nullable: false),
                    teamid = table.Column<int>(type: "INTEGER", nullable: false),
                    probability_tiePercentage = table.Column<double>(type: "REAL", nullable: false),
                    probability_homeWinPercentage = table.Column<double>(type: "REAL", nullable: false),
                    probability_awayWinPercentage = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastPlay", x => x.id);
                    table.ForeignKey(
                        name: "FK_LastPlay_Team_teamid",
                        column: x => x.teamid,
                        principalTable: "Team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LastPlay_Type_typeid",
                        column: x => x.typeid,
                        principalTable: "Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    href = table.Column<string>(type: "TEXT", nullable: false),
                    width = table.Column<int>(type: "INTEGER", nullable: false),
                    height = table.Column<int>(type: "INTEGER", nullable: false),
                    alt = table.Column<string>(type: "TEXT", nullable: false),
                    rel = table.Column<string>(type: "TEXT", nullable: false),
                    lastUpdated = table.Column<string>(type: "TEXT", nullable: false),
                    Leagueid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logo_League_Leagueid",
                        column: x => x.Leagueid,
                        principalTable: "League",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    sportId = table.Column<int>(type: "INTEGER", nullable: false),
                    athleteId = table.Column<int>(type: "INTEGER", nullable: false),
                    uid = table.Column<string>(type: "TEXT", nullable: false),
                    teamId = table.Column<int>(type: "INTEGER", nullable: true),
                    leagueId = table.Column<int>(type: "INTEGER", nullable: true),
                    Videoid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                    table.ForeignKey(
                        name: "FK_Category_Athlete_athleteId",
                        column: x => x.athleteId,
                        principalTable: "Athlete",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Category_League_leagueId",
                        column: x => x.leagueId,
                        principalTable: "League",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Category_Team_teamId",
                        column: x => x.teamId,
                        principalTable: "Team",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Category_Video_Videoid",
                        column: x => x.Videoid,
                        principalTable: "Video",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AthletesInvolved",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fullName = table.Column<string>(type: "TEXT", nullable: false),
                    displayName = table.Column<string>(type: "TEXT", nullable: false),
                    shortName = table.Column<string>(type: "TEXT", nullable: false),
                    headshot = table.Column<string>(type: "TEXT", nullable: false),
                    jersey = table.Column<string>(type: "TEXT", nullable: false),
                    position = table.Column<string>(type: "TEXT", nullable: false),
                    teamid = table.Column<int>(type: "INTEGER", nullable: false),
                    LastPlayid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthletesInvolved", x => x.id);
                    table.ForeignKey(
                        name: "FK_AthletesInvolved_LastPlay_LastPlayid",
                        column: x => x.LastPlayid,
                        principalTable: "LastPlay",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AthletesInvolved_Team_teamid",
                        column: x => x.teamid,
                        principalTable: "Team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Airing",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    createdBy = table.Column<string>(type: "TEXT", nullable: false),
                    createdOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    lastModifiedBy = table.Column<string>(type: "TEXT", nullable: false),
                    lastModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    artworkUrl = table.Column<string>(type: "TEXT", nullable: false),
                    externalId = table.Column<string>(type: "TEXT", nullable: false),
                    propertiesId = table.Column<int>(type: "INTEGER", nullable: false),
                    productLinks_web = table.Column<string>(type: "TEXT", nullable: false),
                    productLinks_mobile = table.Column<string>(type: "TEXT", nullable: false),
                    program = table.Column<string>(type: "TEXT", nullable: false),
                    playableUrl = table.Column<string>(type: "TEXT", nullable: false),
                    policyUrl = table.Column<string>(type: "TEXT", nullable: false),
                    start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    end = table.Column<DateTime>(type: "TEXT", nullable: false),
                    network = table.Column<string>(type: "TEXT", nullable: false),
                    networkId = table.Column<string>(type: "TEXT", nullable: false),
                    policyid = table.Column<int>(type: "INTEGER", nullable: false),
                    withinPlayWindow = table.Column<bool>(type: "INTEGER", nullable: false),
                    network_shortName = table.Column<string>(type: "TEXT", nullable: false),
                    network_displayName = table.Column<string>(type: "TEXT", nullable: false),
                    program_language = table.Column<string>(type: "TEXT", nullable: false),
                    program_eventId = table.Column<string>(type: "TEXT", nullable: false),
                    program_eventUrl = table.Column<string>(type: "TEXT", nullable: false),
                    program_shortTitle = table.Column<string>(type: "TEXT", nullable: false),
                    program_originalAirDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    program_firstPresented = table.Column<DateTime>(type: "TEXT", nullable: false),
                    webAiringLink = table.Column<string>(type: "TEXT", nullable: false),
                    appAiringLink = table.Column<string>(type: "TEXT", nullable: false),
                    webGameLink = table.Column<string>(type: "TEXT", nullable: false),
                    appGameLink = table.Column<string>(type: "TEXT", nullable: false),
                    Competitionid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airing", x => x.id);
                    table.ForeignKey(
                        name: "FK_Airing_Policy_policyid",
                        column: x => x.policyid,
                        principalTable: "Policy",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Airing_Properties_propertiesId",
                        column: x => x.propertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    url = table.Column<string>(type: "TEXT", nullable: false),
                    alt = table.Column<string>(type: "TEXT", nullable: false),
                    caption = table.Column<string>(type: "TEXT", nullable: false),
                    credit = table.Column<string>(type: "TEXT", nullable: false),
                    width = table.Column<int>(type: "INTEGER", nullable: false),
                    height = table.Column<int>(type: "INTEGER", nullable: false),
                    Airingid = table.Column<int>(type: "INTEGER", nullable: true),
                    Videoid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Airing_Airingid",
                        column: x => x.Airingid,
                        principalTable: "Airing",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Image_Video_Videoid",
                        column: x => x.Videoid,
                        principalTable: "Video",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProgramCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    artworkUrl = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    sportId = table.Column<string>(type: "TEXT", nullable: false),
                    Airingid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramCategory", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProgramCategory_Airing_Airingid",
                        column: x => x.Airingid,
                        principalTable: "Airing",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Peer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    height = table.Column<int>(type: "INTEGER", nullable: false),
                    width = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    url = table.Column<string>(type: "TEXT", nullable: false),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peer_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Broadcast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    market = table.Column<string>(type: "TEXT", nullable: false),
                    names = table.Column<string>(type: "TEXT", nullable: false),
                    Competitionid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broadcast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    uid = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<string>(type: "TEXT", nullable: false),
                    attendance = table.Column<int>(type: "INTEGER", nullable: false),
                    typeid = table.Column<int>(type: "INTEGER", nullable: false),
                    timeValid = table.Column<bool>(type: "INTEGER", nullable: false),
                    neutralSite = table.Column<bool>(type: "INTEGER", nullable: false),
                    conferenceCompetition = table.Column<bool>(type: "INTEGER", nullable: false),
                    playByPlayAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    recent = table.Column<bool>(type: "INTEGER", nullable: false),
                    venueid = table.Column<int>(type: "INTEGER", nullable: false),
                    situation_lastPlayid = table.Column<int>(type: "INTEGER", nullable: false),
                    status_clock = table.Column<double>(type: "REAL", nullable: false),
                    status_displayClock = table.Column<string>(type: "TEXT", nullable: false),
                    status_period = table.Column<int>(type: "INTEGER", nullable: false),
                    status_typeid = table.Column<int>(type: "INTEGER", nullable: false),
                    format_regulation_periods = table.Column<int>(type: "INTEGER", nullable: false),
                    startDate = table.Column<string>(type: "TEXT", nullable: false),
                    tournamentId = table.Column<int>(type: "INTEGER", nullable: true),
                    Eventid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.id);
                    table.ForeignKey(
                        name: "FK_Competition_LastPlay_situation_lastPlayid",
                        column: x => x.situation_lastPlayid,
                        principalTable: "LastPlay",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competition_Type_status_typeid",
                        column: x => x.status_typeid,
                        principalTable: "Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competition_Type_typeid",
                        column: x => x.typeid,
                        principalTable: "Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competition_Venue_venueid",
                        column: x => x.venueid,
                        principalTable: "Venue",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competitor",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    uid = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    order = table.Column<int>(type: "INTEGER", nullable: false),
                    homeAway = table.Column<string>(type: "TEXT", nullable: false),
                    teamid = table.Column<int>(type: "INTEGER", nullable: false),
                    score = table.Column<string>(type: "TEXT", nullable: false),
                    curatedRank_current = table.Column<int>(type: "INTEGER", nullable: false),
                    Competitionid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitor", x => x.id);
                    table.ForeignKey(
                        name: "FK_Competitor_Competition_Competitionid",
                        column: x => x.Competitionid,
                        principalTable: "Competition",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Competitor_Team_teamid",
                        column: x => x.teamid,
                        principalTable: "Team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeoBroadcast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    typeid = table.Column<int>(type: "INTEGER", nullable: false),
                    marketid = table.Column<int>(type: "INTEGER", nullable: false),
                    mediaId = table.Column<int>(type: "INTEGER", nullable: false),
                    lang = table.Column<string>(type: "TEXT", nullable: false),
                    region = table.Column<string>(type: "TEXT", nullable: false),
                    Competitionid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoBroadcast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeoBroadcast_Competition_Competitionid",
                        column: x => x.Competitionid,
                        principalTable: "Competition",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_GeoBroadcast_Market_marketid",
                        column: x => x.marketid,
                        principalTable: "Market",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeoBroadcast_Media_mediaId",
                        column: x => x.mediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeoBroadcast_Type_typeid",
                        column: x => x.typeid,
                        principalTable: "Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    headline = table.Column<string>(type: "TEXT", nullable: false),
                    Competitionid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_Competition_Competitionid",
                        column: x => x.Competitionid,
                        principalTable: "Competition",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Odd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    providerid = table.Column<int>(type: "INTEGER", nullable: false),
                    details = table.Column<string>(type: "TEXT", nullable: false),
                    overUnder = table.Column<double>(type: "REAL", nullable: false),
                    Competitionid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odd_Competition_Competitionid",
                        column: x => x.Competitionid,
                        principalTable: "Competition",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Odd_Provider_providerid",
                        column: x => x.providerid,
                        principalTable: "Provider",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    summary = table.Column<string>(type: "TEXT", nullable: false),
                    numberAvailable = table.Column<int>(type: "INTEGER", nullable: false),
                    Competitionid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Competition_Competitionid",
                        column: x => x.Competitionid,
                        principalTable: "Competition",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Leader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    displayName = table.Column<string>(type: "TEXT", nullable: false),
                    shortDisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    abbreviation = table.Column<string>(type: "TEXT", nullable: false),
                    displayValue = table.Column<string>(type: "TEXT", nullable: false),
                    value = table.Column<double>(type: "REAL", nullable: false),
                    athleteid = table.Column<int>(type: "INTEGER", nullable: false),
                    teamid = table.Column<int>(type: "INTEGER", nullable: false),
                    Competitorid = table.Column<int>(type: "INTEGER", nullable: true),
                    LeaderId = table.Column<int>(type: "INTEGER", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Linescore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    value = table.Column<double>(type: "REAL", nullable: false),
                    Competitorid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linescore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Linescore_Competitor_Competitorid",
                        column: x => x.Competitorid,
                        principalTable: "Competitor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    abbreviation = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    summary = table.Column<string>(type: "TEXT", nullable: false),
                    Competitorid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Record_Competitor_Competitorid",
                        column: x => x.Competitorid,
                        principalTable: "Competitor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    abbreviation = table.Column<string>(type: "TEXT", nullable: false),
                    displayValue = table.Column<string>(type: "TEXT", nullable: false),
                    rankDisplayValue = table.Column<string>(type: "TEXT", nullable: false),
                    Competitorid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistic_Competitor_Competitorid",
                        column: x => x.Competitorid,
                        principalTable: "Competitor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    uid = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    shortName = table.Column<string>(type: "TEXT", nullable: false),
                    seasonId = table.Column<int>(type: "INTEGER", nullable: false),
                    status_clock = table.Column<double>(type: "REAL", nullable: false),
                    status_displayClock = table.Column<string>(type: "TEXT", nullable: false),
                    status_period = table.Column<int>(type: "INTEGER", nullable: false),
                    status_typeid = table.Column<int>(type: "INTEGER", nullable: false),
                    weather_displayValue = table.Column<string>(type: "TEXT", nullable: false),
                    weather_temperature = table.Column<int>(type: "INTEGER", nullable: false),
                    weather_highTemperature = table.Column<int>(type: "INTEGER", nullable: false),
                    weather_conditionId = table.Column<string>(type: "TEXT", nullable: false),
                    weather_linkId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScoreboardResultId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.id);
                    table.ForeignKey(
                        name: "FK_Event_ScoreboardResults_ScoreboardResultId",
                        column: x => x.ScoreboardResultId,
                        principalTable: "ScoreboardResults",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Event_Season_seasonId",
                        column: x => x.seasonId,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Type_status_typeid",
                        column: x => x.status_typeid,
                        principalTable: "Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    language = table.Column<string>(type: "TEXT", nullable: false),
                    rel = table.Column<string>(type: "TEXT", nullable: false),
                    href = table.Column<string>(type: "TEXT", nullable: false),
                    text = table.Column<string>(type: "TEXT", nullable: false),
                    shortText = table.Column<string>(type: "TEXT", nullable: false),
                    isExternal = table.Column<bool>(type: "INTEGER", nullable: false),
                    isPremium = table.Column<bool>(type: "INTEGER", nullable: false),
                    AthletesInvolvedid = table.Column<int>(type: "INTEGER", nullable: true),
                    Eventid = table.Column<int>(type: "INTEGER", nullable: true),
                    TicketId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_AthletesInvolved_AthletesInvolvedid",
                        column: x => x.AthletesInvolvedid,
                        principalTable: "AthletesInvolved",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Link_Event_Eventid",
                        column: x => x.Eventid,
                        principalTable: "Event",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Link_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airing_Competitionid",
                table: "Airing",
                column: "Competitionid");

            migrationBuilder.CreateIndex(
                name: "IX_Airing_policyid",
                table: "Airing",
                column: "policyid");

            migrationBuilder.CreateIndex(
                name: "IX_Airing_propertiesId",
                table: "Airing",
                column: "propertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Athlete_teamid",
                table: "Athlete",
                column: "teamid");

            migrationBuilder.CreateIndex(
                name: "IX_AthletesInvolved_LastPlayid",
                table: "AthletesInvolved",
                column: "LastPlayid");

            migrationBuilder.CreateIndex(
                name: "IX_AthletesInvolved_teamid",
                table: "AthletesInvolved",
                column: "teamid");

            migrationBuilder.CreateIndex(
                name: "IX_Audience_propertiesId",
                table: "Audience",
                column: "propertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Broadcast_Competitionid",
                table: "Broadcast",
                column: "Competitionid");

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
                name: "IX_Category_Videoid",
                table: "Category",
                column: "Videoid");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_Eventid",
                table: "Competition",
                column: "Eventid");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_situation_lastPlayid",
                table: "Competition",
                column: "situation_lastPlayid");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_status_typeid",
                table: "Competition",
                column: "status_typeid");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_typeid",
                table: "Competition",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_venueid",
                table: "Competition",
                column: "venueid");

            migrationBuilder.CreateIndex(
                name: "IX_Competitor_Competitionid",
                table: "Competitor",
                column: "Competitionid");

            migrationBuilder.CreateIndex(
                name: "IX_Competitor_teamid",
                table: "Competitor",
                column: "teamid");

            migrationBuilder.CreateIndex(
                name: "IX_Event_ScoreboardResultId",
                table: "Event",
                column: "ScoreboardResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_seasonId",
                table: "Event",
                column: "seasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_status_typeid",
                table: "Event",
                column: "status_typeid");

            migrationBuilder.CreateIndex(
                name: "IX_Event_weather_linkId",
                table: "Event",
                column: "weather_linkId");

            migrationBuilder.CreateIndex(
                name: "IX_GeoBroadcast_Competitionid",
                table: "GeoBroadcast",
                column: "Competitionid");

            migrationBuilder.CreateIndex(
                name: "IX_GeoBroadcast_marketid",
                table: "GeoBroadcast",
                column: "marketid");

            migrationBuilder.CreateIndex(
                name: "IX_GeoBroadcast_mediaId",
                table: "GeoBroadcast",
                column: "mediaId");

            migrationBuilder.CreateIndex(
                name: "IX_GeoBroadcast_typeid",
                table: "GeoBroadcast",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_Image_Airingid",
                table: "Image",
                column: "Airingid");

            migrationBuilder.CreateIndex(
                name: "IX_Image_Videoid",
                table: "Image",
                column: "Videoid");

            migrationBuilder.CreateIndex(
                name: "IX_LastPlay_teamid",
                table: "LastPlay",
                column: "teamid");

            migrationBuilder.CreateIndex(
                name: "IX_LastPlay_typeid",
                table: "LastPlay",
                column: "typeid");

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

            migrationBuilder.CreateIndex(
                name: "IX_League_ScoreboardResultId",
                table: "League",
                column: "ScoreboardResultId");

            migrationBuilder.CreateIndex(
                name: "IX_League_seasonId",
                table: "League",
                column: "seasonId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueSeason_typeid",
                table: "LeagueSeason",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_Linescore_Competitorid",
                table: "Linescore",
                column: "Competitorid");

            migrationBuilder.CreateIndex(
                name: "IX_Link_AthletesInvolvedid",
                table: "Link",
                column: "AthletesInvolvedid");

            migrationBuilder.CreateIndex(
                name: "IX_Link_Eventid",
                table: "Link",
                column: "Eventid");

            migrationBuilder.CreateIndex(
                name: "IX_Link_TicketId",
                table: "Link",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Logo_Leagueid",
                table: "Logo",
                column: "Leagueid");

            migrationBuilder.CreateIndex(
                name: "IX_Note_Competitionid",
                table: "Note",
                column: "Competitionid");

            migrationBuilder.CreateIndex(
                name: "IX_Odd_Competitionid",
                table: "Odd",
                column: "Competitionid");

            migrationBuilder.CreateIndex(
                name: "IX_Odd_providerid",
                table: "Odd",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "IX_Peer_ImageId",
                table: "Peer",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramCategory_Airingid",
                table: "ProgramCategory",
                column: "Airingid");

            migrationBuilder.CreateIndex(
                name: "IX_Record_Competitorid",
                table: "Record",
                column: "Competitorid");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic_Competitorid",
                table: "Statistic",
                column: "Competitorid");

            migrationBuilder.CreateIndex(
                name: "IX_Team_venueid",
                table: "Team",
                column: "venueid");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Competitionid",
                table: "Ticket",
                column: "Competitionid");

            migrationBuilder.CreateIndex(
                name: "IX_Video_deviceRestrictionsId",
                table: "Video",
                column: "deviceRestrictionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_ScoreboardResultId",
                table: "Video",
                column: "ScoreboardResultId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewingPolicy_audienceid",
                table: "ViewingPolicy",
                column: "audienceid");

            migrationBuilder.CreateIndex(
                name: "IX_ViewingPolicy_Policyid",
                table: "ViewingPolicy",
                column: "Policyid");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreboardItem_PartialScoreboardResults_PartialScoreboardResultId",
                table: "ScoreboardItem",
                column: "PartialScoreboardResultId",
                principalTable: "PartialScoreboardResults",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Airing_Competition_Competitionid",
                table: "Airing",
                column: "Competitionid",
                principalTable: "Competition",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Broadcast_Competition_Competitionid",
                table: "Broadcast",
                column: "Competitionid",
                principalTable: "Competition",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competition_Event_Eventid",
                table: "Competition",
                column: "Eventid",
                principalTable: "Event",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Link_weather_linkId",
                table: "Event",
                column: "weather_linkId",
                principalTable: "Link",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreboardItem_PartialScoreboardResults_PartialScoreboardResultId",
                table: "ScoreboardItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Competition_Competitionid",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_AthletesInvolved_Team_teamid",
                table: "AthletesInvolved");

            migrationBuilder.DropForeignKey(
                name: "FK_LastPlay_Team_teamid",
                table: "LastPlay");

            migrationBuilder.DropForeignKey(
                name: "FK_AthletesInvolved_LastPlay_LastPlayid",
                table: "AthletesInvolved");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_Event_Eventid",
                table: "Link");

            migrationBuilder.DropTable(
                name: "Broadcast");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "GeoBroadcast");

            migrationBuilder.DropTable(
                name: "Leader");

            migrationBuilder.DropTable(
                name: "Linescore");

            migrationBuilder.DropTable(
                name: "Logo");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Odd");

            migrationBuilder.DropTable(
                name: "PartialScoreboardResults");

            migrationBuilder.DropTable(
                name: "Peer");

            migrationBuilder.DropTable(
                name: "ProgramCategory");

            migrationBuilder.DropTable(
                name: "Record");

            migrationBuilder.DropTable(
                name: "Statistic");

            migrationBuilder.DropTable(
                name: "ViewingPolicy");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Athlete");

            migrationBuilder.DropTable(
                name: "League");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Competitor");

            migrationBuilder.DropTable(
                name: "Audience");

            migrationBuilder.DropTable(
                name: "LeagueSeason");

            migrationBuilder.DropTable(
                name: "Airing");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "DeviceRestrictions");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropTable(
                name: "LastPlay");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "AthletesInvolved");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropColumn(
                name: "eventsDate_seasonType",
                table: "ScoreboardResults");

            migrationBuilder.RenameColumn(
                name: "groups",
                table: "ScoreboardResults",
                newName: "FilterDate");

            migrationBuilder.RenameColumn(
                name: "eventsDate_date",
                table: "ScoreboardResults",
                newName: "FetchDateTime");

            migrationBuilder.RenameColumn(
                name: "PartialScoreboardResultId",
                table: "ScoreboardItem",
                newName: "ScoreboardResultId");

            migrationBuilder.RenameIndex(
                name: "IX_ScoreboardItem_PartialScoreboardResultId",
                table: "ScoreboardItem",
                newName: "IX_ScoreboardItem_ScoreboardResultId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ScoreboardResults",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreboardItem_ScoreboardResults_ScoreboardResultId",
                table: "ScoreboardItem",
                column: "ScoreboardResultId",
                principalTable: "ScoreboardResults",
                principalColumn: "Id");
        }
    }
}
