namespace Banco.Dominio;

public class Transferencia
{
    private readonly Cuenta origen;
    private readonly Cuenta destino;
    private readonly int monto;

    public Transferencia(Cuenta cuentaOrigen, Cuenta cuentaDestino, int monto)
    {
        this.origen = cuentaOrigen;
        this.destino = cuentaDestino;
        this.monto = monto;
    }

    public string? Id { get; private set; }

    public string Ejecutar()
    {
        try
        {
            this.origen.Debitar(monto);
        }
        catch (TransaccionNoValidaException)
        {
            throw new SaldoInsuficienteException();
        }
        
        this.destino.Acreditar(monto);
        this.Id = Guid.NewGuid().ToString();
        return this.Id;
    }
}