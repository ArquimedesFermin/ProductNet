using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductServices.Context.Migrations
{
    public partial class UpdateTableMarksModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marks_models_IdModel",
                table: "marks");

            migrationBuilder.DropForeignKey(
                name: "FK_products_marks_IdMark",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_ProductTypes_IdProductType",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_marks_IdModel",
                table: "marks");

            migrationBuilder.DropColumn(
                name: "IdModel",
                table: "marks");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "productTypes");

            migrationBuilder.RenameColumn(
                name: "IdMark",
                table: "products",
                newName: "IdModel");

            migrationBuilder.RenameIndex(
                name: "IX_products_IdMark",
                table: "products",
                newName: "IX_products_IdModel");

            migrationBuilder.AddColumn<int>(
                name: "IdMark",
                table: "models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_productTypes",
                table: "productTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_models_IdMark",
                table: "models",
                column: "IdMark");

            migrationBuilder.AddForeignKey(
                name: "FK_models_marks_IdMark",
                table: "models",
                column: "IdMark",
                principalTable: "marks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_models_IdModel",
                table: "products",
                column: "IdModel",
                principalTable: "models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_productTypes_IdProductType",
                table: "products",
                column: "IdProductType",
                principalTable: "productTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_models_marks_IdMark",
                table: "models");

            migrationBuilder.DropForeignKey(
                name: "FK_products_models_IdModel",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productTypes_IdProductType",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productTypes",
                table: "productTypes");

            migrationBuilder.DropIndex(
                name: "IX_models_IdMark",
                table: "models");

            migrationBuilder.DropColumn(
                name: "IdMark",
                table: "models");

            migrationBuilder.RenameTable(
                name: "productTypes",
                newName: "ProductTypes");

            migrationBuilder.RenameColumn(
                name: "IdModel",
                table: "products",
                newName: "IdMark");

            migrationBuilder.RenameIndex(
                name: "IX_products_IdModel",
                table: "products",
                newName: "IX_products_IdMark");

            migrationBuilder.AddColumn<int>(
                name: "IdModel",
                table: "marks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_marks_IdModel",
                table: "marks",
                column: "IdModel");

            migrationBuilder.AddForeignKey(
                name: "FK_marks_models_IdModel",
                table: "marks",
                column: "IdModel",
                principalTable: "models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_marks_IdMark",
                table: "products",
                column: "IdMark",
                principalTable: "marks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_ProductTypes_IdProductType",
                table: "products",
                column: "IdProductType",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
