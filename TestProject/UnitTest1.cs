namespace TestProject
{
    [TestFixture] 
    public class UnitTests
    {
        [Test] 
        public void TestarSomaProgressiva()
        {
            int resultado = SomaProgressiva.CalcularSoma();
            Assert.That(resultado, Is.EqualTo(91));
        }

        [Test]
        [TestCase(0, true)] 
        [TestCase(1, true)]
        [TestCase(13, true)]
        [TestCase(15, false)]
        public void TestarFibonacci(int numero, bool esperado)
        {
            bool resultado = Fibonacci.PertenceAoFibonacci(numero);
            Assert.That(resultado, Is.EqualTo(esperado));
        }

        [Test]
        public void TestarFaturamentoDiario()
        {
            var faturamentos = new List<double> { 200, 300, 0, 500, 0, 100, 800 };
            var resultado = FaturamentoDiario.AnalisarFaturamento(faturamentos);

            Assert.That(resultado.menor, Is.EqualTo(100));
            Assert.That(resultado.maior, Is.EqualTo(800));
            Assert.That(resultado.diasAcimaDaMedia, Is.EqualTo(3));
        }

        [Test]
        public void TestarFaturamentoPorEstado()
        {
            var faturamento = new Dictionary<string, double>
            {
                { "SP", 67836.43 },
                { "RJ", 36678.66 },
                { "MG", 29229.88 },
                { "ES", 27165.48 },
                { "Outros", 19849.53 }
            };

            var resultado = FaturamentoPorEstado.CalcularPercentuais(faturamento);

            Assert.That(System.Math.Round(resultado["SP"], 2), Is.EqualTo(37.51));
            Assert.That(System.Math.Round(resultado["RJ"], 2), Is.EqualTo(20.63));
        }

        [Test]
        public void TestarInversorDeString()
        {
            string resultado = InversorDeString.Inverter("hello");
            Assert.That(resultado, Is.EqualTo("olleh"));
        }
    }
}
