using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College_Sports_WebApp.Migrations.MySQL
{
    /// <inheritdoc />
    public partial class MoreChanges6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "startDate",
                table: "LeagueSeason",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "endDate",
                table: "LeagueSeason",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "startDate",
                table: "LeagueSeason",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "endDate",
                table: "LeagueSeason",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "type_completed",
                table: "LeagueSeason",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "type_description",
                table: "LeagueSeason",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "type_detail",
                table: "LeagueSeason",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "type_shortDetail",
                table: "LeagueSeason",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "type_shortName",
                table: "LeagueSeason",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "type_state",
                table: "LeagueSeason",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "type_text",
                table: "LeagueSeason",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
