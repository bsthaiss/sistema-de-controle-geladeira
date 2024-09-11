using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Context;
using Repository.Interfaces;
using Repository.Models;
using Microsoft.Data.SqlClient;

namespace Repository.RepositoriesClasses
{
    public class ItensGeladeiraRepository : IRepository<ItensGeladeira>
    {
        GeladeiraDbContext _context;

        public ItensGeladeiraRepository(GeladeiraDbContext context)
        {
            _context = context;
        }
        public void Adicionar(ItensGeladeira entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Atualizar(ItensGeladeira entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public ItensGeladeira? Buscar(int id)
        {
            try
            {
                return _context.ItensGeladeiras.Find(id);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ItensGeladeira> ListarTodos()
        {
            try
            {
                return _context.ItensGeladeiras.ToList();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remover(int id)
        {
            var item = _context.ItensGeladeiras.Find(id);
            if (item != null)
            {
                _context.ItensGeladeiras.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}