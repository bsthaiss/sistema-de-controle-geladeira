using System.Collections.Generic;
using Xunit;
using EstruturaGeladeira;

namespace GeladeiraTeste.EstruturaGeladeiraTests
{
    public class ContainerTests
    {
        [Fact]
        public void Container_DeveInicializarItensCorretamente()
        {
            int numeroPosicoes = 4;

            Container container = new Container(numeroPosicoes);

            Assert.Equal(numeroPosicoes, container.Itens.Count);
            Assert.All(container.Itens, item => Assert.Null(item));
        }
    }
}