using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductServices.Context.Migrations
{
    public partial class createTableProductModelColorPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelColorPrice_colors_IdColor",
                table: "ModelColorPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelColorPrice_models_IdModel",
                table: "ModelColorPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelColorPrice_products_ProductsId",
                table: "ModelColorPrice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelColorPrice",
                table: "ModelColorPrice");

            migrationBuilder.DropIndex(
                name: "IX_ModelColorPrice_ProductsId",
                table: "ModelColorPrice");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "ModelColorPrice");

            migrationBuilder.RenameTable(
                name: "ModelColorPrice",
                newName: "modelColorPrice");

            migrationBuilder.RenameIndex(
                name: "IX_ModelColorPrice_IdModel",
                table: "modelColorPrice",
                newName: "IX_modelColorPrice_IdModel");

            migrationBuilder.RenameIndex(
                name: "IX_ModelColorPrice_IdColor",
                table: "modelColorPrice",
                newName: "IX_modelColorPrice_IdColor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_modelColorPrice",
                table: "modelColorPrice",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "productModelColorPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdModelColorPrice = table.Column<int>(type: "int", nullable: false),
                    IdProducts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productModelColorPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productModelColorPrice_modelColorPrice_IdModelColorPrice",
                        column: x => x.IdModelColorPrice,
                        principalTable: "modelColorPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productModelColorPrice_products_IdProducts",
                        column: x => x.IdProducts,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productModelColorPrice_IdModelColorPrice",
                table: "productModelColorPrice",
                column: "IdModelColorPrice");

            migrationBuilder.CreateIndex(
                name: "IX_productModelColorPrice_IdProducts",
                table: "productModelColorPrice",
                column: "IdProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_modelColorPrice_colors_IdColor",
                table: "modelColorPrice",
                column: "IdColor",
                principalTable: "colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_modelColorPrice_models_IdModel",
                table: "modelColorPrice",
                column: "IdModel",
                principalTable: "models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_modelColorPrice_colors_IdColor",
                table: "modelColorPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_modelColorPrice_models_IdModel",
                table: "modelColorPrice");

            migrationBuilder.DropTable(
                name: "productModelColorPrice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_modelColorPrice",
                table: "modelColorPrice");

            migrationBuilder.RenameTable(
                name: "modelColorPrice",
                newName: "ModelColorPrice");

            migrationBuilder.RenameIndex(
                name: "IX_modelColorPrice_IdModel",
                table: "ModelColorPrice",
                newName: "IX_ModelColorPrice_IdModel");

            migrationBuilder.RenameIndex(
                name: "IX_modelColorPrice_IdColor",
                table: "ModelColorPrice",
                newName: "IX_ModelColorPrice_IdColor");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "ModelColorPrice",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelColorPrice",
                table: "ModelColorPrice",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ModelColorPrice_ProductsId",
                table: "ModelColorPrice",
                column: "ProductsId");

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
    }
}
