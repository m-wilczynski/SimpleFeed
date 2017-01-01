using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFeed.Data.Migrations
{
    public partial class Entry_title_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "feed_entry",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "feed_entry",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "feed_entry");

            migrationBuilder.DropColumn(
                name: "title",
                table: "feed_entry");
        }
    }
}
