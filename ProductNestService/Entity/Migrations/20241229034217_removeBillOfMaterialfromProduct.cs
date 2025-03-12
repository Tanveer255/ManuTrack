using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductNestService.Entity.Migrations
{
    /// <inheritdoc />
    public partial class removeBillOfMaterialfromProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOMItem_Product_ProductId1",
                table: "BOMItem");

            migrationBuilder.DropIndex(
                name: "IX_BOMItem_ProductId1",
                table: "BOMItem");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "BOMItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "BOMItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BOMItem_ProductId1",
                table: "BOMItem",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BOMItem_Product_ProductId1",
                table: "BOMItem",
                column: "ProductId1",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
