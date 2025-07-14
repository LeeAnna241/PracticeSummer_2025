using task14;

public class Tests
{
    [Fact]
    public void Test1()
    {
        var X = (double x) => x;
        Assert.Equal(0, DefiniteIntegral.Solve(-1, 1, X, 1e-4, 2), 1e-4);
    }

    [Fact]
    public void Test2()
    {
        var SIN = (double x) => Math.Sin(x);
        Assert.Equal(0, DefiniteIntegral.Solve(-1, 1, SIN, 1e-5, 8), 1e-4);
    }

    [Fact]
    public void Test3()
    {
        var X = (double x) => x;
        Assert.Equal(12.5, DefiniteIntegral.Solve(0, 5, X, 1e-6, 8), 1e-5);
    }
}
