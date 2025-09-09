namespace MicroGrad;

public class Network : Module
{
    private readonly List<Layer> _layers;
    
    public Network(int numberOfInputs, params int[] numberOfOutputs) 
        : this(numberOfInputs, numberOfOutputs.AsEnumerable())
    {
    }
    
    public Network(int numberOfInputs, IEnumerable<int> numberOfOutputs)
    {
        var numOutputs = numberOfOutputs.ToList();
        
        var sizes = new List<int>();
        sizes.Add(numberOfInputs);
        sizes.AddRange(numOutputs);
        
        _layers = Enumerable.Range(0, numOutputs.Count)
            .Select(i => new Layer(sizes[i], sizes[i + 1]))
            .ToList();
    }

    public IEnumerable<Value> GetOutputs(IEnumerable<Value> inputs)
    {
        var outputs = inputs;
        foreach (var layer in _layers)
            outputs = layer.GetOutputs(outputs);

        return outputs;
    }
    
    public IEnumerable<Value> GetOutputs(params Value[] inputs) => GetOutputs((IEnumerable<Value>)inputs);
    
    public override IEnumerable<Value> Parameters => _layers.SelectMany(layer => layer.Parameters);
}