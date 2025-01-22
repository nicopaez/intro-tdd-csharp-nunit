namespace Ejemplo03.Dominio;

public abstract class Transaccion(int monto)
{
    public virtual int Monto { get; } = monto;
}
public class TransaccionCredito(int monto) : Transaccion(monto)
{
}

public class TransaccionDebito(int monto) : Transaccion(monto)
{
}