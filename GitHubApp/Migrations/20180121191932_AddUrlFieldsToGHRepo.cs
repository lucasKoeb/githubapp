using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GitHubApp.Migrations
{
    public partial class AddUrlFieldsToGHRepo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "topics",
                table: "GHRepos");

            migrationBuilder.AddColumn<string>(
                name: "clone_url",
                table: "GHRepos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "git_url",
                table: "GHRepos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ssh_url",
                table: "GHRepos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "svn_url",
                table: "GHRepos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clone_url",
                table: "GHRepos");

            migrationBuilder.DropColumn(
                name: "git_url",
                table: "GHRepos");

            migrationBuilder.DropColumn(
                name: "ssh_url",
                table: "GHRepos");

            migrationBuilder.DropColumn(
                name: "svn_url",
                table: "GHRepos");

            migrationBuilder.AddColumn<List<string>>(
                name: "topics",
                table: "GHRepos",
                nullable: true);
        }
    }
}
