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

    public string TransferirDinero(string aliasCuentaOrigen, string aliasCuentaDestino, int monto)
    {
        VerificarCuentaExistente(aliasCuentaOrigen);
        VerificarCuentaExistente(aliasCuentaDestino);
        var origen = this.repositorio.Get(aliasCuentaOrigen);
        var destino = this.repositorio.Get(aliasCuentaDestino);
        var transferencia = new Transferencia(origen, destino, monto);
        return transferencia.Ejecutar();
    }

    private void VerificarCuentaExistente(string aliasCuenta)
    {
        if (!this.repositorio.ExisteCuentaConAlias(aliasCuenta))
        {
            throw new CuentaInexistenteException();
        }
    }

    public IReadOnlyList<Transaccion> ConsultarTransacciones(string unAlias)
    {
        if (this.repositorio.ExisteCuentaConAlias(unAlias))
        {
            return this.repositorio.Get(unAlias).Historial();
        }

        throw new CuentaInexistenteException();
    }
}