using NUnit.Framework.Constraints;

namespace Ejemplo02;

public class Punto(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;

    public bool EsIgual(Punto otroPunto)
    {
        if (this.Equals(otroPunto))
        {
            return true;
        }

        return this.X == otroPunto.X && this.Y == otroPunto.Y;
    }

    public double Modulo()
    {
        return Math.Round(Math.Sqrt((this.X * this.X) + (this.Y * this.Y)), 1);
    }
}