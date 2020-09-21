using Microsoft.EntityFrameworkCore.Migrations;

namespace HF.Web.Migrations
{
    public partial class many2many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TransactionCategory",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCategory", x => new { x.TransactionId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_TransactionCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionCategory_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCategory_CategoryId",
                table: "TransactionCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionCategory");

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "Category",
                type: "int",
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
    }
}
