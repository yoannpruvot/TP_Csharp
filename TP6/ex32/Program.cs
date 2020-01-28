using System;
using System.Collections.Generic;

namespace ex32
{
    public delegate bool IntPredicate(int x);
    public delegate void IntAction(int x);
    public class IntList : List<int>
    {
        public IntList(params int[] elements) : base(elements) { }
        public void Act(IntAction f) {
        foreach (int i in this)
            f(i);
        }
        public IntList Filter(IntPredicate p) 
        {
            IntList res = new IntList();
            foreach (int i in this)
                if (p(i)) 
                    res.Add(i);
            return res;
        }
    }
    class Program
    {
        // public static void sup25(IntList x)
        // {
        //     return delegate(IntList x){ xs.Filter(x => x>25).Act(Console.WriteLine); };
        // }
        static void Main(string[] args)
        {
            IntList xs = new IntList(12, 26, 33, 2);
            int somme = 0;         
            xs.Act(x => somme+=x);   
            Console.WriteLine(somme);
        }
    }
}
