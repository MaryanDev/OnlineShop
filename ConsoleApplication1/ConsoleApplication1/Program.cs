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
            try
            {
                Method2();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.TargetSite);
                Console.ReadLine();
            }
        }

        static void Method1()
        {
            try
            {
                throw new Exception();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        static void Method2()
        {
            try
            {
                Method1();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

}
