using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Narevim.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1632 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order_id",
                table: "OrderProduct");

            migrationBuilder.AddColumn<string>(
                name: "order_number",
                table: "OrderProduct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order_number",
                table: "OrderProduct");

            migrationBuilder.AddColumn<int>(
                name: "order_id",
                table: "OrderProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
