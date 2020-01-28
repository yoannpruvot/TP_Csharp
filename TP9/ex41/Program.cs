using System;

namespace ex41
{
    public interface IAnneau<T>
    {
        T Ajouter(T x); // renvoie la somme de l’objet courant et de x
        T MultiplierPar(T x); // renvoie le produit (objet courant)*x
        T Oppose(); // renvoie l’opposé de l’objet courant
        T Inverse(); // renvoie l’inverse de l’objet courant
    }
    public struct DoubleA : IAnneau<DoubleA>{
        double valeur;
        public DoubleA(double d){this.valeur = d;}
        public DoubleA Ajouter(DoubleA x){return(valeur+x);}
        public DoubleA MultiplierPar(DoubleA x){return(valeur*x);}
        public DoubleA Oppose(){return this.MultiplierPar(-1);}
        public DoubleA Inverse(){return(1/valeur);}
        public static implicit operator double(DoubleA x){return x.valeur;}
        public static implicit operator DoubleA(double x)
        {
            DoubleA y;
            y.valeur = x;
            return y;
        }
        public override string ToString()
        {
            return valeur.ToString();
        }
    }
    class FractionA : IAnneau<FractionA>
    {
        public int Numerateur;
        public int Denominateur;
        public FractionA(){this.Numerateur = 0; this.Denominateur = 1;}
        public FractionA(int n, int d){this.Numerateur = n; this.Denominateur = d;} 
        public FractionA(string n_str, string d_str)
        {
            this.Numerateur = int.Parse(n_str);
            this.Denominateur = int.Parse(d_str);
        }
        public override string ToString()
        {
            return String.Format($"{this.Numerateur}/{this.Denominateur}");
        }
        /*public string dev_decimal(int d)
        {
            int result = (Integer.Pow(10,d) * this.Numerateur) / this.Denominateur;
            string result_string = result.ToString();
            return String.Format($"0{result_string.Substring(0, result_string.Length - d)},{result_string.Substring(result_string.Length - d)}");
        }*/
        public FractionA Ajouter(FractionA f)
        {
            return new FractionA(this.Numerateur*f.Denominateur + this.Denominateur*f.Numerateur, this.Denominateur*f.Denominateur);
        }
        /*public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerateur*f2.Denominateur - f1.Denominateur*f2.Numerateur, f1.Denominateur*f2.Denominateur);
        }*/
        public FractionA MultiplierPar(FractionA f)
        {
            return new FractionA(this.Numerateur*f.Numerateur, this.Denominateur*f.Denominateur);
        }
        /*public static Fraction operator /(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerateur*f2.Denominateur, f1.Denominateur*f2.Numerateur);
        }*/
        public FractionA Oppose(){return new FractionA(this.Numerateur*(-1), this.Denominateur);}
        public FractionA Inverse(){return new FractionA(this.Denominateur, this.Numerateur);}
    }
        
    public class Matrice<T> : IAnneau<Matrice<T>> where T: IAnneau<T>, new()
    {
        private T[,] elts;
        public int NbLig{ get; private set; }
        public int NbCol{ get; private set; }
        public Matrice(int nbLig,int nbCol){
            elts = new T[nbLig, nbCol];
            NbLig=nbLig;
            NbCol = nbCol;
        }
        public T this[int i, int j]{
            set{elts [i-1, j-1] = value;}
            get{return elts[i-1,j-1];}
        }
        public Matrice<T> Ajouter(Matrice<T> M){
            Matrice<T> A = new Matrice<T> (NbLig,NbCol);
            for (int i=1; i<=NbLig; i++) {
                for (int j=1; j<=NbCol; j++) {
                    A [i, j]=this [i, j].Ajouter( M[i, j]);
                }
            }
            return A;
        }
        public Matrice<T> MultiplierPar(Matrice<T> M){
            Matrice<T> A = new Matrice<T> (NbLig,M.NbCol);
            for (int i=1; i<=NbLig; i++) {
                for (int j=1; j<=M.NbCol; j++) {
                    A [i, j] = new T ();
                    for (int k=1; k<=NbLig; k++) {
                        A[i, j] = A[i, j].Ajouter (this [i, k].MultiplierPar (M[k, j]));
                    }
                }
            }
            return A;
        }
        public Matrice<T> Oppose(){
            Matrice<T> A = new Matrice<T> (NbLig,NbCol);
            for (int i=1; i<=NbLig; i++){
                for (int j=1; j<=NbCol; j++){
                    A[i,j] = new T();
                    A[i,j] = this[i,j].Oppose();
                }
            }
            return A;
        }
        public Matrice<T> Inverse(){return this;}
        public override string ToString()
        {
            string str_mat="";
            for (int i=0; i<this.NbLig; i++){
                for (int j=0; j<NbCol; j++){
                    str_mat = str_mat + this[i+1,j+1] + " ";
                }
                str_mat = str_mat + "\n";
            }
            return str_mat;
        }
        public Matrice<T> Cofacteur(Matrice<T> M)
        {
            Matrice<T> C = new Matrice<T>(M.NbLig,M.NbCol);
            for(int i=1; i<=M.NbLig; i++)
            {
                for(j=1; j<=M.NbCol; j++)
                {
                    C[i,j] = new T();
                    Matrice<T> M_bis = new Matrice<T>(M.NbLig-1,M.NbCol-1);
                    for(int k=1; k<=M_bis.NbLig; k++){
                        for(int l=1; l<=M_bis.NbCol; l++){
                            
                        }
                    }
                    if((i+j)%2 == 0)
                    {
                        C[i,j] = M_bis.Determinant(M_bis);
                    }
                    else 
                    {
                        C[i,j] = M_bis.Determinant(M_bis).Oppose();
                    }
                    
                }
            }
            return C;
        }
        
        public T Determinant(Matrice<T> M)
        {


            /*if (M.NbCol==1){
                return M[1,1];
            }
            T det = new T();
            for (int i=1; i<= M.NbLig; i++){
                Matrice<T> M_bis = new Matrice<T>(M.NbLig-1,M.NbCol-1);
                for(int j=1; j<=M_bis.NbLig; j++){
                    for(int k=1; k<=M_bis.NbCol; k++){
                        if(i!=k){
                            M_bis[j,k]=M[j+1,k];
                        }
                    }
                }
                T det_bis = Determinant(M_bis);
                if((i+1)%2!=0){
                    det = det.Ajouter( det_bis.MultiplierPar(M[1,i]).Oppose());
                }
                else {
                    det = det.Ajouter( det_bis.MultiplierPar(M[1,i]));
                }
            }
            return det;*/
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            /*int d=3;
            Matrice<DoubleA> A = new Matrice<FractionA>(d,d);
            for (int i=1; i<=d; i++){
                for (int j=1; j<=d; j++){
                    A[i,j]= new FractionA(1 , i+j-1);
                }
            }*/
            Matrice<DoubleA> test = new Matrice<DoubleA>(2,2);
            test[1,1]= 1; 
            test[1,2]= 2;
            //test[1,3]= 3; 
            test[2,1]= 3; 
            test[2,2]= 4;
            //test[2,3]= 6;
            //test[3,1]= 3;
            //test[3,2]= 4;
            //test[3,3]= 5; 
            DoubleA det = new DoubleA(0);
            det = test.Determinant(test);
            Console.WriteLine(det);
            //FractionA f = new FractionA(3,2);
            //Console.WriteLine(f.MultiplierPar(f));
        }
    }
}


/*Matrice<DoubleA> test = new Matrice<DoubleA>(2,2);
            test[1,1]= 1.1; 
            test[1,2]= 1.2; 
            test[2,1]= 1.3; 
            test[2,2]= 1.4; 
            Console.WriteLine(test);*/