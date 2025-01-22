namespace Banco.Dominio.Test;

public class BancoTest
{
    [Test]
    public void CreaLaCuentaCuandoElAliasEstaDisponible()
    {
        var repositorio = new RepositorioDeMentira();
        repositorio.ConfigurarExisteCuentaConAlias(false);
        var banco = new Banco(repositorio);
        const string unAlias = "unaliasQueNoExiste";

        var cuenta = banco.CrearCuenta(unAlias);
        
        Assert.That(cuenta.Alias, Is.EqualTo(unAlias));
        Assert.IsTrue(repositorio.FueLlamadoGuardar(), "Repositorio.Guardar no fue llamado");
    }
    
    [Test]
    public void CrearLaCuentaFallaCuandoElAliasNoEstaDisponible()
    {
        var repositorio = new RepositorioDeMentira();
        repositorio.ConfigurarExisteCuentaConAlias(true);
        var banco = new Banco(repositorio);
        const string unAlias = "unaliasQueNoExiste";

        Assert.Throws<AliasExistenteException>(() => banco.CrearCuenta(unAlias));
        Assert.IsFalse(repositorio.FueLlamadoGuardar(), "Repositorio.Guardar fue llamado");
    }

    [Test]
    public void TransferirDineroGeneraUnIdDeTransferencia()
    {
        var aliasCuentaOrigen = "origen";
        var aliasCuentaDestino = "destino";
        var repositorio = new RepositorioFake();
        var cuentaOrigen = new Cuenta(aliasCuentaOrigen);
        cuentaOrigen.Acreditar(100);
        repositorio.Guardar(cuentaOrigen);
        repositorio.Guardar(new Cuenta(aliasCuentaDestino));
        
        var banco = new Banco(repositorio);

        var idTransferencia = banco.TransferirDinero(aliasCuentaOrigen, aliasCuentaDestino, 10);

        Assert.That(idTransferencia, Is.Not.Null);
        Assert.That(idTransferencia, Is.Not.Empty);
    }
    
    [Test]
    public void TransferirDineroFallaCuandoOrigenNoExiste()
    {
        var aliasCuentaDestino = "destino";
        var repositorio = new RepositorioFake();
        repositorio.Guardar(new Cuenta(aliasCuentaDestino));
        
        var banco = new Banco(repositorio);

        Assert.Throws<CuentaInexistenteException>(() => banco.TransferirDinero("aliasCuentaOrigen", aliasCuentaDestino, 10));
    }
    
    [Test]
    public void TransferirDineroFallaCuandoDestinoNoExiste()
    {
        var aliasCuentaOrigen = "origen";
        var repositorio = new RepositorioFake();
        var cuentaOrigen = new Cuenta(aliasCuentaOrigen);
        cuentaOrigen.Acreditar(100);
        repositorio.Guardar(cuentaOrigen);
        
        var banco = new Banco(repositorio);

        Assert.Throws<CuentaInexistenteException>(() => banco.TransferirDinero(aliasCuentaOrigen, "aliasCuentaDestino", 10));
    }

    [Test]
    public void ConsultarTransaccionesDevuelveVacioCuandoNoHay()
    {
        var unAlias = "alias";
        var cuenta = new Cuenta(unAlias);
        var repositorio = new RepositorioFake();
        repositorio.Guardar(cuenta);
        var banco = new Banco(repositorio);

        var transacciones = banco.ConsultarTransacciones(unAlias);
        
        Assert.That(transacciones.Count(), Is.EqualTo(0));
    }
    
    [Test]
    public void ConsultarTransaccionesDevuelveListaDeTransacciones()
    {
        var unAlias = "alias";
        var cuenta = new Cuenta(unAlias);
        cuenta.Acreditar(10);
        cuenta.Debitar(5);
        var repositorio = new RepositorioFake();
        repositorio.Guardar(cuenta);
        var banco = new Banco(repositorio);

        var transacciones = banco.ConsultarTransacciones(unAlias);
        
        Assert.That(transacciones.Count(), Is.EqualTo(2));
    }
    
    [Test]
    public void ConsultarTransaccionesFallaCuandoLaCuentaNoExiste()
    {
        var unAlias = "alias";
        var repositorio = new RepositorioFake();
        var banco = new Banco(repositorio);

        Assert.Throws<CuentaInexistenteException>(() => banco.ConsultarTransacciones(unAlias));
    }
}