namespace Banco.Dominio;

public class Banco
{
    private IRepositorioDeCuentas repositorio;

    public Banco(IRepositorioDeCuentas repositorioDeCuentas)
    {
        this.repositorio = repositorioDeCuentas;
    }

    public Cuenta CrearCuenta(string unAlias)
    {
        if (this.repositorio.ExisteCuentaConAlias(unAlias))
        {
            throw new AliasExistenteException();
        }
        var cuenta = new Cuenta(unAlias);
        this.repositorio.Guardar(cuenta);
        return cuenta;
    }
}