using System.Collections.Generic;
using Xunit;
using EstruturaGeladeira;

namespace GeladeiraTeste.EstruturaGeladeiraTests
{ 
    public class ItemTests
    {
        [Fact]
        public void Item_DeveAdicionarItemNaPosicaoCorreta()
        {
            var item = new Item("ItemTeste");
            var itens = new List<string>(new string[3]);
            string novoItem = "Banana";

            item.AdicionarItem(itens, 0, novoItem);

            Assert.Equal(novoItem, itens[0]);
        }

        [Fact]
        public void Item_DeveRemoverItemDaPosicaoCorreta()
        {
            var item = new Item("ItemTeste");
            var itens = new List<string> { "Banana", null, null };

            item.RemoverItem(itens, 0);

            Assert.Null(itens[0]);
        }

        [Fact]
        public void ListarItens_DeveListarItensCorretamente()
        {
            var item = new Item("ItemTeste");
            var itens = new List<string>
            {
                "Banana",
                null,
                null
            };

            var resultado = item.ListarItens(itens);

            Assert.Equal(3, resultado.Count);
            Assert.Equal("Posição 0: Banana", resultado[0]);
            Assert.Equal("Posição 1: vazio", resultado[1]);
            Assert.Equal("Posição 2: vazio", resultado[2]);

        }
    }
}