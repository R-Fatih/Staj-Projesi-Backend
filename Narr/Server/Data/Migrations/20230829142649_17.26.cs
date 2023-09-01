using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Narevim.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1726 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rank = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<int>(type: "int", nullable: true),
                    createdat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    increase_desi = table.Column<int>(type: "int", nullable: true),
                    rank = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<int>(type: "int", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}
