using Microsoft.AspNetCore.Mvc;
using SistemaGeladeira;
using System.Collections.Generic;

namespace GeladeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeladeiraController : ControllerBase
    {
        private static readonly Geladeira geladeira = new Geladeira(3, 2, 4);

        static GeladeiraController()
        {
            InicializarGeladeira();
        }

        private static void InicializarGeladeira()
        {
            AdicionarItem(0, 0, 0, "Ameixa");
            AdicionarItem(0, 0, 1, "Banana");
            AdicionarItem(0, 0, 2, "Caju");
            AdicionarItem(0, 0, 3, "Damasco");
            AdicionarItem(0, 1, 0, "Alface");
            AdicionarItem(0, 1, 1, "Batata");
            AdicionarItem(0, 1, 2, "Jiló");
            AdicionarItem(0, 1, 3, "Tomate");

            AdicionarItem(1, 0, 0, "Atum");
            AdicionarItem(1, 0, 1, "Leite");
            AdicionarItem(1, 0, 2, "Manteiga");
            AdicionarItem(1, 0, 3, "Requeijão");
            AdicionarItem(1, 1, 0, "Azeitona");
            AdicionarItem(1, 1, 1, "Ketchup");
            AdicionarItem(1, 1, 2, "Maionese");
            AdicionarItem(1, 1, 3, "Sardinha");

            AdicionarItem(2, 0, 0, "Mortadela");
            AdicionarItem(2, 0, 1, "Ovo");
            AdicionarItem(2, 0, 2, "Presunto");
            AdicionarItem(2, 0, 3, "Queijo");
            AdicionarItem(2, 1, 0, "Bacon");
            AdicionarItem(2, 1, 1, "Bife");
            AdicionarItem(2, 1, 2, "Linguiça");
            AdicionarItem(2, 1, 3, "Salame");
        }

        private static void AdicionarItem(int andar, int container, int posicao, string item)
        {
            geladeira.Andares[andar].AdicionarItem(container, posicao, item);
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var itens = new List<string>();

            for (int andar = 0; andar < geladeira.Andares.Count; andar++)
            {
                for (int container = 0; container < geladeira.Andares[andar].Containers.Count; container++)
                {
                    for (int posicao = 0; posicao < geladeira.Andares[andar].Containers[container].Itens.Count; posicao++)
                    {
                        var item = geladeira.Andares[andar].Containers[container].Itens[posicao];
                        if (!string.IsNullOrEmpty(item))
                        {
                            itens.Add($"Andar {andar}, Container {container}, Posição {posicao}: {item}");
                        }
                    }
                }
            }

            if (itens.Count == 0)
            {
                return NotFound("Nenhum item encontrado na geladeira.");
            }

            return Ok(itens);
        }

        [HttpGet("{andar}/{container}/{posicao}")]
        public ActionResult<string> Get(int andar, int container, int posicao)
        {
            if (andar < 0 || andar > geladeira.Andares.Count ||
                container < 0 || container > geladeira.Andares[andar].Containers.Count ||
                posicao < 0 || posicao > geladeira.Andares[andar].Containers[container].Itens.Count)
            {
                return NotFound("Item não encontrado");
            }

            var item = geladeira.Andares[andar].Containers[container].Itens[posicao];
            return string.IsNullOrEmpty(item) ? NotFound("Item não encontrado") : Ok($"Andar {andar}, Container {container}, Posição {posicao}: {item}");
        }

        [HttpPost("{andar}/{container}/{posicao}")]
        public ActionResult Post(int andar, int container, int posicao, [FromBody] string item)
        {
            if (andar < 0 || andar > geladeira.Andares.Count ||
                container < 0 || container > geladeira.Andares[andar].Containers.Count ||
                posicao < 0 || posicao > geladeira.Andares[andar].Containers[container].Itens.Count)
            {
                return BadRequest("Erro! Posição não encontrada");
            }

            var posicaoAtual = geladeira.Andares[andar].Containers[container].Itens[posicao];
            if (!string.IsNullOrEmpty(posicaoAtual))
            {
                return Conflict("Posição já ocupada");
            }

            geladeira.Andares[andar].AdicionarItem(container, posicao, item);
            return Ok($"{item} adicionado com sucesso");
        }

        [HttpPut("{andar}/{container}/{posicao}")]
        public ActionResult Put(int andar, int container, int posicao, [FromBody] string item)
        {
            if (andar < 0 || andar > geladeira.Andares.Count ||
                container < 0 || container > geladeira.Andares[andar].Containers.Count ||
                posicao < 0 || posicao > geladeira.Andares[andar].Containers[container].Itens.Count)
            {
                return BadRequest("Erro! Posição inválida");
            }

            geladeira.Andares[andar].AdicionarItem(container, posicao, item);
            return Ok("Item atualizado com sucesso");
        }

        [HttpDelete("{andar}/{container}/{posicao}")]
        public ActionResult Delete(int andar, int container, int posicao)
        {
            if (andar < 0 || andar > geladeira.Andares.Count ||
                container < 0 || container > geladeira.Andares[andar].Containers.Count ||
                posicao < 0 || posicao > geladeira.Andares[andar].Containers[container].Itens.Count)
            {
                return BadRequest("Erro! Posição inválida");
            }

            geladeira.Andares[andar].RemoverItem(container, posicao);
            return Ok("Item removido com sucesso");
        }
    }
}