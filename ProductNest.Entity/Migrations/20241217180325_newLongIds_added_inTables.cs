using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductNest.Entity.Migrations
{
    /// <inheritdoc />
    public partial class newLongIds_added_inTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "WarehouseId",
                table: "Warehouse",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VariantOptionId",
                table: "VariantOption",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VariantId",
                table: "Variant",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PriceId",
                table: "Price",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PredentPriceId",
                table: "PresentmentPrice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "InventoryId",
                table: "Inventory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ImpactedComponentId",
                table: "ImpactedComponent",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ImageFileId",
                table: "ImageFile",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CompletePartId",
                table: "CompletedPart",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BomItemId",
                table: "BOMItem",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BatchId",
                table: "Batch",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "VariantOptionId",
                table: "VariantOption");

            migrationBuilder.DropColumn(
                name: "VariantId",
                table: "Variant");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "PredentPriceId",
                table: "PresentmentPrice");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ImpactedComponentId",
                table: "ImpactedComponent");

            migrationBuilder.DropColumn(
                name: "ImageFileId",
                table: "ImageFile");

            migrationBuilder.DropColumn(
                name: "CompletePartId",
                table: "CompletedPart");

            migrationBuilder.DropColumn(
                name: "BomItemId",
                table: "BOMItem");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Batch");
        }
    }
}
