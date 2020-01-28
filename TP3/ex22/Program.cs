using System;
using System.Collections.Generic;

namespace ex22
{
    class Decomposition
    {
        public int nombre;

        public int un_fact_decomposition(int n)
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
        public List<int> tab_fact_decomposition(int n)
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
        public int[] fact_premiers
        {
            get
            {
                List<int> liste_fact = new List<int>();
                liste_fact = tab_fact_decomposition(this.nombre);
                int[] fact_premiers = new int[liste_fact.Count];
                for(int i=0; i<liste_fact.Count; i++)
                {
                    fact_premiers[i] = liste_fact[i];
                }
                return fact_premiers;
            }
        }
    

    }
    class Program
    {
        static void Main(string[] args)
        {
            Decomposition N = new Decomposition();
            Console.WriteLine("Entrez un nombre");
            N.nombre = int.Parse(Console.ReadLine());
            for (int i=0; i<N.fact_premiers.Length; i++)
            {
                Console.Write(N.fact_premiers[i]+ " ");
            }
        }
    }
}
