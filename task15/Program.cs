using System.Diagnostics;
using ScottPlot;
using task14;

namespace task15
{
    class Program
    {
        static void Main()
        {
            double a = -100;
            double b = 100;
            Func<double, double> sinFunction = Math.Sin;
            double[] steps = { 1e-1, 1e-2, 1e-3, 1e-4, 1e-5, 1e-6 };
            double fix_step = 1e-4;

            double optimalStep = FindOptimalStep(a, b, sinFunction, steps, fix_step);

            Stopwatch sw = Stopwatch.StartNew();
            double singleThreadResult = OneThreadIntegral(a, b, sinFunction, optimalStep);
            sw.Stop();
            double singleThreadTime = sw.Elapsed.TotalMilliseconds;

            int[] threadCounts = { 1, 2, 4, 8, 16, 32 };
            int runs = 5;
            var results = TestThreadCounts(a, b, sinFunction, optimalStep, threadCounts, runs);

            var bestResult = results.OrderBy(r => r.AverageTime).First();

            double improvement = singleThreadTime / bestResult.AverageTime;

            var plt = new ScottPlot.Plot();
            plt.Add.Scatter(results.Select(r => r.AverageTime).ToArray(), threadCounts.Select(t => (double)t).ToArray());
            plt.XLabel("Время вычисления функции Solve (мс)");
            plt.YLabel("Количество потоков");
            plt.Title("Время выполнения от числа потоков");
            string path = @"C:\Users\User\PracticeSummer_2025\task15\graph.png";
            plt.SavePng(path, 600, 400);

            using (StreamWriter writer = new StreamWriter(@"C:\Users\User\PracticeSummer_2025\task15\results.txt"))
            {
                writer.WriteLine($"Оптимальный шаг: {optimalStep}");
                writer.WriteLine($"Однопоточное время: {Math.Round(singleThreadTime, 2)} мс");
                writer.WriteLine($"Лучшее многопоточное время: {Math.Round(bestResult.AverageTime, 2)} мс при {bestResult.Threads} потоках");
                writer.WriteLine($"Ускорение: {Math.Round(improvement, 2)}%");
            }
        }

        static double FindOptimalStep(double a, double b, Func<double, double> function, double[] steps, double accuracy)
        {
            double optimalStep = steps[0];
            bool found = false;

            foreach (double step in steps)
            {
                double result = OneThreadIntegral(a, b, function, step);
                double error = Math.Abs(result);

                if (error <= accuracy)
                {
                    optimalStep = step;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                optimalStep = steps.Last();
            }

            return optimalStep;
        }

        static List<ThreadTestResult> TestThreadCounts(double a, double b, Func<double, double> function, 
            double step, int[] threadCounts, int runs)
        {
            var results = new List<ThreadTestResult>();

            foreach (int threads in threadCounts)
            {
                double totalTime = 0;

                for (int i = 0; i < runs; i++)
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    DefiniteIntegral.Solve(a, b, function, step, threads);
                    sw.Stop();
                    totalTime += sw.Elapsed.TotalMilliseconds;
                }

                results.Add(new ThreadTestResult
                {
                    Threads = threads,
                    AverageTime = totalTime / runs
                });
            }

            return results;
        }
        static double OneThreadIntegral(double a, double b, Func<double, double> function, double step)
        {
            double sum = 0.0;
            double x = a;

            while (x < b)
            {
                double nextX = Math.Min(x + step, b);
                sum += (function(x) + function(nextX)) * 0.5 * (nextX - x);
                x = nextX;
            }


            return sum;
        }
    }
    class ThreadTestResult
    {
        public int Threads { get; set; }
        public double AverageTime { get; set; }
    }
}

