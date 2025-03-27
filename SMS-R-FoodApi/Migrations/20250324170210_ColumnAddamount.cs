using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS_R_FoodApi.Migrations
{
    /// <inheritdoc />
    public partial class ColumnAddamount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemRate",
                table: "SaleParameter",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "ItemQuantity",
                table: "SaleParameter",
                newName: "Price");

            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "SaleParameter",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SaleParameter");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "SaleParameter",
                newName: "ItemRate");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "SaleParameter",
                newName: "ItemQuantity");
        }
    }
}
