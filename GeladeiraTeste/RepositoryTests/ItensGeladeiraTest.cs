using Repository.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.RepositoriesClasses;
using Xunit;

namespace GeladeiraTeste.TesteRepository
{
    public class ItensGeladeiraRepositoryTests
    {
        private GeladeiraDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<GeladeiraDbContext>()
                .UseInMemoryDatabase(databaseName: "GeladeiraTestDatabase" + Guid.NewGuid())
                .Options;

            return new GeladeiraDbContext(options);
        }


        private ItensGeladeiraRepository GetRepository()
        {
            var context = GetInMemoryDbContext();
            return new ItensGeladeiraRepository(context);
        }

        [Fact]
        public void ListarTodos_DeveRetornarTodosOsItens()
        {
            var repository = GetRepository();
            var item1 = new ItensGeladeira { Nome = "Amora", Andar = 1, Container = 1, Posicao = 1 };
            var item2 = new ItensGeladeira { Nome = "Uva", Andar = 1, Container = 1, Posicao = 2 };

            repository.Adicionar(item1);
            repository.Adicionar(item2);

            var resultado = repository.ListarTodos();

            Assert.Equal(2, resultado.Count);
            Assert.Contains(resultado, i => i.Nome == "Amora");
            Assert.Contains(resultado, i => i.Nome == "Uva");
        }

        [Fact]
        public void Adicionar_DeveAdicionarItem()
        {
            var repository = GetRepository();
            var item = new ItensGeladeira { Nome = "Amora" };

            repository.Adicionar(item);

            var itemSalvo = repository.Buscar(item.Id);
            Assert.NotNull(itemSalvo);
            Assert.Equal("Amora", itemSalvo.Nome);
        }

        [Fact]
        public void Remover_DeveRemoverItem()
        {
            var repository = GetRepository();
            var item = new ItensGeladeira { Nome = "Amora" };
            repository.Adicionar(item);

            repository.Remover(item.Id);

            var itemRemovido = repository.Buscar(item.Id);
            Assert.Null(itemRemovido);
        }

        [Fact]
        public void Buscar_DeveRetornarItemExistente()
        {
            var repository = GetRepository();
            var item = new ItensGeladeira { Nome = "Amora" };
            repository.Adicionar(item);

            var resultado = repository.Buscar(item.Id);

            Assert.NotNull(resultado);
            Assert.Equal("Amora", resultado.Nome);
        }
    }
}