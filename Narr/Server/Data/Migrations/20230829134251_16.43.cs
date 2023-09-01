using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Narevim.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1643 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_Product_id",
                table: "OrderProduct",
                column: "Product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Product_Product_id",
                table: "OrderProduct",
                column: "Product_id",
                principalTable: "Product",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Product_Product_id",
                table: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_Product_id",
                table: "OrderProduct");

           
        }
    }
}
