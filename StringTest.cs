using System;
using System.Diagnostics;
using System.Text;

namespace PerformanceTests
{
    class StringTest : ITest
    {
        public unsafe void TestRun()
        {
            string result = "";
            int repeat = 100_000;

            Console.WriteLine(GetType().Name);
            Console.WriteLine($"Repetition: {repeat:n0}\n");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            for (int i = 0; i < repeat; i++)
            {
                result += "*";
            }
            Console.WriteLine($"String Append: {stopwatch.ElapsedMilliseconds}ms");

            result = "";

            stopwatch.Restart();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < repeat; i++)
            {
                stringBuilder.Append("*");
            }
            result = stringBuilder.ToString();
            Console.WriteLine($"StringBuilder Append: {stopwatch.ElapsedMilliseconds}ms");

            result = "";

            stopwatch.Restart();
            var resultChar = new char[repeat];
            fixed (char* fixedPointer = resultChar)
            {
                var pointer = fixedPointer;
                for (int i = 0; i < repeat; i++)
                {
                    *(pointer++) = '*';
                }
            }
            result = new string(resultChar);
            Console.WriteLine($"Pointer Append: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
