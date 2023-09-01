using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Narevim.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1614 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Orderid",
                table: "Basket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Basket_Orderid",
                table: "Basket",
                column: "Orderid");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Order_Orderid",
                table: "Basket",
                column: "Orderid",
                principalTable: "Order",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Order_Orderid",
                table: "Basket");

            migrationBuilder.DropIndex(
                name: "IX_Basket_Orderid",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "Orderid",
                table: "Basket");
        }
    }
}
