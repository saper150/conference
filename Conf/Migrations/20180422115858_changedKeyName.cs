using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Conf.Migrations
{
    public partial class changedKeyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceUsers_Cities_Cities",
                table: "ConferenceUsers");

            migrationBuilder.RenameColumn(
                name: "Cities",
                table: "ConferenceUsers",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_ConferenceUsers_Cities",
                table: "ConferenceUsers",
                newName: "IX_ConferenceUsers_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceUsers_Cities_CityId",
                table: "ConferenceUsers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceUsers_Cities_CityId",
                table: "ConferenceUsers");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "ConferenceUsers",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_ConferenceUsers_CityId",
                table: "ConferenceUsers",
                newName: "IX_ConferenceUsers_Cities");

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceUsers_Cities_Cities",
                table: "ConferenceUsers",
                column: "Cities",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
