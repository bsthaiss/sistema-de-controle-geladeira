using System.Collections.Generic;
using Xunit;
using EstruturaGeladeira;

namespace GeladeiraTeste.EstruturaGeladeiraTests
{
    public class AndarTests
    {
        [Fact]
        public void Andar_DeveCriarContainersCorretamente()
        {
            int numeroContainers = 2;
            int numeroPosicoes = 4;

            Andar andar = new Andar(numeroContainers, numeroPosicoes);

            Assert.Equal(numeroContainers, andar.Containers.Count);
            Assert.All(andar.Containers, container => Assert.Equal(numeroPosicoes, container.Itens.Count));
        }
    }
}