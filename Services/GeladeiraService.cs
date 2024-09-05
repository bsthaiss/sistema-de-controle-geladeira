using Microsoft.Data.SqlClient;
using Repository.Models;
using System;
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

        public string AdicionarItem(ItensGeladeira item)
        {
            if (item == null)
            {
                return "Item inválido!";
            }

            try
            {
                var itemExistente = _contexto.ItensGeladeiras
                    .FirstOrDefault(i => i.Andar == item.Andar && i.Container == item.Container && i.Posicao == item.Posicao);

                if (itemExistente == null)
                {
                    _contexto.ItensGeladeiras.Add(item);
                    _contexto.SaveChanges();
                    return "Item adicionado com sucesso!";
                }
                else
                {
                    return "Posição já ocupada!";
                }
            }
            catch (SqlException)
            {
                return "Erro ao se comunicar com o banco de dados!";
            }
            catch (Exception ex)
            {
                return $"Erro: {ex.Message}";
            }
        }

        public string AtualizarItem(ItensGeladeira item)
        {
            if (item == null)
            {
                return "Item inválido!";
            }

            try
            {
                var itemExistente = _contexto.ItensGeladeiras
                    .FirstOrDefault(i => i.Andar == item.Andar && i.Container == item.Container && i.Posicao == item.Posicao);

                if (itemExistente != null)
                {
                    itemExistente.Nome = item.Nome;
                    _contexto.ItensGeladeiras.Update(itemExistente);
                    _contexto.SaveChanges();
                    return "Item atualizado com sucesso!";
                }
                else
                {
                    return "Item não encontrado!";
                }
            }
            catch (SqlException)
            {
                return "Erro ao se comunicar com o banco de dados!";
            }
            catch (Exception ex)
            {
                return $"Erro: {ex.Message}";
            }
        }

        public ItensGeladeira BuscarItem(int idItem)
        {
            try
            {
                return _contexto.ItensGeladeiras.Find(idItem);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ItensGeladeira> ListarTodosItens()
        {
            try
            {
                return _contexto.ItensGeladeiras.ToList();
            }
            catch (Exception)
            {
                return new List<ItensGeladeira>();
            }
        }

        public string RemoverItemPorId(int idItem)
        {
            if (idItem <= 0)
            {
                return "ID inválido! Tente novamente.";
            }

            try
            {
                var item = BuscarItem(idItem);

                if (item != null)
                {
                    _contexto.ItensGeladeiras.Remove(item);
                    _contexto.SaveChanges();
                    return $"Item '{item.Nome}' removido com sucesso!";
                }
                else
                {
                    return "Item não encontrado!";
                }
            }
            catch (SqlException)
            {
                return "Erro ao se comunicar com o banco de dados!";
            }
            catch (Exception ex)
            {
                return $"Erro: {ex.Message}";
            }
        }
    }
}