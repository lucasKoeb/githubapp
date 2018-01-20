using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GitHubApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GHRepoOwner",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    login = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GHRepoOwner", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GHRepo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_at = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    fork = table.Column<bool>(nullable: false),
                    full_name = table.Column<string>(nullable: true),
                    html_url = table.Column<string>(nullable: true),
                    language = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    owner_id = table.Column<int>(nullable: false),
                    @private = table.Column<bool>(name: "private", nullable: false),
                    pushed_at = table.Column<DateTime>(nullable: false),
                    score = table.Column<double>(nullable: false),
                    stargazers_count = table.Column<int>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    watchers_count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GHRepo", x => x.id);
                    table.ForeignKey(
                        name: "FK_GHRepo_GHRepoOwner_owner_id",
                        column: x => x.owner_id,
                        principalTable: "GHRepoOwner",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GHRepo_owner_id",
                table: "GHRepo",
                column: "owner_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GHRepo");

            migrationBuilder.DropTable(
                name: "GHRepoOwner");
        }
    }
}
