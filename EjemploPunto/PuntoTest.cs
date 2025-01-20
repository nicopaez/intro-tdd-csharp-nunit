namespace Ejemplo02;

public class PuntoTest
{

    [Test]
    public void SeCreaConXeY()
    {
        const int x = 1;
        const int y = 1;
        var punto = new Punto(x, y);
        Assert.Multiple(() =>
        {
            Assert.That(punto.X, Is.EqualTo(x));
            Assert.That(punto.Y, Is.EqualTo(y));
        });
    }

    [Test]
    public void EsIgualAsimismo()
    {
        var unPunto = new Punto(1, 1);
        var esIgual = unPunto.EsIgual(unPunto);
        Assert.That(esIgual, Is.True);
    }
    
    [Test]
    public void EsIgualSiTieneLosMismosValores()
    {
        const int x = 1;
        const int y = 1;
        var unPunto = new Punto(x, y);
        var otroPunto = new Punto(x, y);
        var esIgual = unPunto.EsIgual(otroPunto);
        Assert.That(esIgual, Is.True);
    }
    
    [Test]
    public void NoEsIgualSiNoTieneLosMismosValores()
    {
        var unPunto = new Punto(1, 1);
        var otroPunto = new Punto(1, 2);
        var esIgual = unPunto.EsIgual(otroPunto);
        Assert.That(esIgual, Is.False);
    }
    
    [Test]
    public void ModuloDelOrigen()
    {
        var unPunto = new Punto(0, 0);
        var modulo = unPunto.Modulo();
        Assert.That(modulo, Is.EqualTo(0.0));
    }
    
    [Test]
    public void ModuloDelPuntoCanonico()
    {
        var unPunto = new Punto(1, 0);
        var modulo = unPunto.Modulo();
        Assert.That(modulo, Is.EqualTo(1.0));
    }
    
    [Test]
    public void ModuloDeUnPuntoQueDaEntero()
    {
        var unPunto = new Punto(4, 3);
        var modulo = unPunto.Modulo();
        Assert.That(modulo, Is.EqualTo(5.0));
    }
   
    [Test]
    public void ModuloDeUnPuntoQueNoDaEntero()
    {
        var unPunto = new Punto(1, 1);
        var modulo = unPunto.Modulo();
        Assert.That(modulo, Is.EqualTo(1.4));
    }
}