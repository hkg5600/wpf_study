using System;

namespace delegateTEST
{
    delegate void Delegate(int sec);
    class ConsoleClass
    {
        
        public static void NamedMethod(int sec)
        {
            Console.WriteLine("{0} sec in NameMethod", sec);
        }
        public static void Main()
        {
            CallBackSample sample = new CallBackSample();

            Delegate test1 = NamedMethod;
            Delegate test2 = sample.Iamcallback;

            test1(10);
            test2(20);
            test2(30);
        }
    }

    public class CallBackSample
    {
        public void Iamcallback(int sec)
        {
            Console.WriteLine("{0} sec in Iamcallback method", sec);
        }
    }
}
