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
}