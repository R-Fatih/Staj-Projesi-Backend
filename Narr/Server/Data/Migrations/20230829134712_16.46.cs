﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Narevim.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1646 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

           

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Productid",
                table: "OrderProduct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_Productid",
                table: "OrderProduct",
                column: "Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Product_Productid",
                table: "OrderProduct",
                column: "Productid",
                principalTable: "Product",
                principalColumn: "id");
        }
    }
}
