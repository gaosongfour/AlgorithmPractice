using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
    public class CSharpLearning
    {
        public void Run()
        {
            B b = new B();
        }
    }

    public class A
    {
        public A(string text)
        {
            var tt = Singleton.Instance;
            var rr = Singleton.Instance;
        }
     }

    public class B
    {
        static A a1=new A("a1");
        A a2 = new A("a2");

        static  B()
        {
            a1 = new A("a3");
        }

        public B()
        {
            a2 = new A("a4");
        }
    }

    public sealed class Singleton
    {
        private Singleton()
        {
            Console.WriteLine("init singleton");
        }

        private static Singleton instance = new Singleton();
        public static Singleton Instance
        {
            get { return instance; }
        }

        
    }
}
