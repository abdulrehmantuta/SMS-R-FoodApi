using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS_R_FoodApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSaleParametersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleParameter_Sales_SaleId",
                table: "SaleParameter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleParameter",
                table: "SaleParameter");

            migrationBuilder.RenameTable(
                name: "SaleParameter",
                newName: "SaleParameters");

            migrationBuilder.RenameIndex(
                name: "IX_SaleParameter_SaleId",
                table: "SaleParameters",
                newName: "IX_SaleParameters_SaleId");

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "SaleParameters",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleParameters",
                table: "SaleParameters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleParameters_Sales_SaleId",
                table: "SaleParameters",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleParameters_Sales_SaleId",
                table: "SaleParameters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleParameters",
                table: "SaleParameters");

            migrationBuilder.RenameTable(
                name: "SaleParameters",
                newName: "SaleParameter");

            migrationBuilder.RenameIndex(
                name: "IX_SaleParameters_SaleId",
                table: "SaleParameter",
                newName: "IX_SaleParameter_SaleId");

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "SaleParameter",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleParameter",
                table: "SaleParameter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleParameter_Sales_SaleId",
                table: "SaleParameter",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id");
        }
    }
}
