using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductNest.Entity.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockLevel = table.Column<int>(type: "int", nullable: false),
                    ReorderLevel = table.Column<int>(type: "int", nullable: false),
                    LeadTimeInDays = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BOMItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOMItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductBatch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BOMVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalQuantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedStartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualStartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedFinishDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualFinishDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinishProductTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtyAvailable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtyReserved = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtyQuarantine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtyRejected = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtyExpired = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockTreatment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockImpact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsStarted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseBuildIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseBuildInSaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsWIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WIPStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackProgress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtyCompleted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseFinished = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseFinishedSaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseAisle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseShelf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseRack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseBay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCancelled = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForcancellation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReinstate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompleteQtyTreatment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancellationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgressStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionState = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectJNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBatch_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedPart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartCompleted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedPart_ProductBatch_BatchId",
                        column: x => x.BatchId,
                        principalTable: "ProductBatch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImpactedComponent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BOMItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aisle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shelf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickedAvlQty = table.Column<double>(type: "float", nullable: false),
                    PickedResQty = table.Column<double>(type: "float", nullable: false),
                    PickedQty = table.Column<double>(type: "float", nullable: false),
                    IsPicked = table.Column<bool>(type: "bit", nullable: false),
                    ImpactType = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpactedComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImpactedComponent_ProductBatch_BatchId",
                        column: x => x.BatchId,
                        principalTable: "ProductBatch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOMItem_ProductId",
                table: "BOMItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedPart_BatchId",
                table: "CompletedPart",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ImpactedComponent_BatchId",
                table: "ImpactedComponent",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBatch_ProductId",
                table: "ProductBatch",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOMItem");

            migrationBuilder.DropTable(
                name: "CompletedPart");

            migrationBuilder.DropTable(
                name: "ImpactedComponent");

            migrationBuilder.DropTable(
                name: "ProductBatch");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
