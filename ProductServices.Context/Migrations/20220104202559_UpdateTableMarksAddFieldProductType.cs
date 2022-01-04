using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductServices.Context.Migrations
{
    public partial class UpdateTableMarksAddFieldProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marksColor_colors_IdColor",
                table: "marksColor");

            migrationBuilder.DropForeignKey(
                name: "FK_marksColor_models_IdModel",
                table: "marksColor");

            migrationBuilder.DropForeignKey(
                name: "FK_marksColor_products_ProductsId",
                table: "marksColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_marksColor",
                table: "marksColor");

            migrationBuilder.RenameTable(
                name: "marksColor",
                newName: "ModelColorPrice");

            migrationBuilder.RenameIndex(
                name: "IX_marksColor_ProductsId",
                table: "ModelColorPrice",
                newName: "IX_ModelColorPrice_ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_marksColor_IdModel",
                table: "ModelColorPrice",
                newName: "IX_ModelColorPrice_IdModel");

            migrationBuilder.RenameIndex(
                name: "IX_marksColor_IdColor",
                table: "ModelColorPrice",
                newName: "IX_ModelColorPrice_IdColor");

            migrationBuilder.AddColumn<int>(
                name: "IdProductType",
                table: "marks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelColorPrice",
                table: "ModelColorPrice",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_marks_IdProductType",
                table: "marks",
                column: "IdProductType");

            migrationBuilder.AddForeignKey(
                name: "FK_marks_productTypes_IdProductType",
                table: "marks",
                column: "IdProductType",
                principalTable: "productTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelColorPrice_colors_IdColor",
                table: "ModelColorPrice",
                column: "IdColor",
                principalTable: "colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelColorPrice_models_IdModel",
                table: "ModelColorPrice",
                column: "IdModel",
                principalTable: "models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelColorPrice_products_ProductsId",
                table: "ModelColorPrice",
                column: "ProductsId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marks_productTypes_IdProductType",
                table: "marks");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelColorPrice_colors_IdColor",
                table: "ModelColorPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelColorPrice_models_IdModel",
                table: "ModelColorPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelColorPrice_products_ProductsId",
                table: "ModelColorPrice");

            migrationBuilder.DropIndex(
                name: "IX_marks_IdProductType",
                table: "marks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelColorPrice",
                table: "ModelColorPrice");

            migrationBuilder.DropColumn(
                name: "IdProductType",
                table: "marks");

            migrationBuilder.RenameTable(
                name: "ModelColorPrice",
                newName: "marksColor");

            migrationBuilder.RenameIndex(
                name: "IX_ModelColorPrice_ProductsId",
                table: "marksColor",
                newName: "IX_marksColor_ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ModelColorPrice_IdModel",
                table: "marksColor",
                newName: "IX_marksColor_IdModel");

            migrationBuilder.RenameIndex(
                name: "IX_ModelColorPrice_IdColor",
                table: "marksColor",
                newName: "IX_marksColor_IdColor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_marksColor",
                table: "marksColor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_marksColor_colors_IdColor",
                table: "marksColor",
                column: "IdColor",
                principalTable: "colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_marksColor_models_IdModel",
                table: "marksColor",
                column: "IdModel",
                principalTable: "models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_marksColor_products_ProductsId",
                table: "marksColor",
                column: "ProductsId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
