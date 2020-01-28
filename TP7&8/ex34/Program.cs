using System;

namespace ex34
{
    using System;
    using System.Threading.Tasks;
    using System.Diagnostics;
    public class Program
    {
        
        static public long N0 = 1;
        static public long N1 = (long)1e7;
        static public void Run()
        {
            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            Task<double> t1 = Task.Run(() => Somme(N0, N1) );
            t1.Wait();
            Console.WriteLine("Temps ecoulé:"+chrono.ElapsedMilliseconds+"ms");
            Console.WriteLine(t1.Result);
        }
        static double Somme(long n0, long n1)
        {
            double result = 0;
            for(long i = n0; i < n1; i++)
            {
                result += Math.Pow(Math.Cos(i),i);
            }
            return result;
        }
        
        static void Main(string[] args)
        {
            Run();
        }
    }
}
