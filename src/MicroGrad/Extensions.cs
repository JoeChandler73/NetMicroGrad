namespace MicroGrad;


public static class Extensions
{
    public static Value Sum(this IEnumerable<Value> source)
    {
        var list = source.ToList();
        var result = list.First();
        
        foreach (var value in list.Skip(1))
            result += value;
        
        return result;
    }
}