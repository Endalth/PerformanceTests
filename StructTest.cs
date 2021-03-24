using System;
using System.Diagnostics;

namespace PerformanceTests
{
    class StructTest : ITest
    {
        public void TestRun()
        {
            int repeat = 100_000_000;

            Console.WriteLine(GetType().Name);
            Console.WriteLine($"Repetition: {repeat:n0}\n");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            for (int i = 0; i < repeat; i++)
            {
                new PointStruct(5,6);
            }
            Console.WriteLine($"Struct: {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            for (int i = 0; i < repeat; i++)
            {
                new PointClass(5, 6);
            }
            Console.WriteLine($"Class: {stopwatch.ElapsedMilliseconds}ms");
        }
    }

    struct PointStruct
    {
        public int x;
        public int y;

        public PointStruct(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class PointClass
    {
        public int x;
        public int y;

        public PointClass(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
