namespace TestProject
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void TestarSomaProgressiva()
        {
            int indice = 13;
            int resultado = SomaProgressiva.CalcularSoma(indice);
            Assert.That(resultado, Is.EqualTo(91));
        }

       
        [Test]
        public void TestarInversorDeString()
        {
            string resultado = StringHelper.Inverter("hello");
            Assert.That(resultado, Is.EqualTo("olleh"));
        }
    }
}
