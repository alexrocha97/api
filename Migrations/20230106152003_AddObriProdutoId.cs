using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddObriProdutoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_tblProdutos_ProdutosId",
                table: "Tag");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutosId",
                table: "Tag",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_tblProdutos_ProdutosId",
                table: "Tag",
                column: "ProdutosId",
                principalTable: "tblProdutos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_tblProdutos_ProdutosId",
                table: "Tag");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutosId",
                table: "Tag",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_tblProdutos_ProdutosId",
                table: "Tag",
                column: "ProdutosId",
                principalTable: "tblProdutos",
                principalColumn: "Id");
        }
    }
}
