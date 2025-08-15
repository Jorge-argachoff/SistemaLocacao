using Locacao.Domain.Interfaces.Service;
using Locacao.Infra.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locacao.API.Controllers
{
    public class MotosController : ControllerBase
    {
        private readonly IMotoService _motoService;

        public MotosController(IMotoService motoService)
        {
            _motoService = motoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(MotoDTO moto)
        {
            if (moto is null)
                return BadRequest();

            await _motoService.GetAllMotos();

            return Created();

        }

        [HttpGet]
        public async Task<IActionResult> GetByPlaca(string placa)
        {
            if (string.IsNullOrEmpty(placa))
                return BadRequest();

            await _motoService.GetMotoByPlaca(placa);

            return Created();

        }

        
        [HttpPost]        
        public async Task<IActionResult> Create(MotoDTO moto)
        {
            if (moto is null)
                return BadRequest();

            await _motoService.CreateMoto(moto.Ano,moto.Modelo,moto.Placa);
           
           return Created();
            
        }
              
        [HttpPost]       
        public async Task<IActionResult> Edit(MotoDTO motoDTO)
        {
            if (motoDTO is null)
                return BadRequest();

            await _motoService.UpdatePlacaMoto(motoDTO.Id,motoDTO.Placa);

            return Ok();
        }
                
        [HttpPost]       
        public async Task<IActionResult> Delete(long id)
        {
            if(id <=0)
                return BadRequest();

            await _motoService.DeleteMoto(id);

            return Ok();
        }
    }
}
