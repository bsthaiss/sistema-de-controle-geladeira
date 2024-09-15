﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstruturaGeladeira;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> ListarTodos();

        TEntity? Buscar(int id);

        void Adicionar(TEntity entity);

        void Atualizar(TEntity entity);

        void Remover(int id);
    }
}
