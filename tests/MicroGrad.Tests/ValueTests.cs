namespace MicroGrad.Tests;

public class ValueTests
{
    [Fact]
    public void ShouldHaveCorrectString()
    {
        var a = new Value(2);
        Assert.Equal("Value(Data=2.0000)", a.ToString());
    }
    
    [Fact]
    public void ShouldHaveCorrectData()
    {
        var a = new Value(2);
        Assert.Equal(2, a.Data);
    }

    [Fact]
    public void ShouldImplicitlyCastDecimalToValue()
    {
        double a = 2;
        Value b = a;
        Assert.Equal(a, b.Data);
    }
    
    [Fact]
    public void ShouldAddTwoValues()
    {
        var a = new Value(2);
        var b = new Value(3);
        var c = a + b;
        Assert.Equal("Value(Data=5.0000)", c.ToString());
        
        var children = c.Children.ToList();
        Assert.Equal(2, children.Count);
        Assert.Equal(2, children[0].Data);
        Assert.Equal(3, children[1].Data);
    }
    
    [Fact]
    public void ShouldAddSelf()
    {
        var a = new Value(2);
        var b = a + a;
        Assert.Equal(4, b.Data);
        
        var children = b.Children.ToList();
        Assert.Single(children);
        Assert.Equal(2, children[0].Data);
    }
    
    [Fact]
    public void ShouldAddValueAndDouble()
    {
        var a = new Value(2);
        var c = a + 3;
        Assert.Equal("Value(Data=5.0000)", c.ToString());
        
        var children = c.Children.ToList();
        Assert.Equal(2, children.Count);
        Assert.Equal(2, children[0].Data);
        Assert.Equal(3, children[1].Data);
    }
    
    [Fact]
    public void ShouldAddDoubleAndValue()
    {
        var a = new Value(2);
        var c = 3 + a;
        Assert.Equal("Value(Data=5.0000)", c.ToString());
        
        var children = c.Children.ToList();
        Assert.Equal(2, children.Count);
        Assert.Equal(3, children[0].Data);
        Assert.Equal(2, children[1].Data);
    }
    
    [Fact]
    public void ShouldSubtractTwoValues()
    {
        var a = new Value(2);
        var b = new Value(1);
        var c = a - b;
        Assert.Equal("Value(Data=1.0000)", c.ToString());
        
        var children = c.Children.ToList();
        Assert.Equal(2, children.Count);
        Assert.Equal(2, children[0].Data);
        Assert.Equal(-1, children[1].Data);
    }
    
    [Fact]
    public void ShouldSubtractSelf()
    {
        var a = new Value(2);
        var b = a - a;
        Assert.Equal(0,  b.Data);
        
        var children = b.Children.ToList();
        Assert.Equal(2, children.Count);
        Assert.Equal(2, children[0].Data);
        Assert.Equal(-2, children[1].Data);
    }
    
    [Fact]
    public void ShouldSubtractValueAndDouble()
    {
        var a = new Value(2);
        var c = a - 1;
        Assert.Equal("Value(Data=1.0000)", c.ToString());
        
        var children = c.Children.ToList();
        Assert.Equal(2, children.Count);
        Assert.Equal(2, children[0].Data);
        Assert.Equal(-1, children[1].Data);
    }
    
    [Fact]
    public void ShouldSubtractDoubleAndValue()
    {
        var a = new Value(1);
        var c = 2 - a;
        Assert.Equal("Value(Data=1.0000)", c.ToString());
        
        var children = c.Children.ToList();
        Assert.Equal(2, children.Count);
        Assert.Equal(2, children[0].Data);
        Assert.Equal(-1, children[1].Data);
    }
    
    [Fact]
    public void ShouldMultiplyTwoValues()
    {
        var a = new Value(3);
        var b = new Value(2);
        var c = a * b;
        Assert.Equal("Value(Data=6.0000)", c.ToString());
        
        var children = c.Children.ToList();
        Assert.Equal(2, children.Count);
        Assert.Equal(3, children[0].Data);
        Assert.Equal(2, children[1].Data);
    }
    
    [Fact]
    public void ShouldMultiplySelf()
    {
        var a = new Value(2);
        var b = a * a;
        Assert.Equal(4, b.Data);
        
        var children = b.Children.ToList();
        Assert.Single(children);
        Assert.Equal(2, children[0].Data);
    }
    
    [Fact]
    public void ShouldMultiplyValueAndDouble()
    {
        var a = new Value(3);
        var c = a * 2;
        Assert.Equal("Value(Data=6.0000)", c.ToString());
        
        var children = c.Children.ToList();
        Assert.Equal(2, children.Count);
        Assert.Equal(3, children[0].Data);
        Assert.Equal(2, children[1].Data);
    }
    
    [Fact]
    public void ShouldMultiplyDoubleAndValue()
    {
        var a = new Value(3);
        var c = 2 * a;
        Assert.Equal("Value(Data=6.0000)", c.ToString());
        
        var children = c.Children.ToList();
        Assert.Equal(2, children.Count);
        Assert.Equal(2, children[0].Data);
        Assert.Equal(3, children[1].Data);
    }
    
    [Fact]
    public void ShouldDivideTwoValues()
    {
        var a = new Value(4);
        var b = new Value(2);
        var c = a / b;
        Assert.Equal("Value(Data=2.0000)", c.ToString());
        
        var children = c.Children.ToList();
        Assert.Equal(2, children.Count);
        Assert.Equal(4, children[0].Data);
        Assert.Equal(0.5, children[1].Data);
    }
    
    [Fact]
    public void ShouldDivideValueAndDouble()
    {
        var a = new Value(4);
        var c = a / 2;
        Assert.Equal("Value(Data=2.0000)", c.ToString());
        
        var children = c.Children.ToList();
        Assert.Equal(2, children.Count);
        Assert.Equal(4, children[0].Data);
        Assert.Equal(0.5, children[1].Data);
    }
    
    [Fact]
    public void ShouldDivideDoubleAndValue()
    {
        var a = new Value(2);
        var c = 4 / a;
        Assert.Equal("Value(Data=2.0000)", c.ToString());
        
        var children = c.Children.ToList();
        Assert.Equal(2, children.Count);
        Assert.Equal(4, children[0].Data);
        Assert.Equal(0.5, children[1].Data);
    }

    [Fact]
    public void TestNetwork()
    {
        // inputs x1, x2
        var x1 = new Value(2);
        var x2 = new Value(0);
        // weights w1, w2
        var w1 = new Value(-3.0);
        var w2 = new Value(1.0);
        // bias of the neuron
        var b = new Value(6.8813735870195432);
        // n = x1 * w1 + x2 * w2 + b
        var x1w1 = x1 * w1;
        var x2w2 = x2 * w2;
        var x1w1x2w2 = x1w1 + x2w2;
        var n = x1w1x2w2 + b;
        var o = n.Tanh();
        o.Back();

        // check values and gradients

        // o
        Assert.Equal("0.7071", $"{o.Data:n4}");
        Assert.Equal("1.0000", $"{o.Grad:n4}");
        Assert.Equal("tanh", o.Operator);
        // n
        Assert.Equal("0.8814", $"{n.Data:n4}");
        Assert.Equal("0.5000", $"{n.Grad:n4}");
        Assert.Equal("+", n.Operator);
        // b
        Assert.Equal("6.8814", $"{b.Data:n4}");
        Assert.Equal("0.5000", $"{b.Grad:n4}");
        Assert.Equal("", b.Operator);
        // x1w1x2w2
        Assert.Equal("-6.0000", $"{x1w1x2w2.Data:n4}");
        Assert.Equal("0.5000", $"{x1w1x2w2.Grad:n4}");
        Assert.Equal("+", x1w1x2w2.Operator);
        // x1w1
        Assert.Equal("-6.0000", $"{x1w1.Data:n4}");
        Assert.Equal("0.5000", $"{x1w1.Grad:n4}");
        Assert.Equal("*", x1w1.Operator);
        // x2w2
        Assert.Equal("0.0000", $"{x2w2.Data:n4}");
        Assert.Equal("0.5000", $"{x2w2.Grad:n4}");
        Assert.Equal("*", x2w2.Operator);
        // x1
        Assert.Equal("2.0000", $"{x1.Data:n4}");
        Assert.Equal("-1.5000", $"{x1.Grad:n4}");
        Assert.Equal("", x1.Operator);
        // x2
        Assert.Equal("0.0000", $"{x2.Data:n4}");
        Assert.Equal("0.5000", $"{x2.Grad:n4}");
        Assert.Equal("", x2.Operator);
        // w1
        Assert.Equal("-3.0000", $"{w1.Data:n4}");
        Assert.Equal("1.0000", $"{w1.Grad:n4}");
        Assert.Equal("", w1.Operator);
        // w2
        Assert.Equal("1.0000", $"{w2.Data:n4}");
        Assert.Equal("0.0000", $"{w2.Grad:n4}");
        Assert.Equal("", w2.Operator);
    }

    [Fact]
    public void Test()
    {
        var network = new Network(3, 4, 4, 1);
        var parameters = network.Parameters.ToList();
    }
}