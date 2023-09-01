using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Narevim.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1536 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clear_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city_id = table.Column<int>(type: "int", nullable: true),
                    town_id = table.Column<int>(type: "int", nullable: true),
                    billing_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    billing_surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    billing_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    billing_telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    billing_clear_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    billing_city_id = table.Column<int>(type: "int", nullable: true),
                    billing_town_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityid = table.Column<int>(type: "int", nullable: true),
                    townid = table.Column<int>(type: "int", nullable: true),
                    billing_cityid = table.Column<int>(type: "int", nullable: true),
                    billing_townid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                    table.ForeignKey(
                        name: "FK_Address_City_billing_cityid",
                        column: x => x.billing_cityid,
                        principalTable: "City",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Address_City_cityid",
                        column: x => x.cityid,
                        principalTable: "City",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Address_Town_billing_townid",
                        column: x => x.billing_townid,
                        principalTable: "Town",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Address_Town_townid",
                        column: x => x.townid,
                        principalTable: "Town",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Favoritte",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritte", x => x.id);
                    table.ForeignKey(
                        name: "FK_Favoritte_Product_Productid",
                        column: x => x.Productid,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    member_adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order_state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_id = table.Column<int>(type: "int", nullable: false),
                    cargo_id = table.Column<int>(type: "int", nullable: false),
                    order_note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_billing_cityid",
                table: "Address",
                column: "billing_cityid");

            migrationBuilder.CreateIndex(
                name: "IX_Address_billing_townid",
                table: "Address",
                column: "billing_townid");

            migrationBuilder.CreateIndex(
                name: "IX_Address_cityid",
                table: "Address",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "IX_Address_townid",
                table: "Address",
                column: "townid");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritte_Productid",
                table: "Favoritte",
                column: "Productid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Favoritte");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
