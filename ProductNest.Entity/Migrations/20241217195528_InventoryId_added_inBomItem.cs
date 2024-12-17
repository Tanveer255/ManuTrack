using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductNest.Entity.Migrations
{
    /// <inheritdoc />
    public partial class InventoryId_added_inBomItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BOMItem");

            migrationBuilder.AddColumn<long>(
                name: "InventoryId",
                table: "BOMItem",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "BOMItem");

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "BOMItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
