using System;
using System.Diagnostics;

namespace PerformanceTests
{
    class SwitchTest : ITest
    {
        public void TestRun()
        {
            int repeat = 100_000_000;
            int value = 5;

            Console.WriteLine(GetType().Name);
            Console.WriteLine($"Repetition: {repeat:n0}\n");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            for (int i = 0; i < repeat; i++)
            {
                switch (value)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Access Last Switch Case: {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            for (int i = 0; i < repeat; i++)
            {
                if (value == 0)
                {

                }
                else if (value == 1)
                {

                }
                else if (value == 2)
                {

                }
                else if (value == 3)
                {

                }
                else if (value == 4)
                {

                }
                else if (value == 5)
                {

                }

            }
            Console.WriteLine($"Access Last If: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
