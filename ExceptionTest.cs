using System;
using System.Diagnostics;

namespace PerformanceTests
{
    class ExceptionTest : ITest
    {
        public void TestRun()
        {
            string result = "X";
            int repeat = 100;

            Console.WriteLine(GetType().Name);
            Console.WriteLine($"Repetition: {repeat:n0}\n");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            for (int i = 0; i < repeat; i++)
            {
                try
                {
                    int.Parse(result);
                }
                catch (Exception)
                {

                }
            }
            Console.WriteLine($"Try Catch Check: {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            for (int i = 0; i < repeat; i++)
            {
                int.TryParse(result, out int number);
            }
            Console.WriteLine($"TryParse Check: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
