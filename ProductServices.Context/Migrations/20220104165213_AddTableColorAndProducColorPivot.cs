using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductServices.Context.Migrations
{
    public partial class AddTableColorAndProducColorPivot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "products");

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HexColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    IdColor = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductColor_Color_IdColor",
                        column: x => x.IdColor,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductColor_products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_IdColor",
                table: "ProductColor",
                column: "IdColor");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_IdProduct",
                table: "ProductColor",
                column: "IdProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductColor");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
