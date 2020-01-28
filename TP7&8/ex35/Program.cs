using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ex35
{
    class Program
    {
        static private Object verrou = new Object();
        public static void Trier(int[] tab)
        {
            int k = 1;
            int aux;
            while (k>0){
                k = 0;
                for (int i = 0; i < tab.Length - 1;i++)
                {
                    if (tab[i]>tab[i+1])
                    {
                        lock(verrou){
                        aux = tab[i];
                        tab[i] = tab[i + 1];
                        tab[i + 1] = aux;
                        k++;}
                    }
                }
            }
        }
        public static void Trier(int[] tab, int p, int r)
        {
            
        }
        public static Random gen=new Random();
        public static int[] permuAl(int n)
        {
            int[] permu = new int[n];
            for (int i = 0; i < n; i++) { permu[i] = i; }
            int k;
            int aux;
            for (int i = 0; i < n; i++)
            {
                k = gen.Next(0, n - i);
                aux = permu[i];
                permu[i] = permu[i + k];
                permu[i + k] = aux;
            }
            return permu;
        }
        static void Main(string[] args)
        {
            int n=10000;
            int[] tab = permuAl(n);
            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            Task t1 = Task.Run(() => Trier(tab));
            Task t2 = Task.Run(() => Trier(tab));
            t1.Wait(); 
            t2.Wait();
            Console.WriteLine("Temps ecoulé:"+chrono.ElapsedMilliseconds+"ms");
            /*for(int i=0; i<n; i++)
            {
                Console.Write(tab[i]+" ");
            }*/
        }
    }
}
