﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_rocket_launcher.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaunchStatus",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    abbrev = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaunchStatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LaunchDetails",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    url = table.Column<string>(type: "TEXT", nullable: false),
                    slug = table.Column<string>(type: "TEXT", nullable: false),
                    flight_club_url = table.Column<string>(type: "TEXT", nullable: true),
                    r_spacex_api_id = table.Column<string>(type: "TEXT", nullable: true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    statusid = table.Column<int>(type: "INTEGER", nullable: false),
                    lastUpdate = table.Column<string>(type: "TEXT", nullable: false),
                    window_end = table.Column<string>(type: "TEXT", nullable: true),
                    window_start = table.Column<string>(type: "TEXT", nullable: true),
                    probability = table.Column<int>(type: "INTEGER", nullable: true),
                    hold_reason = table.Column<string>(type: "TEXT", nullable: true),
                    fail_rason = table.Column<string>(type: "TEXT", nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaunchDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_LaunchDetails_LaunchStatus_statusid",
                        column: x => x.statusid,
                        principalTable: "LaunchStatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouritesLaunches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LaunchId = table.Column<string>(type: "TEXT", nullable: false),
                    LaunchDetailsJson = table.Column<string>(type: "TEXT", nullable: false),
                    isFavourite = table.Column<bool>(type: "INTEGER", nullable: false),
                    detailsid = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouritesLaunches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouritesLaunches_LaunchDetails_detailsid",
                        column: x => x.detailsid,
                        principalTable: "LaunchDetails",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouritesLaunches_detailsid",
                table: "FavouritesLaunches",
                column: "detailsid");

            migrationBuilder.CreateIndex(
                name: "IX_LaunchDetails_statusid",
                table: "LaunchDetails",
                column: "statusid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouritesLaunches");

            migrationBuilder.DropTable(
                name: "LaunchDetails");

            migrationBuilder.DropTable(
                name: "LaunchStatus");
        }
    }
}