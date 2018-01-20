using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GitHubApp.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GHRepo_GHRepoOwner_owner_id",
                table: "GHRepo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GHRepoOwner",
                table: "GHRepoOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GHRepo",
                table: "GHRepo");

            migrationBuilder.RenameTable(
                name: "GHRepoOwner",
                newName: "GHRepoOwners");

            migrationBuilder.RenameTable(
                name: "GHRepo",
                newName: "GHRepos");

            migrationBuilder.RenameIndex(
                name: "IX_GHRepo_owner_id",
                table: "GHRepos",
                newName: "IX_GHRepos_owner_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GHRepoOwners",
                table: "GHRepoOwners",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GHRepos",
                table: "GHRepos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_GHRepos_GHRepoOwners_owner_id",
                table: "GHRepos",
                column: "owner_id",
                principalTable: "GHRepoOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GHRepos_GHRepoOwners_owner_id",
                table: "GHRepos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GHRepos",
                table: "GHRepos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GHRepoOwners",
                table: "GHRepoOwners");

            migrationBuilder.RenameTable(
                name: "GHRepos",
                newName: "GHRepo");

            migrationBuilder.RenameTable(
                name: "GHRepoOwners",
                newName: "GHRepoOwner");

            migrationBuilder.RenameIndex(
                name: "IX_GHRepos_owner_id",
                table: "GHRepo",
                newName: "IX_GHRepo_owner_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GHRepo",
                table: "GHRepo",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GHRepoOwner",
                table: "GHRepoOwner",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_GHRepo_GHRepoOwner_owner_id",
                table: "GHRepo",
                column: "owner_id",
                principalTable: "GHRepoOwner",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
