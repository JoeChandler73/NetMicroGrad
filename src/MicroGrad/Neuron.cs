using MathNet.Numerics.Distributions;

namespace MicroGrad;

public class Neuron : Module
{
    private readonly List<Value> _weights;

    private readonly Value _bias;
    
    public Neuron(int numberOfInputs)
    {
        var uniform = new ContinuousUniform(-1, 1);

        _weights = Enumerable.Range(0, numberOfInputs)
            .Select(i => new Value(uniform.Sample()))
            .ToList();
        
        _bias = new Value(uniform.Sample());
    }

    public Value GetOutput(IEnumerable<Value> inputs)
    {
        var @out = _weights.Zip(inputs)
            .Select(item => item.First * item.Second)
            .Sum() + _bias;

        return @out.Tanh();
    }

    public Value GetOutput(params Value[] inputs) => GetOutput(inputs.AsEnumerable());

    public override IEnumerable<Value> Parameters => _weights.Append(_bias);
}