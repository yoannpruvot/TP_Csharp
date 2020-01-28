using System;

namespace ex24
{
    public struct Temps{ 
        public int minutes; 
        public Temps(int hh, int mm){ this.minutes=60*hh+mm; } 
        public Temps(int min){this.minutes=min;}
        public readonly int Minute{
            get{return this.minutes%60;}
        }
        public readonly int Heure{
            get{return this.minutes/60;}
        }
        public override string ToString()
        {
            return String.Format("{0:00}:{1:00} ", this.Heure, this.Minute); 
        } 
        public static Temps operator +(Temps t1, Temps t2)
        {
            return new Temps(t1.minutes + t2.minutes);
        }
        public static Temps operator -(Temps t1, Temps t2)
        {
            return new Temps(t1.minutes - t2.minutes);
        }
        public static implicit operator Temps(int t_int){
            Temps t = new Temps(t_int);
            return t;
        }
        public static explicit operator int(Temps t){
            int t_int = t.minutes;
            return t_int;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Temps t1 = new Temps(9,30); 
            Temps t2 = t1; 
            t1.minutes= 100; 
            Console.WriteLine("t1={0} and t2={1}",t1,t2);
        }
    }
}
