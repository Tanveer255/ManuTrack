using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductNest.Entity.Migrations
{
    /// <inheritdoc />
    public partial class variants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "ProductBatch",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "ProductBatch",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "Product",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Product",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "ImpactedComponent",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "ImpactedComponent",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "CompletedPart",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "CompletedPart",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "BOMItem",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "BOMItem",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "AdminGraphqlApiId",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BodyHtml",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vendor",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ImageFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    AdminGraphqlApiId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VariantIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFile_Product_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Variant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentProductId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    InventoryPolicy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompareAtPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Taxable = table.Column<bool>(type: "bit", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FulfillmentService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grams = table.Column<int>(type: "int", nullable: false),
                    InventoryManagement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiresShipping = table.Column<bool>(type: "bit", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    WeightUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryItemId = table.Column<long>(type: "bigint", nullable: false),
                    InventoryQuantity = table.Column<int>(type: "int", nullable: false),
                    OldInventoryQuantity = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyHtml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminGraphqlApiId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variant_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VariantOption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Values = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariantOption_Product_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PresentmentPrice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompareAtPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VariantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentmentPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresentmentPrice_Price_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Price",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresentmentPrice_Variant_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageFile_ProductId1",
                table: "ImageFile",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_PresentmentPrice_PriceId",
                table: "PresentmentPrice",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentmentPrice_VariantId",
                table: "PresentmentPrice",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Variant_ProductId",
                table: "Variant",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_VariantOption_ProductId1",
                table: "VariantOption",
                column: "ProductId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageFile");

            migrationBuilder.DropTable(
                name: "PresentmentPrice");

            migrationBuilder.DropTable(
                name: "VariantOption");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "Variant");

            migrationBuilder.DropColumn(
                name: "AdminGraphqlApiId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BodyHtml",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Vendor",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ProductBatch",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ProductBatch",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Product",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Product",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ImpactedComponent",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ImpactedComponent",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "CompletedPart",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "CompletedPart",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "BOMItem",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BOMItem",
                newName: "CreatedTime");
        }
    }
}
