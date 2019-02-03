using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProxyFairy.Migrations
{
    public partial class UpdateClients_removeAdditionalId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_ProductOwnerId1",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ProductOwnerId1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ProductOwnerId1",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "ProductOwnerId",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ProductOwnerId",
                table: "Customers",
                column: "ProductOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_ProductOwnerId",
                table: "Customers",
                column: "ProductOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_ProductOwnerId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ProductOwnerId",
                table: "Customers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductOwnerId",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductOwnerId1",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ProductOwnerId1",
                table: "Customers",
                column: "ProductOwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_ProductOwnerId1",
                table: "Customers",
                column: "ProductOwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
