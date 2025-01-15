using NUnit.Framework.Constraints;

namespace FizzBuzzKata;

public class FizzBuzz
{
    public string De(int n)
    {
        if ((n % 3 == 0) && (n % 5 == 0))
        {
            return "FizzBuzz";
        }
        if (n % 5 == 0)
        {
            return "Buzz";
        }
        if (n % 3 == 0)
        {
            return "Fizz";
        }
        return n.ToString();
    }
}