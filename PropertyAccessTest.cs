using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;

namespace PerformanceTests
{
    class PropertyAccessTest : ITest
    {
        public delegate object PropertyGetDelegate(object obj);
        public delegate void PropertySetDelegate(object obj, object value);
        public void TestRun()
        {
            int repeat = 10_000_000;

            Console.WriteLine(GetType().Name);
            Console.WriteLine($"Repetition: {repeat:n0}\n");

            Stopwatch stopwatch = new Stopwatch();
            var sb = new System.Text.StringBuilder("Test");

            stopwatch.Restart();
            PropertyInfo pi = sb.GetType().GetProperty("Length");
            for (int i = 0; i < repeat; i++)
            {
                var length = pi.GetValue(sb);
                if (!4.Equals(length))
                    throw new InvalidOperationException($"Invalid length {length} returned");
            }
            Console.WriteLine($"Reflection: {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            var getter = GetPropertyGetter("System.Text.StringBuilder", "Length");
            for (int i = 0; i < repeat; i++)
            {
                var length = getter(sb);
                if (!4.Equals(length))
                    throw new InvalidOperationException($"Invalid length {length} returned");
            }
            Console.WriteLine($"Dynamic CIL: {stopwatch.ElapsedMilliseconds}ms");

            stopwatch.Restart();
            for (int i = 0; i < repeat; i++)
            {
                var length = sb.Length;
                if (!4.Equals(length))
                    throw new InvalidOperationException($"Invalid length {length} returned");
            }
            Console.WriteLine($"Direct: {stopwatch.ElapsedMilliseconds}ms");
        }

        private PropertyGetDelegate GetPropertyGetter(string typeName, string propertyName)
        {
            Type t = Type.GetType(typeName);
            PropertyInfo pi = t.GetProperty(propertyName);
            MethodInfo getter = pi.GetGetMethod();

            DynamicMethod dm = new DynamicMethod("GetValue", typeof(object), new Type[] { typeof(object) }, typeof(object), true);
            ILGenerator lgen = dm.GetILGenerator();
            lgen.Emit(OpCodes.Ldarg_0);
            lgen.Emit(OpCodes.Call, getter);

            if (getter.ReturnType.GetTypeInfo().IsValueType)
                lgen.Emit(OpCodes.Box, getter.ReturnType);

            lgen.Emit(OpCodes.Ret);

            return dm.CreateDelegate(typeof(PropertyGetDelegate)) as PropertyGetDelegate;
        }

        private PropertySetDelegate GetPropertySetter(string typeName, string propertyName)
        {
            Type t = Type.GetType(typeName);
            PropertyInfo pi = t.GetProperty(propertyName);
            MethodInfo setter = pi.GetSetMethod(false);

            DynamicMethod dm = new DynamicMethod("SetValue", typeof(void), new Type[] { typeof(object), typeof(object) }, typeof(object), true);
            ILGenerator lgen = dm.GetILGenerator();
            lgen.Emit(OpCodes.Ldarg_0);
            lgen.Emit(OpCodes.Ldarg_1);
            
            Type parameterType = setter.GetParameters()[0].ParameterType;

            if (parameterType.GetTypeInfo().IsValueType)
                lgen.Emit(OpCodes.Unbox_Any, parameterType);

            lgen.Emit(OpCodes.Call, setter);
            lgen.Emit(OpCodes.Ret);

            return dm.CreateDelegate(typeof(PropertySetDelegate)) as PropertySetDelegate;
        }
    }
}
