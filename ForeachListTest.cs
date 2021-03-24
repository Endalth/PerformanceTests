using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PerformanceTests
{
    class ForeachListTest : ITest
    {
        public void TestRun()
        {
            int size = 250_000_000;
            int temp = 0;

            Console.WriteLine(GetType().Name);
            Console.WriteLine($"Array Size: {size:n0}\n");

            List<int> list = (new int[size]).ToList();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Restart();
            //If list.Count is used instead of size in the condition of the for loop, for loop runs slower than foreach
            for (int i = 0; i < size; i++)
            {
                temp = list[i];
            }
            Console.WriteLine($"Access List Elements with For: {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            foreach (int item in list)
            {
                temp = item;
            }
            Console.WriteLine($"Access List Elements with Foreach: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
