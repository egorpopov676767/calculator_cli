using System.Numerics;

public static class Extensions
{
    public static BigInteger Sum(this IEnumerable<BigInteger> bigIntegers)
    {
        return bigIntegers.Aggregate<BigInteger, BigInteger>(
            0, (current, b) => current + b);
    }
}