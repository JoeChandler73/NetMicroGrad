namespace MicroGrad;

public abstract class Module
{
    public void ZeroGrad()
    {
        foreach (var parameter in Parameters)
            parameter.Grad = 0;
    }
    
    public void UpdateParameters(double learningRate)
    {
        foreach (var parameter in Parameters)
            parameter.UpdateData(learningRate);
    }
    
    public abstract IEnumerable<Value> Parameters { get; }
}