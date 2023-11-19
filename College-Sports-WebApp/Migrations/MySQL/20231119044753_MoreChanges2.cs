using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College_Sports_WebApp.Migrations.MySQL
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

            migrationBuilder.AddColumn<string>(
                name: "market_type",
                table: "GeoBroadcast",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
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
