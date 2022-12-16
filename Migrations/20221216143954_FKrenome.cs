using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudProduto.Migrations
{
    /// <inheritdoc />
    public partial class FKrenome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_Pedidos_PedidoFKId",
                table: "ItensPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_Produtos_ProdutoFKId",
                table: "ItensPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedidos_PedidoFKId",
                table: "ItensPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedidos_ProdutoFKId",
                table: "ItensPedidos");

            migrationBuilder.DropColumn(
                name: "PedidoFKId",
                table: "ItensPedidos");

            migrationBuilder.DropColumn(
                name: "ProdutoFKId",
                table: "ItensPedidos");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_IdPedido",
                table: "ItensPedidos",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_IdProduto",
                table: "ItensPedidos",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_Pedidos_IdPedido",
                table: "ItensPedidos",
                column: "IdPedido",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_Produtos_IdProduto",
                table: "ItensPedidos",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_Pedidos_IdPedido",
                table: "ItensPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_Produtos_IdProduto",
                table: "ItensPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedidos_IdPedido",
                table: "ItensPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedidos_IdProduto",
                table: "ItensPedidos");

            migrationBuilder.AddColumn<int>(
                name: "PedidoFKId",
                table: "ItensPedidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoFKId",
                table: "ItensPedidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoFKId",
                table: "ItensPedidos",
                column: "PedidoFKId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_ProdutoFKId",
                table: "ItensPedidos",
                column: "ProdutoFKId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_Pedidos_PedidoFKId",
                table: "ItensPedidos",
                column: "PedidoFKId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_Produtos_ProdutoFKId",
                table: "ItensPedidos",
                column: "ProdutoFKId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }
    }
}
