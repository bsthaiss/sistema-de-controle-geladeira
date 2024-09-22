using System.Collections.Generic;
using Xunit;
using EstruturaGeladeira;

namespace GeladeiraTeste.EstruturaGeladeiraTests
{
    public class GeladeiraTests
    {
        [Fact]
        public void CriarGeladeira_DeveCriarAndaresCorretamente()
        {
            int numeroAndares = 3;
            int numeroContainers = 2;
            int numeroPosicoes = 4;

            Geladeira geladeira = new Geladeira(numeroAndares, numeroContainers, numeroPosicoes);

            Assert.Equal(numeroAndares, geladeira.Andares.Count);
            Assert.All(geladeira.Andares, andar => Assert.Equal(numeroContainers, andar.Containers.Count));
        }
    }
}