namespace Ejemplo03.Dominio.Test;

public class CuentaTest
{
    [Test]
    public void AcreditarIncrementaSaldo()
    {
        var cuenta = new Cuenta("unalias");
        cuenta.Acreditar(10);
        Assert.That(cuenta.Saldo(), Is.EqualTo(10));
    }

    [Test]
    public void AcreditarFallaCuandoMontoNegativo()
    {
        var cuenta = new Cuenta("unalias");
        Assert.Throws<TransaccionNoValidaException>(() => cuenta.Acreditar(-1));
    }

    [Test]
    public void AcreditarFallaCuandoMontoEsCero()
    {
        var cuenta = new Cuenta("unalias");
        Assert.Throws<TransaccionNoValidaException>(() => cuenta.Acreditar(0));
    }
    
    [Test]
    public void CreacionConAlias()
    {
        const string alias = "mialias";
        var cuenta = new Cuenta(alias);
        Assert.That(cuenta.Alias, Is.EqualTo(alias));
    }

    [Test]
    public void CreacionConSaldoCero()
    {
        const string alias = "mialias";
        var cuenta = new Cuenta(alias);
        Assert.That(cuenta.Saldo(), Is.EqualTo(0));
    }

    [Test]
    public void CreacionFallaSiAliasVacio()
    {
        const string alias = "";
        Assert.Throws<AliasInvalidoExcepcion>(() => new Cuenta(alias));
    }

    [Test]
    public void CreacionFallaSiAliasMayorA20()
    {
        const string alias = "123456789012345678901";
        Assert.Throws<AliasInvalidoExcepcion>(() => new Cuenta(alias));
    }
}