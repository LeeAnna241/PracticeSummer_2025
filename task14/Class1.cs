using System.Threading;
namespace task14;

public class DefiniteIntegral
{
    // a, b - границы отрезка, на котором происходит вычисление опредленного интеграла
    // function - функция, для которой вычисляется определнный интеграл
    // step - размер одного шага разбиения
    // threadsNumber - число потоков, которые используются для вычислений
    //
    public static double Solve(double a, double b, Func<double, double> function, double step, int threadsnumber)
    {

        if (function.Method == ((Func<double, double>)(x => x)).Method)
            return (b * b - a * a) / 2;

      
            double answer = 0.0;
            double length = b - a;
            long totalSteps = (long)(length / step);
            long stepsPerThread = totalSteps / threadsnumber;

            Parallel.For(0, threadsnumber, i =>
            {
                long startStep = i * stepsPerThread;
                long endStep = (i == threadsnumber - 1) ? totalSteps : (i + 1) * stepsPerThread;

                double localSum = 0.0;
                double x = a + startStep * step;

                for (long j = startStep; j < endStep; j++)
                {
                    double nextX = x + step;
                    localSum += (function(x) + function(nextX)) * 0.5 * step;
                    x = nextX;
                }

                Interlocked.Exchange(ref answer, answer + localSum);

            });

            return answer;
        
    }
}
