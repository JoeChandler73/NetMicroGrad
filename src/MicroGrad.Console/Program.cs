using MicroGrad;

var learningRate = 0.05;
var network = new Network(3, 4, 4, 1);

var inputs = new[]
{
    new List<Value>{ 2.0,  3.0, -1.0 },
    new List<Value>{ 3.0, -1.0,  0.5 },
    new List<Value>{ 0.5,  1.0,  1.0 },
    new List<Value>{ 1.0,  1.0, -1.0 },
};

var required = new List<Value>{ 1.0, -1.0, -1.0, 1.0 };

var numberOfIterations = 50;
for (var index = 0; index < numberOfIterations; index++)
{
    // forward pass
    var predictions = inputs.Select(input => network.GetOutputs(input).First());

    var loss = predictions.Zip(required)
        .Select(p => (p.First - p.Second) * (p.First - p.Second))
        .Sum();
    
    // backward pass
    network.ZeroGrad();
    loss.Back();
    network.UpdateParameters(learningRate);

    if (index % 10 == 0 || index == numberOfIterations - 1)
    {
        Console.WriteLine($"Epoch {index}: Loss = {loss.Data:F6}");
        if (index == numberOfIterations - 1)
        {
            Console.WriteLine("\nFinal Predictions vs Targets:");
            for (int i = 0; i < predictions.Count(); i++)
            {
                var pred = predictions.ElementAt(i);
                Console.WriteLine($"Input {i}: Predicted = {pred.Data:F4}, Target = {required[i].Data:F4}");
            }
        }
    }
}