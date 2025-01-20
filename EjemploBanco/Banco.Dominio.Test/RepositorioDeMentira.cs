namespace Banco.Dominio.Test;

public class RepositorioDeMentira : IRepositorioDeCuentas
{
    private bool existeCuentaConAlias;
    private bool fueLlamadoGuardar = false;

    public void ConfigurarExisteCuentaConAlias(bool valorConfiguracion)
    {
        this.existeCuentaConAlias = valorConfiguracion;
    }
    public bool ExisteCuentaConAlias(string unAlias)
    {
        return this.existeCuentaConAlias;
    }

    public void Guardar(Cuenta cuenta)
    {
        this.fueLlamadoGuardar = true;
    }

    public bool FueLlamadoGuardar()
    {
        return this.fueLlamadoGuardar;
    }
}