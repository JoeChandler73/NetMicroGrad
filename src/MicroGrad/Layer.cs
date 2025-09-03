namespace MicroGrad;

public class Layer : Module
{
    private readonly List<Neuron> _neurons;
    
    public Layer(int numberOfInputs, int numberOfOutputs)
    {
        _neurons = Enumerable.Range(0, numberOfOutputs)
            .Select(i => new Neuron(numberOfInputs))
            .ToList();
    }

    public IEnumerable<Value> GetOutputs(IEnumerable<Value> inputs)
    {
        return _neurons
            .Select(neuron => neuron.GetOutput(inputs));
    }
    
    public IEnumerable<Value> GetOutputs(params Value[] inputs) => GetOutputs(inputs.AsEnumerable());

    public override IEnumerable<Value> Parameters => _neurons.SelectMany(neuron => neuron.Parameters);
}