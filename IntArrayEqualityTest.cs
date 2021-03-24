using System;
using System.Diagnostics;

namespace PerformanceTests
{
    class IntArrayEqualityTest : ITest
    {
        public void TestRun()
        {
            Stopwatch stopwatch = new Stopwatch();

            int size = 10_000_000;

            Console.WriteLine(GetType().Name);
            Console.WriteLine($"Array size: {size:n0}\n");

            int[] array = new int[size];
            int[] array2 = new int[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                int n = random.Next(1, 10000);
                array[i] = n;
                array2[size - i - 1] = n;
            }
            int comp = 0;
            int[] tempa = new int[size], tempa2 = new int[size];
            array.CopyTo(tempa, 0);
            array2.CopyTo(tempa2, 0);

            stopwatch.Restart();
            Array.Sort(tempa);
            Array.Sort(tempa2);
            for (int i = 0; i < array.Length; i++)
            {
                if (tempa[i] != tempa2[i])
                    Console.WriteLine("Not Equal");
            }
            Console.WriteLine($"Regular Comparison: {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            for (int i = 0; i < array.Length; i++)
            {
                comp ^= array[i];
                comp ^= array2[i];
            }
            if (comp != 0)
                Console.WriteLine("Not Equal");
            Console.WriteLine($"XOR Comparison: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
