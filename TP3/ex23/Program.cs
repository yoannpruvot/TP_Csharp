using System;

namespace ex23
{
    class Vecteur
    {
        private double[] elts;
        public Vecteur(int dim)
        {
            this.elts = new double[dim];
        }
        public int Length
        {
            get {return this.elts.Length;}
        }
        public virtual double this[int i]
        {
            get{ if((0 < i) & (i<this.Length + 1)) {
                return this.elts[i-1];
                }
                else {
                    Console.WriteLine("Index out of range.");
                    return 0;
                }
            }
            set{
                this.elts[i-1]=value;
            }
        }
        public static double prod_scal(Vecteur vect1, Vecteur vect2)
        {
            if (vect1.Length == vect2.Length)
            {
                double prod=0;
                for(int i=0; i<vect1.Length; i++)
                {
                    prod += vect1.elts[i] * vect2.elts[i];
                }
                return prod;
            }
            else 
            {
                Console.WriteLine("Vectors dimensions are differents.");
                return 0;
            }
        }
        public static Vecteur Somme(Vecteur vect1, Vecteur vect2)
        {
            Vecteur somme_vect = new Vecteur(vect1.Length);
            for (int i=0; i < vect1.Length; i++)
            {
                if (vect1.Length == vect2.Length)
                {
                    somme_vect.elts[i] = vect1[i+1] + vect2[i+1];
                }
                else 
                {
                    Console.WriteLine("Vectors dimensions are differents.");
                    break;
                }
            }
            return somme_vect;
        }
        public static Vecteur Produit(Vecteur vect, double a)
        {
            Vecteur prod = new Vecteur(vect.Length);
            for(int i=0; i<vect.Length; i++)
            {
                prod.elts[i] = vect[i+1]*a;
            }
            return prod;
        }
        public static void GramSchmidt(Vecteur[] a) 
        {
            Vecteur[] b = new Vecteur[a.Length];
            b[0] = new Vecteur(a[0].Length);
            b[0]=Vecteur.Produit(a[0],1/Math.Sqrt(Vecteur.prod_scal(a[0],a[0])));
            for(int i=1; i<a.Length; i++)
            {
                Vecteur u = new Vecteur(a[0].Length);
                b[i] = new Vecteur(a[0].Length);
                Vecteur somme = new Vecteur(a[0].Length);
                for (int j=0; j<i; j++)
                {
                    somme = Vecteur.Somme(somme, Vecteur.Produit(b[j],Vecteur.prod_scal(a[i],b[j]))); 
                } 
                u = Vecteur.Somme(a[i], Vecteur.Produit(somme,-1)) ;
                b[i] = Vecteur.Produit(u,1/Math.Sqrt(Vecteur.prod_scal(u,u)));
            }
            for(int i=0; i<a.Length; i++)
            {
                a[i]=b[i];
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            /*Vecteur vect1 = new Vecteur(3);
            vect1[1]=1;
            vect1[2]=2;
            vect1[3]=3;
            Vecteur vect2 = new Vecteur(3);
            vect2[1]=2;
            vect2[2]=3;
            vect2[3]=4;*/
            int d=5;
            Vecteur[] vect3 = new Vecteur[d];
            for(int i=0; i<d; i++)
            {
                vect3[i] = new Vecteur(d);
                for(int j=1; j<=d; j++)
                {
                    vect3[i][j]=1/((double)i+(double)j);
                }
            }
            for(int i=0; i<d; i++)
            {
                Console.WriteLine($"{vect3[i][1]} , {vect3[i][2]} , {vect3[i][3]}, {vect3[i][4]}, {vect3[i][5]}");           
            }
            Vecteur.GramSchmidt(vect3);
            for(int i=0; i<d-1; i++)
            {
                //Console.WriteLine($"{vect3[i][1]} , {vect3[i][2]} , {vect3[i][3]}, {vect3[i][4]}, {vect3[i][5]}");
                Console.WriteLine($"{Vecteur.prod_scal(vect3[i],vect3[i+1])}");
            }
        }
    }
}
