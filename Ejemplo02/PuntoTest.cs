namespace Ejemplo02;

public class PuntoTest
{
    [Test]
    public void SeCreaConXeY()
    {
        const int x = 1;
        const int y = 1;
        var unPunto = new Punto(x, y);
        Assert.Multiple(() =>
        {
            Assert.That(unPunto.X, Is.EqualTo(x));
            Assert.That(unPunto.Y, Is.EqualTo(y));
        });
    }

    [Test]
    public void EsIgualSiTienenMismosValores()
    {
        var unPunto = new Punto(1, 1);
        var otroPunto = new Punto(1, 1);
        Assert.That(unPunto.EsIgualA(otroPunto));
    }
    
    [Test]
    public void NoEsIgualSiNoTienenMismosValores()
    {
        var unPunto = new Punto(1, 2);
        var otroPunto = new Punto(2, 1);
        Assert.That(!unPunto.EsIgualA(otroPunto));
    }
    
    [Test]
    public void ElModuloDe1_0Es1()
    {
        var unPunto = new Punto(1, 0);
        Assert.That(unPunto.Modulo(), Is.EqualTo(1.0));
    }
    
    [Test]
    public void ElModuloDe0_2Es2()
    {
        var unPunto = new Punto(0, 2);
        Assert.That(unPunto.Modulo(), Is.EqualTo(2.0));
    }

    [Test]
    public void ElModuloDe4_3Es5()
    {
        var unPunto = new Punto(4, 3);
        Assert.That(unPunto.Modulo(), Is.EqualTo(5.0));
    }
    
    [Test]
    public void ElModuloDe2_1UnoEs2Coma2()
    {
        var unPunto = new Punto(2, 1);
        Assert.That(unPunto.Modulo(), Is.EqualTo(2.2));
    }
}