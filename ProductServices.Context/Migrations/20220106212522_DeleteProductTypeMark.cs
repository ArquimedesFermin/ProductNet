using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductServices.Context.Migrations
{
    public partial class DeleteProductTypeMark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marks_productTypes_IdProductType",
                table: "marks");

            migrationBuilder.DropIndex(
                name: "IX_marks_IdProductType",
                table: "marks");

            migrationBuilder.DropColumn(
                name: "IdProductType",
                table: "marks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProductType",
                table: "marks",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
