using System;
using System.Numerics;
using System.Collections;

namespace ex26
{
    class Fraction : IComparable
    {
        public BigInteger Numerateur;
        public BigInteger Denominateur;
        /*{
            get{return this.Denominateur;}
            set{
                this.Denominateur = value;
                if (value!=0){
                    this.Denominateur = value;
                }
                else{ 
                    Console.WriteLine("Erreur: Denominateur nul.");
                    this.Denominateur = -1;
                }
            }
        } */
        public Fraction(BigInteger n, BigInteger d){this.Numerateur = n; this.Denominateur = d;} 
        public Fraction(string n_str, string d_str)
        {
            this.Numerateur = BigInteger.Parse(n_str);
            this.Denominateur = BigInteger.Parse(d_str);
        }
        public override string ToString()
        {
            return String.Format($"{this.Numerateur} / {this.Denominateur}");
        }
        public string dev_decimal(int d)
        {
            BigInteger result = (BigInteger.Pow((BigInteger)10,d) * this.Numerateur) / this.Denominateur;
            string result_string = result.ToString();
            return String.Format($"0{result_string.Substring(0, result_string.Length - d)},{result_string.Substring(result_string.Length - d)}");
        }
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerateur*f2.Denominateur + f1.Denominateur*f2.Numerateur, f1.Denominateur*f2.Denominateur);
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerateur*f2.Denominateur - f1.Denominateur*f2.Numerateur, f1.Denominateur*f2.Denominateur);
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerateur*f2.Numerateur, f1.Denominateur*f2.Denominateur);
        }
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerateur*f2.Denominateur, f1.Denominateur*f2.Numerateur);
        }
        public static Fraction simplifier(Fraction f)
        {
            BigInteger GOD = BigInteger.GreatestCommonDivisor(f.Numerateur, f.Denominateur);
            return new Fraction(f.Numerateur/GOD, f.Denominateur/GOD);
        }
        public static void approx_racine(Fraction f, int d)
        {
            Fraction y = new Fraction(1,2);
            Fraction test;
            Fraction u;
            int truc=1;
            //Fraction puissance_d = new Fraction((BigInteger)Math.Pow(10,d),1);
            while(truc!=0)
            {
                y = y * (new Fraction(3,1) - f*y*y)/new Fraction(2,1);
                //Console.WriteLine($"L'approximation est : \n{y.dev_decimal(d)}");
                u = (new Fraction(1,1)/(y*y)) - f;
                if((u.Numerateur<0)&(u.Denominateur> 0)|((u.Numerateur>0)&(u.Denominateur<0))){
                    u.Numerateur= (BigInteger)(-1) * u.Numerateur;
                }
                test = u * y;
                BigInteger dix = 10;
                if(test.Numerateur *  BigInteger.Pow(dix,d)/*puissance_d.Numerateur*/<test.Denominateur)
                {
                    truc = 0;
                }
            }
            y=new Fraction(1,1)/y;
            Console.WriteLine($"L'approximation est : \n{y.dev_decimal(d)}");
        }
        public int CompareTo (object f_test1)
        {
            Fraction f_test = (Fraction) f_test1;
            Fraction f = new Fraction(this.Numerateur * f_test.Denominateur, this.Denominateur * f_test.Denominateur);
            f_test.Numerateur = f_test.Numerateur * this.Denominateur;
            f_test.Denominateur = f_test.Denominateur * this.Denominateur;
            if (f.Numerateur < f_test.Numerateur) return -1;
            if (f.Numerateur > f_test.Numerateur) return 1;
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fraction test1 = new Fraction(2 , 1);
            Fraction test2 = new Fraction(2 , 3);
            Fraction test3 = test1 + test2;
            Fraction test3_bis = Fraction.simplifier(test3);
            Console.WriteLine(test3_bis);
            //Fraction.approx_racine(test1, 500);
            ArrayList myAL = new ArrayList();
            myAL.Add(test1);
            myAL.Add(test2);
            myAL.Add(test3_bis);
            //myAL.Sort();
            foreach(Fraction x in myAL) Console.WriteLine(x.ToString());
        }
    }
}
