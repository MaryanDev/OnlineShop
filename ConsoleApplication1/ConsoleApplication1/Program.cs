using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass m = new MyClass();
            Console.WriteLine(m.Field);//10

            Type t = m.GetType();
            t.GetField("_field",  BindingFlags.NonPublic | BindingFlags.Instance).SetValue(m, 15);

            Console.WriteLine(m.Field);//15
        }
    }

    class MyClass
    {
        private int _field = 10;

        public int Field { get { return _field; } }
    }
}
