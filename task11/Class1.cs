using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace task11;

 public interface ICalculator
{
    int Add(int x, int y);
    int Minus(int x, int y);
    int Mul(int x, int y);
    int Div(int x, int y);
}

[Generator]
public class SourceGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        string code = @"
namespace Generated
{
    public class Calculator : task11.ICalculator
    {
        public int Add(int x, int y) => x + y;
        public int Minus(int x, int y) => x - y;
        public int Mul(int x, int y) => x * y;
        public int Div(int x, int y) => x / y;
    }
}";
        
        context.AddSource("GeneratedCalculator", SourceText.From(code, Encoding.UTF8));
    }

    public void Initialize(GeneratorInitializationContext context) {}
}

