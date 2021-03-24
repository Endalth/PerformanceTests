using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PerformanceTests
{
    class ListTest : ITest
    {
        public void TestRun()
        {
            int size = 100_000_000;

            Console.WriteLine(GetType().Name);
            Console.WriteLine($"Array Size: {size:n0}\n");

            int[] array = new int[size];
            List<int> list = new List<int>(size);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Restart();
            for (int i = 0; i < size; i++)
            {
                array[i] = 1;
            }
            Console.WriteLine($"Array: {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            for (int i = 0; i < size; i++)
            {
                list.Add(1);
            }
            Console.WriteLine($"List: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
