using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductServices.Context.Migrations
{
    public partial class UpdateTableModelColorPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marksColor_marks_IdMarks",
                table: "marksColor");

            migrationBuilder.RenameColumn(
                name: "IdMarks",
                table: "marksColor",
                newName: "IdModel");

            migrationBuilder.RenameIndex(
                name: "IX_marksColor_IdMarks",
                table: "marksColor",
                newName: "IX_marksColor_IdModel");

            migrationBuilder.AddForeignKey(
                name: "FK_marksColor_models_IdModel",
                table: "marksColor",
                column: "IdModel",
                principalTable: "models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marksColor_models_IdModel",
                table: "marksColor");

            migrationBuilder.RenameColumn(
                name: "IdModel",
                table: "marksColor",
                newName: "IdMarks");

            migrationBuilder.RenameIndex(
                name: "IX_marksColor_IdModel",
                table: "marksColor",
                newName: "IX_marksColor_IdMarks");

            migrationBuilder.AddForeignKey(
                name: "FK_marksColor_marks_IdMarks",
                table: "marksColor",
                column: "IdMarks",
                principalTable: "marks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
