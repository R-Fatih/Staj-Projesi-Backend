using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Narevim.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    facebook_pixel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    free_pay_limit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    banner_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    home_banner_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<int>(type: "int", nullable: false),
                    isNext = table.Column<bool>(type: "bit", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    first_group_id = table.Column<int>(type: "int", nullable: true),
                    second_group_id = table.Column<int>(type: "int", nullable: true),
                    third_group_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
