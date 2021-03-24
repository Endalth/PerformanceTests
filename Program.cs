using System;
using System.Collections.Generic;

/*
 * For Optimization IF POSSIBLE:
 * DON'T use Methods. --> SwapTest
 * DON'T use If when you can solve the problem without it. --> IfTest
 * DON'T use Foreach with Arrays. For is faster thanks to the slight optimization of caching the size of the array. --> ForeachArrayTest
 * DON'T use Foreach with Lists. For is faster thanks to the slight optimization of caching the size of the list. --> ForeachListTest
 * DO    use 1-Dimensional Arrays. Flatten 2-Dimensional Arrays if you can. --> ArrayTest
 * DO    use Switch if you have more than one Else If. --> SwitchTest
 * DO    use Array instead of List. --> ListTest
 * DO    use StringBuilder. --> StringTest
 * DO    use TryParse or check values in another way instead of relying on Try-Catch --> ExceptionTest
 * DO    use Struct. --> StructTest
 * DO    use CopyTo. --> CopyToTest
 * DO    use Dynamic CIL if you can't use direct instantiation or directly access property. --> InstantiationTest / PropertyAccessTest
 * DO    use XOR comparison if you are checking the equality of two int arrays. --> IntArrayEqualityTest
 * 
 * If unsure always test every variation of the code for performance.
 */

namespace PerformanceTests
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ITest> tests = new List<ITest>();
            tests.Add(new SwapTest());
            tests.Add(new IfTest());
            tests.Add(new ArrayTest());
            tests.Add(new SwitchTest());
            tests.Add(new ForeachArrayTest());
            tests.Add(new ForeachListTest());
            tests.Add(new ListTest());
            tests.Add(new StringTest());
            tests.Add(new ExceptionTest());
            tests.Add(new StructTest());
            tests.Add(new CopyToTest());
            tests.Add(new InstantiationTest());
            tests.Add(new PropertyAccessTest());
            tests.Add(new IntArrayEqualityTest());

            foreach (ITest test in tests)
            {
                test.TestRun();
                Console.WriteLine($"\n{new string('-', 30)}");
            }

            Console.WriteLine("Finish");
            Console.ReadKey();
        }
    }
}
