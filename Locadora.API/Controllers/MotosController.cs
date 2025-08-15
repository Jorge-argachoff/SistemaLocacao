using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces.Repository;
using Locadora.Domain.Interfaces.Service;
using Locadora.Infra.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locacao.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly IMotoService _motoService;

        public MotoController(IMotoService motoService)
        {
            _motoService = motoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var motos = await _motoService.GetAllMotos();
            return Ok(motos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            if (id <= 0)
                return NotFound();

            var moto = await _motoService.GetMotoById(id);

            if (moto is null)
                return NotFound();

            return Ok(moto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Moto moto)
        {
            await _motoService.CreateMoto(moto);
            return CreatedAtAction(nameof(Get), new { id = moto.Id }, moto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, string placa)
        {
            if (id <= 0 || string.IsNullOrEmpty(placa))
                return BadRequest();

            await _motoService.UpdatePlacaMoto(id, placa);

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _motoService.DeleteMoto(id);

            return NoContent();
        }
    }

}
