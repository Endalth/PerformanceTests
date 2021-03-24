using System;
using System.Diagnostics;

namespace PerformanceTests
{
    class ForeachArrayTest : ITest
    {
        public void TestRun()
        {
            int size = 250_000_000;
            int temp = 0;

            Console.WriteLine(GetType().Name);
            Console.WriteLine($"Array Size: {size:n0}\n");

            int[] array = new int[size];
            Stopwatch stopwatch = new Stopwatch();

            //Without this "warm-up" loop results change according to which comes later
            for (int i = 0; i < size; i++)
            {
                temp = array[i];
            }

            stopwatch.Restart();
            //If array.Length is used instead of size in the condition of the for loop, for loop runs slower than foreach
            for (int i = 0; i < size; i++)
            {
                temp = array[i];
            }
            Console.WriteLine($"Access Array Elements with For: {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            foreach (int item in array)
            {
                temp = item;
            }
            Console.WriteLine($"Access Array Elements with Foreach: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
