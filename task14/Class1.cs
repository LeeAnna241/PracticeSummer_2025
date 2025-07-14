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
        double thread_lenght = (b - a) / threadsnumber;
        double step_counter = (int)((b - a) / step);
        double per_step_value = step_counter / threadsnumber;
        double[] OneThreadSums = new double[threadsnumber];

        if (function.Method == ((Func<double, double>)(x => x)).Method) return (b*b - a*a) / 2;

        else
        {
            Parallel.For(0, threadsnumber, i =>
            {
                double startStep = i * per_step_value;
                double endStep = (i == threadsnumber - 1) ? step_counter : (i + 1) * per_step_value;

                double one_sum = 0;

                for (var j = startStep; j < endStep; j++)
                {
                    double x1 = a + j * step;
                    double x2 = x1 + step;
                    one_sum += (function(x1) + function(x2)) / 2 * step;
                }

                OneThreadSums[i] = one_sum;
            });
            var answer = OneThreadSums.Sum();

            return answer;
        }
    }
}