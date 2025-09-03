namespace MicroGrad;

public static class Extensions
{
    public static Value Sum(this IEnumerable<Value> source)
    {
        return source.Aggregate((acc, next) => acc + next);
    }
}