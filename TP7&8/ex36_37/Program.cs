using System;

namespace ex36
{
    public interface IGenerateur
    {
        double NextDouble();
        IGenerateur Clone();
    }
    public class Gunif : Random, IGenerateur{
        static Random g = new Random();
        public Gunif(int graine) : base(graine){}
        public Gunif() { }
        public IGenerateur Clone()
        {
            return new Gunif(g.Next());
        }
    }
    public class RGauss : Random, IGenerateur{
        static Random g = new Random();
        public RGauss(){}
        public RGauss(int graine) : base(graine){}
        protected override double Sample()
        {
            return (Math.Pow(-2*Math.Log(g.NextDouble()), 0.5) * Math.Cos(2*Math.PI*g.NextDouble()));
        }
        public IGenerateur Clone()
        {
            return new RGauss(g.Next());
        }
    }
    public class MonteCarlo
    {
        public IGenerateur g;
        public MonteCarlo(IGenerateur gen){g=gen;}
        public Tuple<double,double> MoyVarEmpi(Func<double,double> f, ulong n)
        {
            double M=0 ; double V=0 ;
            for(int i=0; (ulong)i<n; i++)
            {
                double x = g.NextDouble();
                M += (1/(double)n)*f(x);
                V += (1/(double)n)*f(x)*f(x);
            }
            V = (V - M*M);
            return new Tuple<double, double>(M,V);
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*Random r = new Random();
            Console.WriteLine( Math.Pow(-2*Math.Log(r.NextDouble()), 0.5) * Math.Cos(2*Math.PI*r.NextDouble()));
            RGauss test = new RGauss();
            for(int i=0; i<10; i++){
                Console.WriteLine(test.NextDouble());
            }*/
            MonteCarlo test_unif = new MonteCarlo(new RGauss());
            ulong N = 10000000;
            //int count = 0;
            Tuple<double,double> test = test_unif.MoyVarEmpi((x=>Math.Abs(x)), N);
            Console.WriteLine("Moyenne "+test.Item1+" Variance "+test.Item2);
            /*Tuple<double,double> test = test_unif.MoyVarEmpi((x=>4/(1+x*x)), N);
            for(int i = 0; i<20; i++)
            {
                Tuple<double,double> test = test_unif.MoyVarEmpi((x=>4/(1+x*x)), N);
                if( (test.Item1 - 1.96 * Math.Pow(test.Item2/(int)N, 0.5)<Math.PI)&(test.Item1 + 1.96 * Math.Pow(test.Item2/(int)N, 0.5)>Math.PI))
                {
                    count++;
                }
            }
            Console.WriteLine(count);*/
        }
    }
}
