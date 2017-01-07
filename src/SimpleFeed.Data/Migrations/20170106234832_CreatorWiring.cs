using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFeed.Data.Migrations
{
    public partial class CreatorWiring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_feed_entry_vote_creator_id",
                table: "feed_entry_vote",
                column: "creator_id");

            migrationBuilder.CreateIndex(
                name: "IX_feed_entry_comment_creator_id",
                table: "feed_entry_comment",
                column: "creator_id");

            migrationBuilder.CreateIndex(
                name: "IX_feed_entry_comment_vote_creator_id",
                table: "feed_entry_comment_vote",
                column: "creator_id");

            migrationBuilder.CreateIndex(
                name: "IX_feed_entry_creator_id",
                table: "feed_entry",
                column: "creator_id");

            migrationBuilder.AddForeignKey(
                name: "FK_feed_entry_AspNetUsers_creator_id",
                table: "feed_entry",
                column: "creator_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_feed_entry_comment_vote_AspNetUsers_creator_id",
                table: "feed_entry_comment_vote",
                column: "creator_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_feed_entry_comment_AspNetUsers_creator_id",
                table: "feed_entry_comment",
                column: "creator_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_feed_entry_vote_AspNetUsers_creator_id",
                table: "feed_entry_vote",
                column: "creator_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feed_entry_AspNetUsers_creator_id",
                table: "feed_entry");

            migrationBuilder.DropForeignKey(
                name: "FK_feed_entry_comment_vote_AspNetUsers_creator_id",
                table: "feed_entry_comment_vote");

            migrationBuilder.DropForeignKey(
                name: "FK_feed_entry_comment_AspNetUsers_creator_id",
                table: "feed_entry_comment");

            migrationBuilder.DropForeignKey(
                name: "FK_feed_entry_vote_AspNetUsers_creator_id",
                table: "feed_entry_vote");

            migrationBuilder.DropIndex(
                name: "IX_feed_entry_vote_creator_id",
                table: "feed_entry_vote");

            migrationBuilder.DropIndex(
                name: "IX_feed_entry_comment_creator_id",
                table: "feed_entry_comment");

            migrationBuilder.DropIndex(
                name: "IX_feed_entry_comment_vote_creator_id",
                table: "feed_entry_comment_vote");

            migrationBuilder.DropIndex(
                name: "IX_feed_entry_creator_id",
                table: "feed_entry");
        }
    }
}
