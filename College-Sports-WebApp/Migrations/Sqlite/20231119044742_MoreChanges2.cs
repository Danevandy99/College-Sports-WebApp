using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College_Sports_WebApp.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class MoreChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeoBroadcast_Market_marketid",
                table: "GeoBroadcast");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropIndex(
                name: "IX_GeoBroadcast_marketid",
                table: "GeoBroadcast");

            migrationBuilder.RenameColumn(
                name: "marketid",
                table: "GeoBroadcast",
                newName: "market_id");

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
                name: "market_type",
                table: "GeoBroadcast",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "market_type",
                table: "GeoBroadcast");

            migrationBuilder.RenameColumn(
                name: "market_id",
                table: "GeoBroadcast",
                newName: "marketid");

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

            migrationBuilder.CreateIndex(
                name: "IX_GeoBroadcast_marketid",
                table: "GeoBroadcast",
                column: "marketid");

            migrationBuilder.AddForeignKey(
                name: "FK_GeoBroadcast_Market_marketid",
                table: "GeoBroadcast",
                column: "marketid",
                principalTable: "Market",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
