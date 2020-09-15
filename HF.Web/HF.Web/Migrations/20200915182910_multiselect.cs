using Microsoft.EntityFrameworkCore.Migrations;

namespace HF.Web.Migrations
{
    public partial class multiselect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Category_CategoryId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_CategoryId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Transaction");

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "Category",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_TransactionId",
                table: "Category",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Transaction_TransactionId",
                table: "Category",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Transaction_TransactionId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_TransactionId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Category");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CategoryId",
                table: "Transaction",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Category_CategoryId",
                table: "Transaction",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
