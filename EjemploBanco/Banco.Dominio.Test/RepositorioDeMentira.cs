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

    public Cuenta Get(string unAlias)
    {
        throw new NotImplementedException();
    }

    public bool FueLlamadoGuardar()
    {
        return this.fueLlamadoGuardar;
    }
}

public class RepositorioFake : IRepositorioDeCuentas
{
    private List<Cuenta> cuentas = new List<Cuenta>();
    public bool ExisteCuentaConAlias(string unAlias)
    {
        var cuentas = this.cuentas.Count(c => c.Alias == unAlias);
        return cuentas > 0;
    }

    public void Guardar(Cuenta cuenta)
    {
        if (!this.cuentas.Contains(cuenta))
        {
            this.cuentas.Add(cuenta);    
        }
    }

    public Cuenta Get(string unAlias)
    {
        return this.cuentas.First(c => c.Alias == unAlias);
    }
}