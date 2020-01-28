using System;

namespace ex31
{

    class Program
    {
        delegate void IntAction(int x);
        public static void PrintInt(int x)
        {
            Console.WriteLine(x);
        }
        static void Perform(IntAction act, int[] arr)
        {
            foreach(int i in arr)
            {
                act(i);
            }
        }
        static void Main(string[] args)
        {
            IntAction act = PrintInt;
            act += Console.WriteLine;
            int[] tab = {1,2,3,4,5};
            Perform(act,tab);


        }
    }
}
