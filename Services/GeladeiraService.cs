using Repository.Context;
using Repository.Interfaces;
using Repository.Models;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class GeladeiraService : IService<ItensGeladeira>
    {
        private readonly IRepository<ItensGeladeira> _repository;

        public GeladeiraService(IRepository<ItensGeladeira> repository)
        {
            _repository = repository;
        }

        public List<ItensGeladeira> ListarTodos()
        {
            return _repository.ListarTodos();
        }

        public ItensGeladeira? Buscar(int id)
        {
            return _repository.Buscar(id);
        }

        public void Adicionar(ItensGeladeira entity)
        {
            _repository.Adicionar(entity);
        }

        public void Atualizar(ItensGeladeira entity)
        {
            _repository.Atualizar(entity);
        }

        public void Remover(int id)
        {
            _repository.Remover(id);
        }
    }
}