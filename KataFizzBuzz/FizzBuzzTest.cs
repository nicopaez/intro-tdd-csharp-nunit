using NUnit.Framework.Constraints;

namespace FizzBuzzKata;

[TestFixture]
public class FizzBuzzTest
{
    [Test]
    public void FizzbuzzDe1Es1()
    {
        Assert.That(new FizzBuzz().De(1), Is.EqualTo("1"));
    }
    
    [Test]
    public void FizzbuzzDe2Es2()
    {
        Assert.That(new FizzBuzz().De(2), Is.EqualTo("2"));
    }
    
    [Test]
    public void FizzbuzzDe3EsFizz()
    {
        Assert.That(new FizzBuzz().De(3), Is.EqualTo("Fizz"));
    }
    
    [Test]
    public void FizzbuzzDe6EsFizz()
    {
        Assert.That(new FizzBuzz().De(6), Is.EqualTo("Fizz"));
    }
    
    [Test]
    public void FizzbuzzDe5EsBuzz()
    {
        Assert.That(new FizzBuzz().De(5), Is.EqualTo("Buzz"));
    }
    
    [Test]
    public void FizzbuzzDe10EsBuzz()
    {
        Assert.That(new FizzBuzz().De(10), Is.EqualTo("Buzz"));
    }
    
    [Test]
    public void FizzbuzzDe15EsBuzz()
    {
        Assert.That(new FizzBuzz().De(15), Is.EqualTo("FizzBuzz"));
    }
    
    [Test]
    public void FizzbuzzDe30EsBuzz()
    {
        Assert.That(new FizzBuzz().De(30), Is.EqualTo("FizzBuzz"));
    }
}