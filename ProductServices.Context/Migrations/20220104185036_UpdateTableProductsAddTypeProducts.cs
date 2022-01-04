using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductServices.Context.Migrations
{
    public partial class UpdateTableProductsAddTypeProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productsColor");

            migrationBuilder.AddColumn<int>(
                name: "IdProductType",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "marksColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMarks = table.Column<int>(type: "int", nullable: false),
                    IdColor = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marksColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_marksColor_colors_IdColor",
                        column: x => x.IdColor,
                        principalTable: "colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_marksColor_marks_IdMarks",
                        column: x => x.IdMarks,
                        principalTable: "marks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_marksColor_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_IdProductType",
                table: "products",
                column: "IdProductType");

            migrationBuilder.CreateIndex(
                name: "IX_marksColor_IdColor",
                table: "marksColor",
                column: "IdColor");

            migrationBuilder.CreateIndex(
                name: "IX_marksColor_IdMarks",
                table: "marksColor",
                column: "IdMarks");

            migrationBuilder.CreateIndex(
                name: "IX_marksColor_ProductsId",
                table: "marksColor",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_ProductTypes_IdProductType",
                table: "products",
                column: "IdProductType",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_ProductTypes_IdProductType",
                table: "products");

            migrationBuilder.DropTable(
                name: "marksColor");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_products_IdProductType",
                table: "products");

            migrationBuilder.DropColumn(
                name: "IdProductType",
                table: "products");

            migrationBuilder.CreateTable(
                name: "productsColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdColor = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productsColor_colors_IdColor",
                        column: x => x.IdColor,
                        principalTable: "colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productsColor_products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productsColor_IdColor",
                table: "productsColor",
                column: "IdColor");

            migrationBuilder.CreateIndex(
                name: "IX_productsColor_IdProduct",
                table: "productsColor",
                column: "IdProduct");
        }
    }
}
