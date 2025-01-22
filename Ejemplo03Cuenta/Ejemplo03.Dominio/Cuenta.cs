using System.Diagnostics;

namespace Ejemplo03.Dominio;

public class Cuenta
{
    private int saldo;
    private readonly List<Transaccion> historial;

    public Cuenta(string alias)
    {
        if (string.IsNullOrEmpty(alias) || (alias.Length > 20))
        {
            throw new AliasInvalidoExcepcion();
        }

        this.Alias = alias;
        this.saldo = 0;
        this.historial = new List<Transaccion>();
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
        this.historial.Add(new TransaccionCredito(monto));
    }

    public void Debitar(int monto)
    {
        if (monto < 0)
        {
            throw new TransaccionNoValidaException();
        }

        if (monto > this.Saldo())
        {
            throw new TransaccionNoValidaException();
        }
        this.saldo = this.saldo - monto;
        this.historial.Add(new TransaccionDebito(monto));
    }

    public IReadOnlyList<Transaccion> Historial()
    {
        return this.historial;
    }
}
