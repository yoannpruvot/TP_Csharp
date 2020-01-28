using System;

namespace TP2
{
    class Program
    {

        static int multiplication(int nombre){
            string str_nombre = nombre.ToString();
            int taille_nombre = str_nombre.Length;
            int new_nombre = 1;
            for (int i=0; i<taille_nombre; i++){
                new_nombre = new_nombre * (int)Char.GetNumericValue(str_nombre[i]) ;
            }
            return new_nombre;

        } 
        static void Main(string[] args)
        {
            Console.WriteLine("Entrez deux nombres nombres");
            string str_nombre1 = Console.ReadLine();
            string str_nombre2 = Console.ReadLine();
            int nombre1 = int.Parse(str_nombre1);
            int nombre2 = int.Parse(str_nombre2);
            for (int i=0; nombre1 + i<nombre2; i++){
                int nombre_suite=nombre1+i;
                Console.Write($"La suite multiplicative est: {nombre_suite}");
                while(nombre_suite>9){
                    nombre_suite = multiplication(nombre_suite);
                    Console.Write($", {nombre_suite}");
                }
                Console.Write("\n");
            }          
        }
    }
}


/*
            Exercice 11:

            Console.WriteLine("entrez la taille du tableau");
            int n= int.Parse(Console.ReadLine());
            Random gen=new Random();
            int[] tab= new int [n];
            Console.WriteLine("Le tableau est:");
            for (int i=0; i<n; i++){ 
                tab[i]=gen.Next(0,10);
                Console.WriteLine(tab[i]);
            }
            for (int i=n; i>0; i--){
                for (int j=1; j<i; j++){
                    if (tab[j-1]>tab[j]){
                        int temp=tab[j-1];
                        tab[j-1]=tab[j];
                        tab[j]=temp;
                    }
                }
            }
            Console.WriteLine("Le nouveau tableau est:");
            for (int i=0; i<n; i++){ 
                Console.WriteLine(tab[i]);
            }

___________________________________________________________________

            exercice 12:

            Console.Write("Entrez un nombre :");
            int N = int.Parse(Console.ReadLine());
            int [] tab_nb_premiers = new int [N];
            int i=2; 
            tab_nb_premiers[0]=1;
            tab_nb_premiers[1]=2;
            int nb_test=3;
            while(i<N){ 
                bool test = true;
                for(int k=1; k<i; k++){
                    if(nb_test%tab_nb_premiers[k]==0){
                        test=false;
                        break;
                    };
                }
                if (test){
                    tab_nb_premiers[i]= nb_test;
                    i++;
                }
                nb_test++;
            }
            Console.WriteLine("Le tableau est:");
            for (int temp=0; temp<N; temp++){ 
                Console.WriteLine(tab_nb_premiers[temp]);
            }
 */


 /*
    tentative exo 14:
            static void permutation(list<char> liste, int taille)
        {
            int taille_factoriel=1;
            for (int i=0; i<taille; ++i){
                taille_factoriel*=i;
            }
            List<List<char>> liste_permutations = new List<List<char>>() ;
            List<char> liste_court=new List<char>();
            liste_court=liste;
            liste_court.RemoveAt(taille);
            permutation(liste_court, taille-1)
        }
  */