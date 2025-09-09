using MathNet.Numerics.Distributions;

namespace MicroGrad;

public class Neuron : Module
{
    private readonly List<Value> _weights;

    private readonly Value _bias;
    
    private readonly Func<Value, Value> _activation;
    
    public Neuron(int numberOfInputs, Func<Value, Value>? activation = null)
    {
        var uniform = new ContinuousUniform(-1, 1);

        _weights = Enumerable.Range(0, numberOfInputs)
            .Select(i => new Value(uniform.Sample()))
            .ToList();
        
        _bias = new Value(uniform.Sample());
        
        _activation = activation ?? (x => x.Tanh());
    }

    public Value GetOutput(IEnumerable<Value> inputs)
    {
        var inputList = inputs.ToList();
        if (inputList.Count != _weights.Count)
            throw new ArgumentException($"Expected {_weights.Count} inputs, got {inputList.Count}");
        
        var @out = _weights.Zip(inputList)
            .Select(item => item.First * item.Second)
            .Sum() + _bias;

        return _activation(@out);
    }

    public Value GetOutput(params Value[] inputs) => GetOutput((IEnumerable<Value>)inputs);

    public override IEnumerable<Value> Parameters => _weights.Append(_bias);
}