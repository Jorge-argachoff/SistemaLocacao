using Locadora.Domain.Entities;

namespace Locadora.Tests
{
    public class LocacaoTests
    {
        [Fact]
        public void DeveRetornarTrue_QuandoDataFimForIgualDataPrevisao()
        {
            // Arrange
            var locacao = new Locacao
            {
                DataCadastro = new DateTime(2025, 08, 14),
                DataInicio = new DateTime(2025, 08, 15),
                DataTermino = new DateTime(2025, 08, 22),
                DataPrevisaoTermino = new DateTime(2025, 08, 22),
                Plano = new Plano { Id = 1, ValorDia = 30.00m, Dias = 7, Nome = "Plano 7" }
            };

            // Act
            var result = locacao.PrevisaoCorreta() ;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DeveRetornarFalse_QuandoDataFimForDiferenteDataPrevisao()
        {
            // Arrange
            var locacao = new Locacao
            {
                DataCadastro = new DateTime(2025, 08, 14),
                DataInicio = new DateTime(2025, 08, 15),
                DataTermino = new DateTime(2025, 08, 21),
                DataPrevisaoTermino = new DateTime(2025, 08, 22),
                Plano = new Plano { Id = 1, ValorDia = 30.00m, Dias = 7, Nome = "Plano 7" }
            };

            // Act
            var result = locacao.PrevisaoCorreta();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DeveRetornarFalse_QuandoDataPrevisaoOuInicioForMenorQueDataAtual()
        {
            // Arrange
            var locacao = new Locacao
            {
                DataCadastro = new DateTime(2025, 08, 14),
                DataInicio = new DateTime(2025, 08, 15),
                DataTermino = new DateTime(2025, 08, 21),
                DataPrevisaoTermino = new DateTime(2025, 08, 18),
                Plano = new Plano { Id = 1, ValorDia = 30.00m, Dias = 7, Nome = "Plano 7" }
            };

            // Act
            var result = locacao.ValidarDataMenorQueDataAtual();

            // Assert
            Assert.False(result);
        }
    }
}