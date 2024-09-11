using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Services.Interfaces;

/*
    Nome: Thais Barbosa dos Santos
 */

namespace GeladeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeladeiraController : ControllerBase
    {
        IService<ItensGeladeira> _service;

        public GeladeiraController(IService<ItensGeladeira> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItensGeladeira>> Get()
        {
            return _service.ListarTodos();
        }

        [HttpGet("{id}")]
        public ActionResult<ItensGeladeira> Get(int id)
        {
            var item = _service.Buscar(id);

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

            _service.Adicionar(item);
            return Ok("Item adicionado com sucesso");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ItensGeladeira item)
        {

            if (id != item.Id)
            {
                return BadRequest("Erro! Item inválido");
            }

            var itemExiste = _service.Buscar(id);

            if (itemExiste == null)
            {
                return NotFound();
            }

            _service.Atualizar(item);
            return Ok("Item atualizado com sucesso");


        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var itemExiste = _service.Buscar(id);

            if (itemExiste == null)
            {
                return NotFound();
            }

            _service.Remover(id);
            return Ok("Item removido com sucesso");
        }

    }
}