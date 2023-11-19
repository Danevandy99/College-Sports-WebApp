using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College_Sports_WebApp.Migrations.MySQL
{
    /// <inheritdoc />
    public partial class MoreChanges5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "type_type",
                table: "LastPlay");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "type_abbreviation",
                table: "LastPlay",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "type_completed",
                table: "LastPlay",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "type_description",
                table: "LastPlay",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "type_detail",
                table: "LastPlay",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "type_name",
                table: "LastPlay",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "type_shortDetail",
                table: "LastPlay",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "type_shortName",
                table: "LastPlay",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "type_state",
                table: "LastPlay",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "type_type",
                table: "LastPlay",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
