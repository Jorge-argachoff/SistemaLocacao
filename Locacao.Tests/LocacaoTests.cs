namespace Locacao.Tests
{
    public class LocacaoTests
    {
        [Fact]
        public void EstaVencida_DeveRetornarTrue_QuandoDataFimEpassada()
        {
            // Arrange
            var locacao = new Locacao
            {
            };

            // Act
            var result = locacao.EstaVencida();

            // Assert
            Assert.True(result);
        }
    }
}