using Moq;
using Xunit;
using Repository.Interfaces;
using Repository.Models;
using Services;
using System.Collections.Generic;

namespace GeladeiraTeste.ServicesTests
{
    public class GeladeiraServiceTests
    {
        private readonly Mock<IRepository<ItensGeladeira>> _mockRepository;
        private readonly GeladeiraService _service;

        public GeladeiraServiceTests()
        {
            _mockRepository = new Mock<IRepository<ItensGeladeira>>();
            _service = new GeladeiraService(_mockRepository.Object);
        }

        [Fact]
        public void ListarTodos_DeveRetornarTodosOsItens()
        {
            var itens = new List<ItensGeladeira>
        {
            new ItensGeladeira { Id = 1, Nome = "Amora" },
            new ItensGeladeira { Id = 2, Nome = "Uva" }
        };
            _mockRepository.Setup(repo => repo.ListarTodos()).Returns(itens);

            var resultado = _service.ListarTodos();

            Assert.Equal(2, resultado.Count);
        }

        [Fact]
        public void Buscar_DeveRetornarItemExistente()
        {

            var item = new ItensGeladeira { Id = 1, Nome = "Amora" };
            _mockRepository.Setup(repo => repo.Buscar(1)).Returns(item);

            var resultado = _service.Buscar(1);

            Assert.Equal(item, resultado);
        }

        [Fact]
        public void Buscar_DeveRetornarNullParaItemInexistente()
        {
            _mockRepository.Setup(repo => repo.Buscar(1)).Returns((ItensGeladeira)null);

            var resultado = _service.Buscar(1);

            Assert.Null(resultado);
        }

        [Fact]
        public void Adicionar_DeveChamarAdicionarDoRepository()
        {
            var item = new ItensGeladeira { Id = 1, Nome = "Amora" };

            _service.Adicionar(item);

            _mockRepository.Verify(repo => repo.Adicionar(item), Times.Once);
        }

        [Fact]
        public void Atualizar_DeveChamarAtualizarDoRepository()
        {
            var item = new ItensGeladeira { Id = 1, Nome = "Amora" };

            _service.Atualizar(item);

            _mockRepository.Verify(repo => repo.Atualizar(item), Times.Once);
        }

        [Fact]
        public void Remover_DeveChamarRemoverDoRepository()
        {
            int id = 1;

            _service.Remover(id);

            _mockRepository.Verify(repo => repo.Remover(id), Times.Once);
        }
    }
}