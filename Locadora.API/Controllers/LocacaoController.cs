using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoService _locacaoService;

        public LocacaoController(ILocacaoService locacaoService)
        {
            _locacaoService = locacaoService;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Locacao locacao)
        {
            await _locacaoService.Create(locacao);
            return Ok();
        }

        [HttpPost("devolucao")]
        public async Task<IActionResult> Devolucao( long id)
        {
            await _locacaoService.Devolucao(id);
            return Ok();
        }

    }
}
