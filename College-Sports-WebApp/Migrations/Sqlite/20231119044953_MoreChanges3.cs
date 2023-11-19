using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College_Sports_WebApp.Migrations.Sqlite
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
                newName: "venue_indoor");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Video",
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

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Competition",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "venue_address_city",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "venue_address_state",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "venue_capacity",
                table: "Competition",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "venue_fullName",
                table: "Competition",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "venue_id",
                table: "Competition",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
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
                name: "venue_id",
                table: "Competition");

            migrationBuilder.RenameColumn(
                name: "venue_indoor",
                table: "Competition",
                newName: "venueid");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Video",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "venueid",
                table: "Team",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ScoreboardResults",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Competition",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    fullName = table.Column<string>(type: "TEXT", nullable: false),
                    indoor = table.Column<bool>(type: "INTEGER", nullable: false),
                    address_city = table.Column<string>(type: "TEXT", nullable: false),
                    address_state = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.id);
                });

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
