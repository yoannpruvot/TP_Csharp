using System;

namespace ex29
{
    public struct Pair<T, U> 
    { 
        public T Fst 
        { 
            get; 
            private set; 
        } 
        public U Snd 
        { 
            get; 
            private set; 
        } 
        public Pair(T fst, U snd) : this() { Fst=fst; Snd=snd; } 
        public override string ToString() 
        { 
            return "[" + Fst + "," + Snd + "]";
        }
        public static Pair<U,T> swap ( Pair<T,U> p)
        {
            var p2 = new Pair<U,T>();
            p2.Snd = p.Fst ; 
            p2.Fst = p.Snd ;
            return p2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Pair<int,string>(5,"abc");
            var test_swap = new Pair <string, int>();
            test_swap = Pair<int,string>.swap(test);
            Console.WriteLine(test_swap);

        }
    }
}
