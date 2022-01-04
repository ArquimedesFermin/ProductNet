using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductServices.Context.Migrations
{
    public partial class renameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_Color_IdColor",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_products_IdProduct",
                table: "ProductColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductColor",
                table: "ProductColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.RenameTable(
                name: "ProductColor",
                newName: "productsColor");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "colors");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColor_IdProduct",
                table: "productsColor",
                newName: "IX_productsColor_IdProduct");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColor_IdColor",
                table: "productsColor",
                newName: "IX_productsColor_IdColor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productsColor",
                table: "productsColor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_colors",
                table: "colors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_productsColor_colors_IdColor",
                table: "productsColor",
                column: "IdColor",
                principalTable: "colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productsColor_products_IdProduct",
                table: "productsColor",
                column: "IdProduct",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productsColor_colors_IdColor",
                table: "productsColor");

            migrationBuilder.DropForeignKey(
                name: "FK_productsColor_products_IdProduct",
                table: "productsColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productsColor",
                table: "productsColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_colors",
                table: "colors");

            migrationBuilder.RenameTable(
                name: "productsColor",
                newName: "ProductColor");

            migrationBuilder.RenameTable(
                name: "colors",
                newName: "Color");

            migrationBuilder.RenameIndex(
                name: "IX_productsColor_IdProduct",
                table: "ProductColor",
                newName: "IX_ProductColor_IdProduct");

            migrationBuilder.RenameIndex(
                name: "IX_productsColor_IdColor",
                table: "ProductColor",
                newName: "IX_ProductColor_IdColor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductColor",
                table: "ProductColor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_Color_IdColor",
                table: "ProductColor",
                column: "IdColor",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_products_IdProduct",
                table: "ProductColor",
                column: "IdProduct",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
