using Dapper;
using Locadora.Domain.Entities;
using Locadora.Infra.DTO;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Text.Json;
namespace LocacaoMotoConsumer
{
    public class EventoRepository
    {
        private readonly IConfiguration _configuration;

        public EventoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task InsertAsync(Eventos eventos)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await connection.OpenAsync();

                    // Exemplo de inserção
                    string insertSql = "INSERT INTO public.\"Tb_Evento\" (\"Payload\", \"DataCadastro\") VALUES (@Payload, @DataCadastro)";

                    var parameter = new { Payload = eventos.Payload, DataCadastro = eventos.DataCadastro }
                    ;
                    await connection.ExecuteAsync(insertSql, parameter);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
