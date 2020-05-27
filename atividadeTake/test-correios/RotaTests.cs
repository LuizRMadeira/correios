using System;
using Xunit;
using correios;
using correios.servicos;
using Moq;

namespace test_correios
{
    public class RotaTests
    {
        [Fact]
        public void Retornar_Resultado_Final_Correto()
        {
            var mockTrechosServicos = new Mock<TrechosServicos>();
            mockTrechosServicos.Setup(x => x.consultarTrechos()).Returns(

                new string[,] { { "LS", "SF", "1" },
                                { "SF", "LS", "2" },
                                { "LS", "LV", "1" },
                                { "LV", "LS", "1" },
                                { "SF", "LV", "2" },
                                { "LV", "SF", "2" },
                                { "LS", "RC", "1" },
                                { "RC", "LS", "2" },
                                { "SF", "WS", "1" },
                                { "WS", "SF", "2" },
                                { "LV", "BC", "1" },
                                { "BC", "LV", "1" }}
            );

            var teste = new Entrega(mockTrechosServicos.Object);

            teste.rota("WS BC");

            Assert.Equal("WS SF LV BC 5", teste.resultadoFinal);
        }
    }
}