using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College_Sports_WebApp.Migrations.MySQL
{
    /// <inheritdoc />
    public partial class AddNewScoreboardResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ScoreboardScoreCellItemRecord");

            migrationBuilder.DropTable(
                name: "ScoreboardScoreCell");

            migrationBuilder.DropColumn(
                name: "FilterDate",
                table: "ScoreboardResults");

            migrationBuilder.RenameColumn(
                name: "FetchDateTime",
                table: "ScoreboardResults",
                newName: "eventsDate_date");

            migrationBuilder.AddColumn<int>(
                name: "eventsDate_seasonType",
                table: "ScoreboardResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "groups",
                table: "ScoreboardResults",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DeviceRestrictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    devices = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceRestrictions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    shortName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    createdBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    lastModifiedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    hasEspnId3Heartbeats = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    language = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    shortTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    trueOriginal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    simulcastAiringId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contentCleared = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hasPassThroughAds = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dtcPackages = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    airingConcurrency = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isLive = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hasNielsenWatermarks = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    artworkLastModified = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    allowStartOver = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    trackingId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    commercialReplacement = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    allowedAccess = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    reAir = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    killDateTimestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    sponsored = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    liveReplay = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    broadcastStartOffset = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nbStartTimestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    feedType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ratingsId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    shortName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    canIpAuthenticate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    origination = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    iso3166 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    subscription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    year = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    slug = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    abbreviation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    state = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    completed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    detail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    shortDetail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    shortName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address_city = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address_state = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    indoor = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    source = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dataSourceIdentifier = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    headline = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    caption = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    premium = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ad_sport = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ad_bundle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tracking_sportName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tracking_leagueName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tracking_coverageType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tracking_trackingName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tracking_trackingId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cerebroId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contributingPartner = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contributingSystem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    originalPublishDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    timeRestrictions_embargoDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    timeRestrictions_expirationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    deviceRestrictionsId = table.Column<int>(type: "int", nullable: false),
                    syndicatable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    keywords = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    posterImages_default_href = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    posterImages_default_width = table.Column<int>(type: "int", nullable: false),
                    posterImages_default_height = table.Column<int>(type: "int", nullable: false),
                    posterImages_full_href = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    posterImages_wide_href = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    posterImages_square_href = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    thumbnail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ScoreboardResultId = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Audience",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    externalId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    match = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    propertiesId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LeagueSeason",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    year = table.Column<int>(type: "int", nullable: false),
                    startDate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    endDate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    displayName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    typeid = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    uid = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    abbreviation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    displayName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    shortDisplayName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    color = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    alternateColor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    venueid = table.Column<int>(type: "int", nullable: false),
                    logo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    conferenceId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ViewingPolicy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    audienceid = table.Column<int>(type: "int", nullable: false),
                    actions = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    externalId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Policyid = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "League",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    abbreviation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    midsizeName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    slug = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    seasonId = table.Column<int>(type: "int", nullable: false),
                    calendarType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    calendarIsWhitelist = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    calendarStartDate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    calendarEndDate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    calendar = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    href = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ScoreboardResultId = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Athlete",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    displayName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    shortName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    headshot = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    jersey = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    position_abbreviation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    teamid = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LastPlay",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    typeid = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    scoreValue = table.Column<int>(type: "int", nullable: false),
                    teamid = table.Column<int>(type: "int", nullable: false),
                    probability_tiePercentage = table.Column<double>(type: "double", nullable: false),
                    probability_homeWinPercentage = table.Column<double>(type: "double", nullable: false),
                    probability_awayWinPercentage = table.Column<double>(type: "double", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Logo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    href = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    width = table.Column<int>(type: "int", nullable: false),
                    height = table.Column<int>(type: "int", nullable: false),
                    alt = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastUpdated = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Leagueid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logo_League_Leagueid",
                        column: x => x.Leagueid,
                        principalTable: "League",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sportId = table.Column<int>(type: "int", nullable: false),
                    athleteId = table.Column<int>(type: "int", nullable: false),
                    uid = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    teamId = table.Column<int>(type: "int", nullable: true),
                    leagueId = table.Column<int>(type: "int", nullable: true),
                    Videoid = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AthletesInvolved",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    displayName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    shortName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    headshot = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    jersey = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    position = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    teamid = table.Column<int>(type: "int", nullable: false),
                    LastPlayid = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Airing",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    createdBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    lastModifiedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    artworkUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    externalId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    propertiesId = table.Column<int>(type: "int", nullable: false),
                    productLinks_web = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    productLinks_mobile = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    program = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    playableUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    policyUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    end = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    network = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    networkId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    policyid = table.Column<int>(type: "int", nullable: false),
                    withinPlayWindow = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    network_shortName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    network_displayName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    program_language = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    program_eventId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    program_eventUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    program_shortTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    program_originalAirDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    program_firstPresented = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    webAiringLink = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    appAiringLink = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    webGameLink = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    appGameLink = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Competitionid = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    alt = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    caption = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    credit = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    width = table.Column<int>(type: "int", nullable: false),
                    height = table.Column<int>(type: "int", nullable: false),
                    Airingid = table.Column<int>(type: "int", nullable: true),
                    Videoid = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProgramCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    artworkUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sportId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Airingid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramCategory", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProgramCategory_Airing_Airingid",
                        column: x => x.Airingid,
                        principalTable: "Airing",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Peer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    height = table.Column<int>(type: "int", nullable: false),
                    width = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peer_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Broadcast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    market = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    names = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Competitionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broadcast", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    attendance = table.Column<int>(type: "int", nullable: false),
                    typeid = table.Column<int>(type: "int", nullable: false),
                    timeValid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    neutralSite = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    conferenceCompetition = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    playByPlayAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    recent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    venueid = table.Column<int>(type: "int", nullable: false),
                    situation_lastPlayid = table.Column<int>(type: "int", nullable: false),
                    status_clock = table.Column<double>(type: "double", nullable: false),
                    status_displayClock = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status_period = table.Column<int>(type: "int", nullable: false),
                    status_typeid = table.Column<int>(type: "int", nullable: false),
                    format_regulation_periods = table.Column<int>(type: "int", nullable: false),
                    startDate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tournamentId = table.Column<int>(type: "int", nullable: true),
                    Eventid = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Competitor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    order = table.Column<int>(type: "int", nullable: false),
                    homeAway = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    teamid = table.Column<int>(type: "int", nullable: false),
                    score = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    curatedRank_current = table.Column<int>(type: "int", nullable: false),
                    Competitionid = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GeoBroadcast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    typeid = table.Column<int>(type: "int", nullable: false),
                    marketid = table.Column<int>(type: "int", nullable: false),
                    mediaId = table.Column<int>(type: "int", nullable: false),
                    lang = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    region = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Competitionid = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    headline = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Competitionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_Competition_Competitionid",
                        column: x => x.Competitionid,
                        principalTable: "Competition",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Odd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    providerid = table.Column<int>(type: "int", nullable: false),
                    details = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    overUnder = table.Column<double>(type: "double", nullable: false),
                    Competitionid = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    summary = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numberAvailable = table.Column<int>(type: "int", nullable: false),
                    Competitionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Competition_Competitionid",
                        column: x => x.Competitionid,
                        principalTable: "Competition",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Leader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    displayName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    shortDisplayName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    abbreviation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    displayValue = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    value = table.Column<double>(type: "double", nullable: false),
                    athleteid = table.Column<int>(type: "int", nullable: false),
                    teamid = table.Column<int>(type: "int", nullable: false),
                    Competitorid = table.Column<int>(type: "int", nullable: true),
                    LeaderId = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Linescore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    value = table.Column<double>(type: "double", nullable: false),
                    Competitorid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linescore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Linescore_Competitor_Competitorid",
                        column: x => x.Competitorid,
                        principalTable: "Competitor",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    abbreviation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    summary = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Competitorid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Record_Competitor_Competitorid",
                        column: x => x.Competitorid,
                        principalTable: "Competitor",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    abbreviation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    displayValue = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rankDisplayValue = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Competitorid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistic_Competitor_Competitorid",
                        column: x => x.Competitorid,
                        principalTable: "Competitor",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    uid = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    shortName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    seasonId = table.Column<int>(type: "int", nullable: false),
                    status_clock = table.Column<double>(type: "double", nullable: false),
                    status_displayClock = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status_period = table.Column<int>(type: "int", nullable: false),
                    status_typeid = table.Column<int>(type: "int", nullable: false),
                    weather_displayValue = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    weather_temperature = table.Column<int>(type: "int", nullable: false),
                    weather_highTemperature = table.Column<int>(type: "int", nullable: false),
                    weather_conditionId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    weather_linkId = table.Column<int>(type: "int", nullable: false),
                    ScoreboardResultId = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    language = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    href = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    shortText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isExternal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    isPremium = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AthletesInvolvedid = table.Column<int>(type: "int", nullable: true),
                    Eventid = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.DropColumn(
                name: "groups",
                table: "ScoreboardResults");

            migrationBuilder.RenameColumn(
                name: "eventsDate_date",
                table: "ScoreboardResults",
                newName: "FetchDateTime");

            migrationBuilder.AddColumn<DateOnly>(
                name: "FilterDate",
                table: "ScoreboardResults",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

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
                    LocationDetail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocationHeadline = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreboardEventInfo", x => x.Id);
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
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false)
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
                    CalloutsId = table.Column<int>(type: "int", nullable: false),
                    EventInfoId = table.Column<int>(type: "int", nullable: false),
                    ScoreCellId = table.Column<int>(type: "int", nullable: false),
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
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    IsAway = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LogoUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ScoreboardScoreCellId = table.Column<int>(type: "int", nullable: true),
                    TeamName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
    }
}
