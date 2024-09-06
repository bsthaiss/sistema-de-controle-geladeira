using Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class GeladeiraService
    {
        private readonly GeladeiraDbContext _contexto;

        public GeladeiraService(GeladeiraDbContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<ItensGeladeira> ListarTodosItens()
        {
            return _contexto.ItensGeladeiras.ToList();
        }

        public ItensGeladeira? BuscarItem(int id)
        {
            return _contexto.ItensGeladeiras.Find(id);
        }

        public void AdicionarItem(ItensGeladeira item)
        {
            _contexto.ItensGeladeiras.Add(item);
            _contexto.SaveChanges();
        }

        public void AtualizarItem(ItensGeladeira itemAtualizado)
        {
            var itemExistente = _contexto.ItensGeladeiras.Find(itemAtualizado.Id);

            if (itemExistente != null)
            {
                itemExistente.Nome = itemAtualizado.Nome;
                itemExistente.Andar = itemAtualizado.Andar;
                itemExistente.Container = itemAtualizado.Container;
                itemExistente.Posicao = itemAtualizado.Posicao;
                _contexto.SaveChanges();
            }
        }

        public void RemoverItem(int id)
        {
            var item = _contexto.ItensGeladeiras.Find(id);
            if (item != null)
            {
                _contexto.ItensGeladeiras.Remove(item);
                _contexto.SaveChanges();
            }
        }
    }
}