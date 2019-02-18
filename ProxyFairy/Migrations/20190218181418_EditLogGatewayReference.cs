using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProxyFairy.Migrations
{
    public partial class EditLogGatewayReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MobAppId",
                table: "LogsGateway",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogsGateway_MobAppId",
                table: "LogsGateway",
                column: "MobAppId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogsGateway_MobApps_MobAppId",
                table: "LogsGateway",
                column: "MobAppId",
                principalTable: "MobApps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogsGateway_MobApps_MobAppId",
                table: "LogsGateway");

            migrationBuilder.DropIndex(
                name: "IX_LogsGateway_MobAppId",
                table: "LogsGateway");

            migrationBuilder.DropColumn(
                name: "MobAppId",
                table: "LogsGateway");
        }
    }
}
