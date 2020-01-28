using System;

namespace ex38
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
    class MonteCarloP
    {
        public MonteCarlo[] tmc;
        MonteCarloP(IGenerateur gen, int p)
        {
            this.tmc.Length = p;
            for(int i=0; i<p; i++)
            {
                this.tmc[i] = new MonteCarlo(gen.Clone());
            }
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
