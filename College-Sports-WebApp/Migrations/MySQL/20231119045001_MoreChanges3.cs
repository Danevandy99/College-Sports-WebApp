using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College_Sports_WebApp.Migrations.MySQL
{
    /// <inheritdoc />
    public partial class MoreChanges3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competition_Venue_venueid",
                table: "Competition");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Venue_venueid",
                table: "Team");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropIndex(
                name: "IX_Team_venueid",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Competition_venueid",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "venueid",
                table: "Team");

            migrationBuilder.RenameColumn(
                name: "venueid",
                table: "Competition",
                newName: "venue_id");

            migrationBuilder.AddColumn<string>(
                name: "venue_address_city",
                table: "Competition",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "venue_address_state",
                table: "Competition",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "venue_capacity",
                table: "Competition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "venue_fullName",
                table: "Competition",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "venue_indoor",
                table: "Competition",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "venue_address_city",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "venue_address_state",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "venue_capacity",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "venue_fullName",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "venue_indoor",
                table: "Competition");

            migrationBuilder.RenameColumn(
                name: "venue_id",
                table: "Competition",
                newName: "venueid");

            migrationBuilder.AddColumn<int>(
                name: "venueid",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    fullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    indoor = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    address_city = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address_state = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Team_venueid",
                table: "Team",
                column: "venueid");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_venueid",
                table: "Competition",
                column: "venueid");

            migrationBuilder.AddForeignKey(
                name: "FK_Competition_Venue_venueid",
                table: "Competition",
                column: "venueid",
                principalTable: "Venue",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Venue_venueid",
                table: "Team",
                column: "venueid",
                principalTable: "Venue",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
