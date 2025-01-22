namespace Banco.Dominio.Test;

public class TransferenciaTest
{
    [Test]
    public void TransferenciaMueveUnMontoEntreCuentas()
    {
        var cuentaOrigen = new Cuenta("origen");
        cuentaOrigen.Acreditar(10);
        var cuentaDestino = new Cuenta("destino");
        var monto = 5;

        var transferencia = new Transferencia(cuentaOrigen, cuentaDestino, monto);
        transferencia.Ejecutar();
        
        Assert.That(cuentaOrigen.Saldo(), Is.EqualTo(5));
        Assert.That(cuentaDestino.Saldo(), Is.EqualTo(5));
    }
    
    [Test]
    public void TransferenciaTieneUnIdentificador()
    {
        var cuentaOrigen = new Cuenta("origen");
        cuentaOrigen.Acreditar(10);
        var cuentaDestino = new Cuenta("destino");
        var monto = 5;

        var transferencia = new Transferencia(cuentaOrigen, cuentaDestino, monto);
        var id = transferencia.Ejecutar();
        
        Assert.That(id, Is.EqualTo(transferencia.Id));
        Assert.IsNotNull(transferencia.Id);
        Assert.IsNotEmpty(transferencia.Id);
    }
    
    [Test]
    public void TransferenciaFallaCuandoOrigenSinSaldo()
    {
        var cuentaOrigen = new Cuenta("origen");
        cuentaOrigen.Acreditar(10);
        var cuentaDestino = new Cuenta("destino");
        var monto = 20;

        var transferencia = new Transferencia(cuentaOrigen, cuentaDestino, monto);
        Assert.Throws<SaldoInsuficienteException>(() => transferencia.Ejecutar());
        Assert.That(cuentaOrigen.Saldo(), Is.EqualTo(10));
        Assert.That(cuentaDestino.Saldo(), Is.EqualTo(0));
    }
}