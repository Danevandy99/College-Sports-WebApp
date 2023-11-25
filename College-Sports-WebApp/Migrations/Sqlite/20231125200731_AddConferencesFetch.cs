﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College_Sports_WebApp.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class AddConferencesFetch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConferencesFetches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JsonResponse = table.Column<string>(type: "TEXT", nullable: false),
                    FetchedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferencesFetches", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConferencesFetches");
        }
    }
}
