namespace Ejemplo03.Dominio.Test;

[TestFixture]
public class TransaccionCreditoTest
{
    [Test]
    public void CreacionConMonto()
    {
        var trx = new TransaccionCredito(100);
        Assert.That(trx.Monto, Is.EqualTo(100));
    }
}

[TestFixture]
public class TransaccionDebitoTest
{
    [Test]
    public void CreacionConMonto()
    {
        var trx = new TransaccionDebito(100);
        Assert.That(trx.Monto, Is.EqualTo(100));
    }
}