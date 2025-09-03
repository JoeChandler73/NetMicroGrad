namespace MicroGrad;

public class Value
{
    public Value(double data, (Value lhs, Value? rhs)? children = null, string @operator = "")
    {
        Data = data;
        Operator = @operator;
        
        if (children != null)
        {
            Children.Add(children.Value.lhs);
            if (children.Value.rhs != null)
                Children.Add(children.Value.rhs);
        }
    }

    public double Data { get; private set; }
    
    public double Grad { get; set; }
    
    public string Operator { get; private set; }
    
    public HashSet<Value> Children { get; private set; } = new HashSet<Value>();

    private Action Backward { get; set; } = () => { };
    
    public static implicit operator Value(double value) => new Value(value);
    
    public static Value operator +(Value lhs, Value rhs)
    {
        var @out = new Value(lhs.Data + rhs.Data, (lhs, rhs), "+");

        @out.Backward = () =>
        {
            lhs.Grad += 1 * @out.Grad;
            rhs.Grad += 1 * @out.Grad;
        };
        
        return @out;
    }
    
    public static Value operator *(Value lhs, Value rhs)
    {
        var @out = new Value(lhs.Data * rhs.Data, (lhs, rhs), "*");
        
        @out.Backward = () =>
        {
            lhs.Grad += rhs.Data * @out.Grad;
            rhs.Grad += lhs.Data * @out.Grad;
        };
        
        return @out;
    }

    public static Value operator ^(Value lhs, double rhs)
    {
        var @out = new Value(Math.Pow(lhs.Data, rhs), (lhs, null), $"^{rhs}");
        @out.Backward = () => lhs.Grad += rhs * Math.Pow(lhs.Data, rhs - 1) * @out.Grad;
        return @out;
    }
    
    public static Value operator +(Value lhs, double rhs) => lhs + (Value)rhs;
    
    public static Value operator +(double lhs, Value rhs) => (Value)lhs + rhs;

    public static Value operator *(Value lhs, double rhs) => lhs * (Value)rhs;
    
    public static Value operator *(double lhs, Value rhs) => (Value)lhs * rhs;

    public static Value operator -(Value lhs, Value rhs) => lhs + (-1 * rhs);
    
    public static Value operator -(Value lhs, double rhs) => lhs - (Value)rhs;

    public static Value operator -(double lhs, Value rhs) => (Value)lhs - rhs;

    public static Value operator /(Value lhs, Value rhs) => lhs * (rhs ^ -1);
    
    public static Value operator /(Value lhs, double rhs) => lhs / (Value)rhs;

    public static Value operator /(double lhs, Value rhs) => (Value)lhs / rhs;

    public Value Exp()
    {
        var @out = new Value(Math.Exp(Data), (this,null), "exp");
        @out.Backward = () => Grad += @out.Data * @out.Grad;
        return @out;
    }

    public Value Tanh()
    {
        var data = (Math.Exp(2 * Data) - 1) / (Math.Exp(2 * Data) + 1);
        var @out = new Value(data, (this,null), "tanh");
        @out.Backward = () => Grad += (1 - data * data) * @out.Grad;
        return @out;
    }

    public void Back()
    {
        var topo = new List<Value>();
        var visited = new HashSet<Value>();
        BuildTopo(topo, visited, this);
        topo.Reverse();

        Grad = 1;
        foreach (var value in topo)
            value.Backward();
    }

    public void Update(double learningRate)
    {
        Data -= learningRate *  Grad;
    }

    private void BuildTopo(List<Value> topo, HashSet<Value> visited, Value value)
    {
        if(!visited.Contains(value))
            visited.Add(value);
        
        foreach (var child in value.Children) 
            BuildTopo(topo, visited, child);
        
        topo.Add(value);
    }
    
    public override string ToString()
    {
        return $"Value(Data={Data:n4})";
    }
}