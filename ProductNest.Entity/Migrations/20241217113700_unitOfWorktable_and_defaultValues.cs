using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductNest.Entity.Migrations
{
    /// <inheritdoc />
    public partial class unitOfWorktable_and_defaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitOfMeasures",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasures", x => x.Code);
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasures",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { "ac", "Acre" },
                    { "AI", "Assembled Item" },
                    { "cl", "Centiliter" },
                    { "cm", "Centimeter" },
                    { "cm3", "Cubic Centimeter" },
                    { "dcl", "Decaliter" },
                    { "dcm", "Decameter" },
                    { "dl", "Deciliter" },
                    { "dm", "Decimeter" },
                    { "each", "Each" },
                    { "floz", "Fluid Ounce" },
                    { "ft", "Foot" },
                    { "g", "Gram" },
                    { "glim", "Gallon (Imperial)" },
                    { "gll", "Gallon (Metric)" },
                    { "ha", "Hectare" },
                    { "hcl", "Hectoliter" },
                    { "hcm", "Hectometer" },
                    { "in", "Inch" },
                    { "kg", "Kilogram" },
                    { "kg/m3", "Kilogram Per Cubic Meter" },
                    { "kl", "Kiloliter" },
                    { "km", "Kilometer" },
                    { "km2", "Square Kilometer" },
                    { "L", "Liter" },
                    { "lb", "Pound" },
                    { "lot", "Lot" },
                    { "m", "Meter" },
                    { "m2", "Square Meter" },
                    { "m3", "Cubic Meter" },
                    { "mcg", "Microgram" },
                    { "mg", "Milligram" },
                    { "ml", "Milliliter" },
                    { "mm", "Millimeter" },
                    { "mt", "Metric-Ton" },
                    { "Other", "Other" },
                    { "oz", "Ounce" },
                    { "pair", "Pair" },
                    { "piece", "Piece" },
                    { "pt", "Pint" },
                    { "SI", "Single Item" },
                    { "sin", "Square Inch" },
                    { "SU", "Single Unit" },
                    { "t", "Ton" },
                    { "yard", "Yard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitOfMeasures");
        }
    }
}
