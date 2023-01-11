using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProdutos_Categoria_CategoriaId",
                table: "tblProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "tblCategoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblCategoria",
                table: "tblCategoria",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdutosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_tblProdutos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "tblProdutos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ProdutosId",
                table: "Tag",
                column: "ProdutosId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProdutos_tblCategoria_CategoriaId",
                table: "tblProdutos",
                column: "CategoriaId",
                principalTable: "tblCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProdutos_tblCategoria_CategoriaId",
                table: "tblProdutos");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblCategoria",
                table: "tblCategoria");

            migrationBuilder.RenameTable(
                name: "tblCategoria",
                newName: "Categoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProdutos_Categoria_CategoriaId",
                table: "tblProdutos",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
