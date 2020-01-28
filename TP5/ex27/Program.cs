using System;
using System.Collections;

namespace ex27
{
    public interface IEnumerable
    { 
        IEnumerator GetEnumerator();
    }
    class CompteARebours : IEnumerator
    { 
        int count=11; 
        public bool MoveNext()
        {
            return count++ >0;
        } 
        public object Current
        {
            get{return count;}
        } 
        public void Reset(){count=11;}
    }
    class Program
    {
        public static void Affiche(object ob) 
        { 
            IEnumerable obEnu = ob as IEnumerable; 
            if (obEnu != null) 
            { 
                foreach (object x in obEnu) { Affiche (x); } 
            } 
            else Console.Write(ob+ " "); 
        }
        
        static void Main(string[] args)
        {
            ArrayList test = new ArrayList();
            test.Add(test);
            Affiche(test);
        }
    }
}
