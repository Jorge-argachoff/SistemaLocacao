using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntregadoresController : Controller
    {
        private readonly IEntregadorService _entregadorService;

        public EntregadoresController(IEntregadorService entregadorService)
        {
            _entregadorService = entregadorService;
        }


        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var motos = await _entregadorService.GetAll();
            return Ok(motos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            if (id <= 0)
                return NotFound();

            var moto = await _entregadorService.GetById(id);

            if (moto is null)
                return NotFound();

            return Ok(moto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Entregador entregador)
        {
            await _entregadorService.Create(entregador);
            return CreatedAtAction(nameof(Get), new { id = entregador.Id }, entregador);
        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _entregadorService.Delete(id);

            return NoContent();
        }

    }
}
