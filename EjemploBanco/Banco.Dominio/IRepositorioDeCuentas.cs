namespace Banco.Dominio;

public interface IRepositorioDeCuentas
{
    bool ExisteCuentaConAlias(string unAlias);
    void Guardar(Cuenta cuenta);
    Cuenta Get(string unAlias);
}