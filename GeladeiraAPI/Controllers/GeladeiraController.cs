using Microsoft.AspNetCore.Mvc;
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