using EstruturaGeladeira;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

/*
    Nome: Thais Barbosa dos Santos
 */

namespace GeladeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeladeiraController : ControllerBase
    {
        private static readonly Geladeira _geladeira = new Geladeira(3, 2, 4);

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var itens = _geladeira.ListarItens();

            if (itens.Count == 0)
            {
                return NotFound("Nenhum item encontrado na geladeira.");
            }

            return Ok(itens);
        }

        [HttpGet("{andar}/{container}/{posicao}")]
        public ActionResult<string> Get(int andar, int container, int posicao)
        {
            if (andar < 0 || andar > _geladeira.Andares.Count ||
                container < 0 || container > _geladeira.Andares[andar].Containers.Count ||
                posicao < 0 || posicao > _geladeira.Andares[andar].Containers[container].Itens.Count)
            {
                return NotFound("Item não encontrado");
            }

            var item = _geladeira.Andares[andar].Containers[container].Itens[posicao];
            return string.IsNullOrEmpty(item) ? NotFound("Item não encontrado") : Ok($"Andar {andar}, Container {container}, Posição {posicao}: {item}");
        }

        [HttpPost("{andar}/{container}/{posicao}")]
        public ActionResult Post(int andar, int container, int posicao, [FromBody] string item)
        {
            if (andar < 0 || andar > _geladeira.Andares.Count ||
                container < 0 || container > _geladeira.Andares[andar].Containers.Count ||
                posicao < 0 || posicao > _geladeira.Andares[andar].Containers[container].Itens.Count)
            {
                return BadRequest("Erro! Posição não encontrada");
            }

            var posicaoAtual = _geladeira.Andares[andar].Containers[container].Itens[posicao];
            if (!string.IsNullOrEmpty(posicaoAtual))
            {
                return Conflict("Posição já ocupada");
            }

            _geladeira.Andares[andar].AdicionarItem(container, posicao, item);
            return Ok($"{item} adicionado com sucesso");
        }

        [HttpPut("{andar}/{container}/{posicao}")]
        public ActionResult Put(int andar, int container, int posicao, [FromBody] string item)
        {
            if (andar < 0 || andar >= _geladeira.Andares.Count ||
                container < 0 || container >= _geladeira.Andares[andar].Containers.Count ||
                posicao < 0 || posicao >= _geladeira.Andares[andar].Containers[container].Itens.Count)
            {
                return BadRequest("Erro! Posição inválida");
            }

            _geladeira.Andares[andar].AdicionarItem(container, posicao, item);
            return Ok("Item atualizado com sucesso");
        }

        [HttpDelete("{andar}/{container}/{posicao}")]
        public ActionResult Delete(int andar, int container, int posicao)
        {
            if (andar < 0 || andar > _geladeira.Andares.Count ||
                container < 0 || container > _geladeira.Andares[andar].Containers.Count ||
                posicao < 0 || posicao > _geladeira.Andares[andar].Containers[container].Itens.Count)
            {
                return BadRequest("Erro! Posição inválida");
            }

            _geladeira.Andares[andar].RemoverItem(container, posicao);
            return Ok("Item removido com sucesso");
        }
    }
}