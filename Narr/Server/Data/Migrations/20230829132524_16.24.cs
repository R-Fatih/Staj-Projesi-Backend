using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Narevim.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1624 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "order_detail",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "order_detail",
                table: "Order");

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
    }
}
