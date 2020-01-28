using System;
using System.Collections;
using System.Collections.Generic;

namespace ex28
{
    public class ListeFacteursPremiers : IEnumerable 
    { 
        int n;
        class EnumFacteursPremiers : IEnumerator 
        { 
            int nombre;
            private int nombre_test;
            private int nombre_test_prev;
            public EnumFacteursPremiers(int nb){nombre = nb; nombre_test = nb; nombre_test_prev = nb;}
            public bool MoveNext ()
            {
                return ListeFacteursPremiers.un_fact_decomposition(nombre_test_prev) != nombre_test_prev;
            }
            public void Reset ()
            {
                nombre_test = nombre;
                nombre_test_prev = nombre;
            }
            public object Current 
            { 
                get 
                {
                    int facteur = ListeFacteursPremiers.un_fact_decomposition(nombre_test);
                    nombre_test_prev = nombre_test;
                    nombre_test /= facteur;
                    return facteur;
                } 
            }
        }
        public static int un_fact_decomposition(int n)
        {
            int i=1; 
            int reste=1;
            while(reste!=0)
            {   
                i++;
                reste = n%i;
            }
            return i;
        }
       
        public ListeFacteursPremiers (int nb){n = nb;}
        public IEnumerator GetEnumerator () 
        {
            return new EnumFacteursPremiers (n); 
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            ListeFacteursPremiers test = new ListeFacteursPremiers(136);
            foreach (int nb in test)
            {
                Console.Write($"{nb}, ");
            }
        }
    }
}








/*

using System;
using System.Collections;
using System.Collections.Generic;

namespace ex28
{
    public class ListeFacteursPremiers : IEnumerable 
    { 
        int n;
        class EnumFacteursPremiers : IEnumerator 
        { 
            public int nombre;
            public List<int> list_fact_prem;
            int index = -1;
            public EnumFacteursPremiers(int nb)
            {
                this.nombre = nb;
                this.list_fact_prem = ListeFacteursPremiers.tab_fact_decomposition(nb);
            }
            public bool MoveNext ()
            {
                index ++;
                return (index<list_fact_prem.Count);
            }
            public void Reset ()
            {
            index = -1;
            }
            public object Current 
            { 
                get 
                {
                    return list_fact_prem[index];
                } 
            }
        }
        private static int un_fact_decomposition(int n)
        {
            int i=1; 
            int reste=1;
            while(reste!=0)
            {   
                i++;
                reste = n%i;
            }
            return i;
        }
        public static List<int> tab_fact_decomposition(int n)
        {
            List<int> liste_fact = new List<int>();
            liste_fact.Add(n);
            liste_fact.Add(un_fact_decomposition(n));
            int i=1;
            int new_number=n/liste_fact[i];
            while(un_fact_decomposition(new_number)!=new_number)
            {
                liste_fact.Add(un_fact_decomposition(new_number));
                i++;
                new_number=new_number/liste_fact[i];
            }
            liste_fact.Add(un_fact_decomposition(new_number));
            liste_fact.RemoveAt(0);
            return liste_fact;
        }
        public ListeFacteursPremiers (int n)
        {
            this.EnumFacteursPremiers.list_fact_prem = tab_fact_decomposition(n);
        }
        public IEnumerator GetEnumerator () 
        {
            return new EnumFacteursPremiers (n); 
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

 */