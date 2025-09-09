namespace MicroGrad;

public static class Extensions
{
    public static Value Sum(this IEnumerable<Value> source)
    {
        if (source == null) 
            throw new ArgumentNullException(nameof(source));
        
        return source.Aggregate(new Value(0), (acc, next) => acc + next);
    }
}