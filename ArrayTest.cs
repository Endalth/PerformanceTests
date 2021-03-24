using System;
using System.Diagnostics;

namespace PerformanceTests
{
    class ArrayTest : ITest
    {
        public void TestRun()
        {
            int size = 10_000;
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine(GetType().Name);
            Console.WriteLine($"Array Size: {size * size:n0}\n");

            OneDArray(size, stopwatch);
            FlattenedArray(size, stopwatch);
            TwoDArray(size, stopwatch);
            JaggedArray(size, stopwatch);
        }

        public void OneDArray(int size, Stopwatch stopwatch)
        {
            stopwatch.Restart();
            int[] oneArray = new int[size * size];
            for (int i = 0; i < size * size; i++)
            {
                oneArray[i] = 1;
            }
            Console.WriteLine($"One-D Array: {stopwatch.ElapsedMilliseconds}ms");
        }

        public void FlattenedArray(int size, Stopwatch stopwatch)
        {
            stopwatch.Restart();
            int[] flattened = new int[size * size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int pos = i * size + j;
                    flattened[pos] = 1;
                }
            }
            Console.WriteLine($"Flattened Two-D Array: {stopwatch.ElapsedMilliseconds}ms");
        }

        public void TwoDArray(int size, Stopwatch stopwatch)
        {
            stopwatch.Restart();
            int[,] twoArray = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    twoArray[i, j] = 1;
                }
            }
            Console.WriteLine($"Two-D Array: {stopwatch.ElapsedMilliseconds}ms");
        }

        public void JaggedArray(int size, Stopwatch stopwatch)
        {
            stopwatch.Restart();
            int[][] jaggedArray = new int[size][];
            for (int i = 0; i < size; i++)
            {
                jaggedArray[i] = new int[size];
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    jaggedArray[i][j] = 1;
                }
            }
            Console.WriteLine($"Jagged Array: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
