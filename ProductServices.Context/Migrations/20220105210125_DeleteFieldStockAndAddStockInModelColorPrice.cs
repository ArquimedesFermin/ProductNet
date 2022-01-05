using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductServices.Context.Migrations
{
    public partial class DeleteFieldStockAndAddStockInModelColorPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateManufacture",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "modelColorPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "modelColorPrice");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateManufacture",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
