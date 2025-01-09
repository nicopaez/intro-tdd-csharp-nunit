using NUnit.Framework.Constraints;

namespace Ejemplo02;

public class Punto(int x, int y)
{
    public int X { get; } = x;
    
    public int Y { get; } = y;
    public bool EsIgualA(Punto otroPunto)
    {
        return X == otroPunto.X && Y == otroPunto.Y;
    }

    public double Modulo()
    {
        return Math.Round(Math.Sqrt(X*X + Y*Y), 1);
    }
}