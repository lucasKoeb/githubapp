﻿// <auto-generated />
using GitHubApp.DAL;
using GitHubApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GitHubApp.Migrations
{
    [DbContext(typeof(GitHubAppContext))]
    [Migration("20180120012608_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("GitHubApp.Models.GHRepo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at");

                    b.Property<string>("description");

                    b.Property<bool>("fork");

                    b.Property<string>("full_name");

                    b.Property<string>("html_url");

                    b.Property<string>("language");

                    b.Property<string>("name");

                    b.Property<int>("owner_id");

                    b.Property<bool>("private");

                    b.Property<DateTime>("pushed_at");

                    b.Property<double>("score");

                    b.Property<int>("stargazers_count");

                    b.Property<DateTime>("updated_at");

                    b.Property<int>("watchers_count");

                    b.HasKey("id");

                    b.HasIndex("owner_id");

                    b.ToTable("GHRepo");
                });

            modelBuilder.Entity("GitHubApp.Models.GHRepoOwner", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("login");

                    b.HasKey("id");

                    b.ToTable("GHRepoOwner");
                });

            modelBuilder.Entity("GitHubApp.Models.GHRepo", b =>
                {
                    b.HasOne("GitHubApp.Models.GHRepoOwner", "owner")
                        .WithMany("repositories")
                        .HasForeignKey("owner_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
