using System;
using System.Diagnostics;

namespace PerformanceTests
{
    class SwapTest : ITest
    {
        public void TestRun()
        {
            int[] array = { 1, 2, 3 };
            int repeat = 100_000_000;

            Console.WriteLine(GetType().Name);
            Console.WriteLine($"Repetition: {repeat:n0}\n");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            for (int i = 0; i < repeat; i++)
            {
                int temp = array[0];
                array[0] = array[1];
                array[1] = temp;
            }
            Console.WriteLine($"Inline Swap: {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            for (int i = 0; i < repeat; i++)
            {
                Swap(array);
            }
            Console.WriteLine($"Method Swap: {stopwatch.ElapsedMilliseconds}ms");
        }

        public void Swap(int[] array)
        {
            int temp = array[0];
            array[0] = array[1];
            array[1] = temp;
        }
    }
}
