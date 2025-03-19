using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcessFlowService.Migrations
{
    /// <inheritdoc />
    public partial class TenentIdadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "User");
        }
    }
}
