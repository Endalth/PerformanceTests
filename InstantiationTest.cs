using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;

namespace PerformanceTests
{
    class InstantiationTest : ITest
    {
        public delegate object ConstructorDelegate();
        public void TestRun()
        {
            int repeat = 10_000_000;

            Console.WriteLine(GetType().Name);
            Console.WriteLine($"Repetition: {repeat:n0}\n");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            var type = Type.GetType("System.Text.StringBuilder");
            for (int i = 0; i < repeat; i++)
            {
                var obj = Activator.CreateInstance(type);
                if (obj.GetType() != typeof(System.Text.StringBuilder))
                    throw new InvalidOperationException("Constructed object is not a StringBuilder");
            }
            Console.WriteLine($"Reflection: {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            var constructor = GetConstructor("System.Text.StringBuilder");
            for (int i = 0; i < repeat; i++)
            {
                var obj = constructor();
                if (obj.GetType() != typeof(System.Text.StringBuilder))
                    throw new InvalidOperationException("Constructed object is not a StringBuilder");
            }
            Console.WriteLine($"Dynamic CIL: {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            for (int i = 0; i < repeat; i++)
            {
                var obj = new System.Text.StringBuilder();
                if (obj.GetType() != typeof(System.Text.StringBuilder))
                    throw new InvalidOperationException("Constructed object is not a StringBuilder");
            }
            Console.WriteLine($"Direct: {stopwatch.ElapsedMilliseconds}ms");
        }

        ConstructorDelegate GetConstructor(string typeName)
        {
            Type t = Type.GetType(typeName);
            ConstructorInfo ctor = t.GetConstructor(new Type[0]);

            string methodName = t.Name + "Ctor";
            DynamicMethod dm = new DynamicMethod(methodName, t, new Type[0], typeof(Activator));
            ILGenerator lgen = dm.GetILGenerator();
            lgen.Emit(OpCodes.Newobj, ctor);
            lgen.Emit(OpCodes.Ret);

            ConstructorDelegate creator = (ConstructorDelegate)dm.CreateDelegate(typeof(ConstructorDelegate));

            return creator;
        }
    }
}
