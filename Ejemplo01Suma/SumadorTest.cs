namespace Ejemplo01;

public class Tests
{
    [Test]
    public void Test1()
    {
        var sumando1 = 1;
        var sumando2 = 2;
        var sumador = new Sumador();
        var resultado = sumador.Sumar(sumando1, sumando2);
        Assert.AreEqual(3, resultado);
    }
    
    [Test]
    public void Test2()
    {
        var sumando1 = 1;
        var sumando2 = 5;
        var sumador = new Sumador();
        var resultado = sumador.Sumar(sumando1, sumando2);
        Assert.AreEqual(6, resultado);
    }
}