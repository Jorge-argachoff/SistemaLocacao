using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces.Repository;
using Locadora.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.Services
{
    public class EntregadorService : IEntregadorService
    {
        private readonly IEntregadorRepository _entregadorRepository;

        public EntregadorService(IEntregadorRepository entregadorRepository)
        {
            _entregadorRepository = entregadorRepository;
        }
        public async Task Create(Entregador entregador)
        {
            await _entregadorRepository.Add(entregador);
        }

        public async Task Delete(long id)
        {
            await _entregadorRepository.Delete(id);
        }

        public async Task<IEnumerable<Entregador>> GetAll()
        {
            return await _entregadorRepository.GetAll();
        }

        public async Task<Entregador> GetById(long id)
        {
            return await _entregadorRepository.GetById(id);
        }

        public async Task Upload(IFormFile image, long id)
        {
           
            var savePath = Path.Combine(@"C:\temp\uploads", $"{DateTime.UtcNow.ToString("yyyyMMddHHmmssfff")}-{image.FileName}");
                        
            Directory.CreateDirectory(Path.GetDirectoryName(savePath));

            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var entregador = await _entregadorRepository.GetById(id);
            if(entregador is not null)
            {
                entregador.CaminhoImagemCNH = savePath;
                await _entregadorRepository.Update(entregador);
            }

        }
    }
}
