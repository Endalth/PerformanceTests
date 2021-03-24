using System;
using System.Diagnostics;

namespace PerformanceTests
{
    class CopyToTest : ITest
    {
        public void TestRun()
        {

            int repeat = 250_000_000;
            byte[] first = new byte[repeat];
            byte[] second = new byte[repeat];

            Console.WriteLine(GetType().Name);
            Console.WriteLine($"Array Size: {repeat:n0}\n");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            for (int i = 0; i < repeat; i++)
            {
                second[i] = first[i];
            }
            Console.WriteLine($"Manual Copy: {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            first.CopyTo(second, 0);
            Console.WriteLine($"CopyTo: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
