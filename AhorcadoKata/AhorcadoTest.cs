namespace AhorcadoKata;

public class Tests
{
    [Test]
    public void CreacionConPalabraSecreta()
    {
        var ahorcado = new Ahorcado("secreto");
        Assert.That(ahorcado.MostrarEstado(), Is.EqualTo("_______"));
    }
    
    [Test]
    public void CreacionConPalabraSecretaOfuscada()
    {
        var ahorcado = new Ahorcado("hola");
        Assert.That(ahorcado.MostrarEstado(), Is.EqualTo("____"));
    }
    
    [Test]
    public void CreacionFallaSiPalabraCorta()
    {
        Assert.Throws<PalabraCortaException>(() => new Ahorcado("uno"));
    }
    
    [Test]
    public void CreacionCon7Vidas()
    {
        var ahorcado = new Ahorcado("hola");
        Assert.That(ahorcado.VidasRestantes(), Is.EqualTo(7));
    }
    
    [Test]
    public void CreacionConJuegoNoPerdido()
    {
        var ahorcado = new Ahorcado("hola");
        Assert.False(ahorcado.JuegoPerdido());
    }
    
    [Test]
    public void CreacionConJuegoNoGanado()
    {
        var ahorcado = new Ahorcado("hola");
        Assert.False(ahorcado.JuegoGanado());
    }

    
    [Test]
    public void ProbarLetraQueNoEstaDecrementaVida()
    {
        var ahorcado = new Ahorcado("hola");
        ahorcado.ProbarLetra('x');
        Assert.That(ahorcado.VidasRestantes(), Is.EqualTo(6));
    }
    
    [Test]
    public void ProbarLetraQueNoEstaNoCambiaEstado()
    {
        var ahorcado = new Ahorcado("hola");
        ahorcado.ProbarLetra('x');
        Assert.That(ahorcado.MostrarEstado(), Is.EqualTo("____"));
    }
    
    [Test]
    public void ProbarLetraQueEstaUnaVezCambiaEstado()
    {
        var ahorcado = new Ahorcado("hola");
        ahorcado.ProbarLetra('a');
        Assert.That(ahorcado.MostrarEstado(), Is.EqualTo("___a"));
    }
    
    [Test]
    public void ProbarLetraQueEstaUnaVezNoCambiaVidasRestantes()
    {
        var ahorcado = new Ahorcado("hola");
        ahorcado.ProbarLetra('a');
        Assert.That(ahorcado.VidasRestantes(), Is.EqualTo(7));
    }
    
    [Test]
    public void ProbarLetraQueEstaDosVecesCambiaEstado()
    {
        var ahorcado = new Ahorcado("mama");
        ahorcado.ProbarLetra('a');
        Assert.That(ahorcado.MostrarEstado(), Is.EqualTo("_a_a"));
    }

    [Test]
    public void ProbarLetraQueEstaNoEstaPierdoElJuegoSiTengo1Vidas()
    {
        var ahorcado = new Ahorcado("mama");
        ahorcado.ProbarLetra('b');
        ahorcado.ProbarLetra('c');
        ahorcado.ProbarLetra('d');
        ahorcado.ProbarLetra('e');
        ahorcado.ProbarLetra('f');
        ahorcado.ProbarLetra('g');
        ahorcado.ProbarLetra('h');
        Assert.That(ahorcado.JuegoPerdido(), Is.EqualTo(true));
    }
    
    [Test]
    public void ProbarLetraQueEstaSiSoloFaltaEsaGanoElJuego()
    {
        var ahorcado = new Ahorcado("mama");
        ahorcado.ProbarLetra('m');
        ahorcado.ProbarLetra('a');
        Assert.That(ahorcado.JuegoGanado(), Is.EqualTo(true));
    }
    
    [Test]
    public void ProbarLetraFallaSiJuegoEstaGanado()
    {
        var ahorcado = new Ahorcado("mama");
        ahorcado.ProbarLetra('m');
        ahorcado.ProbarLetra('a');
        Assert.Throws<JuegoTerminadoException>(() => ahorcado.ProbarLetra('x'));
    }
    
    [Test]
    public void ProbarLetraFallaSiJuegoEstaPerdido()
    {
        var ahorcado = new Ahorcado("mama");
        ahorcado.ProbarLetra('b');
        ahorcado.ProbarLetra('c');
        ahorcado.ProbarLetra('d');
        ahorcado.ProbarLetra('e');
        ahorcado.ProbarLetra('f');
        ahorcado.ProbarLetra('g');
        ahorcado.ProbarLetra('h');
        Assert.Throws<JuegoTerminadoException>(() => ahorcado.ProbarLetra('x'));
    }
}