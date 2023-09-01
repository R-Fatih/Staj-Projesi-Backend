using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Narevim.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class new2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_url = table.Column<int>(type: "int", nullable: true),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    product_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    product_keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prodcut_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    discount_price = table.Column<int>(type: "int", nullable: true),
                    money_unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    design_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brand_id = table.Column<int>(type: "int", nullable: true),
                    first_group_id = table.Column<int>(type: "int", nullable: true),
                    second_group_id = table.Column<int>(type: "int", nullable: true),
                    third_group_id = table.Column<int>(type: "int", nullable: true),
                    desi = table.Column<int>(type: "int", nullable: true),
                    video_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank = table.Column<int>(type: "int", nullable: true),
                    homeRank = table.Column<int>(type: "int", nullable: true),
                    stock = table.Column<int>(type: "int", nullable: true),
                    isColor = table.Column<int>(type: "int", nullable: true),
                    isSize = table.Column<int>(type: "int", nullable: true),
                    isDiscount = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<int>(type: "int", nullable: true),
                    isNew = table.Column<int>(type: "int", nullable: true),
                    isHome = table.Column<int>(type: "int", nullable: true),
                    isOpportunity = table.Column<int>(type: "int", nullable: true),
                    isFreeCargo = table.Column<int>(type: "int", nullable: true),
                    isBanner = table.Column<int>(type: "int", nullable: true),
                    isWeekStar = table.Column<int>(type: "int", nullable: true),
                    isMostSeller = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    campaign_rank = table.Column<int>(type: "int", nullable: true),
                    img_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    point = table.Column<int>(type: "int", nullable: true),
                    review = table.Column<int>(type: "int", nullable: true),
                    discountRatio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title_size = table.Column<int>(type: "int", nullable: true),
                    description_size = table.Column<int>(type: "int", nullable: true),
                    img_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    allowButton = table.Column<int>(type: "int", nullable: true),
                    button_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    button_caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    block_side = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    animation_time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Slider");
        }
    }
}
