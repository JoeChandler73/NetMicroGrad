namespace MicroGrad;

public class Layer : Module
{
    private readonly List<Neuron> _neurons;
    
    public Layer(int numberOfInputs, int numberOfOutputs, Func<Value, Value>? activation = null)
    {
        _neurons = Enumerable.Range(0, numberOfOutputs)
            .Select(i => new Neuron(numberOfInputs, activation))
            .ToList();
    }

    public IEnumerable<Value> GetOutputs(IEnumerable<Value> inputs)
    {
        return _neurons
            .Select(neuron => neuron.GetOutput(inputs))
            .ToList();
    }
    
    public IEnumerable<Value> GetOutputs(params Value[] inputs) => GetOutputs((IEnumerable<Value>)inputs);

    public override IEnumerable<Value> Parameters => _neurons.SelectMany(neuron => neuron.Parameters);
}