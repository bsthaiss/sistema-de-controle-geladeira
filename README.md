## Trilha de Formação C# - CodeRDIversity

Esse repositório tem o objetivo de armazenar o código do sistema de controle de itens de uma geladeira.

-------------------------------------------------------------------------------------------------------

Comandos utilizados no SQL Server e SSMS:

```
CREATE DATABASE GeladeiraDB;

CREATE TABLE ItensGeladeira (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome VARCHAR(100) NOT NULL,
    Andar INT NOT NULL,
    Container INT NOT NULL,
    Posicao INT NOT NULL
);
```

Comando feito no Scaffold:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=GeladeiraDB;Uid=sa;Pwd=123;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

-------------------------------------------------------------------------------------------------------

Antigo código `GeladeiraService.cs`:

```
﻿using Repository.Context;
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
```

Antigo código `GeladeiraController.cs`:
```
﻿using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Services;

/*
    Nome: Thais Barbosa dos Santos
 */

namespace GeladeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeladeiraController : ControllerBase
    {
        private readonly GeladeiraService _service;

        public GeladeiraController(GeladeiraService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItensGeladeira>> Get()
        {
            var itens = _service.ListarTodosItens();
            return Ok(itens);
        }

        [HttpGet("{id}")]
        public ActionResult<ItensGeladeira> Get(int id)
        {
            var item = _service.BuscarItem(id);

            if (item == null)
            {
                return NotFound("Item não encontrado");
            }

            return Ok(item);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ItensGeladeira item)
        {
            if (item == null)
            {
                return BadRequest("Erro!");
            }

            _service.AdicionarItem(item);
            return Ok("Item adicionado com sucesso");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ItensGeladeira item)
        {

            if (id != item.Id)
            {
                return BadRequest("Erro! Item inválido");
            }

            var itemExiste = _service.BuscarItem(id);

            if (itemExiste == null)
            {
                return NotFound();
            }

            _service.AtualizarItem(item);
            return Ok("Item atualizado com sucesso");


        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var itemExiste = _service.BuscarItem(id);

            if (itemExiste == null)
            {
                return NotFound();
            }

            _service.RemoverItem(id);
            return Ok("Item removido com sucesso");

        }

    }
}
```