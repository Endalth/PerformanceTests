using System;
using System.Diagnostics;

namespace PerformanceTests
{
    class IfTest : ITest
    {
        public void TestRun()
        {
            int result = 0;
            int repeat = 250_000_000;

            Console.WriteLine(GetType().Name);
            Console.WriteLine($"Repetition: {repeat:n0}\n");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            for (int i = 0; i < repeat; i++)
            {
                result++;
            }
            Console.WriteLine($"Without If Check: {stopwatch.ElapsedMilliseconds}ms");

            result = 0;

            stopwatch.Restart();
            for (int i = 0; i < repeat; i++)
            {
                if (i == repeat - 1)
                    result = repeat;
            }
            Console.WriteLine($"With If Check: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
