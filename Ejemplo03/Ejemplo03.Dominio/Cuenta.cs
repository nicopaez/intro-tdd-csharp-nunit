using System.Diagnostics;

namespace Ejemplo03.Dominio;

public class Cuenta
{
    private int saldo;

    public Cuenta(string alias)
    {
        if (string.IsNullOrEmpty(alias) || (alias.Length > 20))
        {
            throw new AliasInvalidoExcepcion();
        }

        this.Alias = alias;
        this.saldo = 0;
    }

    public string Alias { get; private set; }

    public int Saldo()
    {
        return this.saldo;
    }

    public void Acreditar(int monto)
    {
        if (monto <= 0)
        {
            throw new TransaccionNoValidaException();
        }
        this.saldo = this.saldo + monto;
    }
}