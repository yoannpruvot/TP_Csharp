using System;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrez un float");
            float a = float.Parse(Console.ReadLine());
            int b = 0;
            while (b<1){
                Console.WriteLine("Entrez un entier positif supérieur à 1");
                b = int.Parse(Console.ReadLine());
            }
            int i =0;
            float result=1;
            while(i<b){
                result= result*a;
                i=i+1;
            }
            Console.WriteLine($"Le resultat de {a} à la puissance {b} est : {result}");
        }
    }
}



/* 
 * exercice 5
            Console.WriteLine("Entrez un nombre");
            int a = int.Parse(Console.ReadLine());
            if (a < 0) {Console.WriteLine("Le nombre est négatif"); }
            else if (a > 0) {Console.WriteLine("Le nombre est positif"); }
            else if (a == 0){ Console.WriteLine("Le nombre est nul"); }

 * exercice 6
            Console.WriteLine("Entrez un caractère");
            var a = Console.ReadLine();
            a.ToLower();
            if (a == "a" || a == "e" || a == "o" || a == "i" || a == "u" || a == "y")
            {
                Console.WriteLine("La lettre est une voyelle");
            }
            else
                Console.WriteLine("La lettre est une consonne");
  
 * exercice 7               
            var jour = DateTime.Now.DayOfWeek;
            var heure = DateTime.Now.Hour;
            if (jour == DayOfWeek.Saturday || jour == DayOfWeek.Sunday || jour == DayOfWeek.Friday && heure > 18 || jour == DayOfWeek.Monday && heure > 9)
            {
                Console.WriteLine("Bonjour Mr C");
            }
            else if (jour == DayOfWeek.Monday || jour == DayOfWeek.Tuesday || jour == DayOfWeek.Wednesday || jour == DayOfWeek.Thursday || jour == DayOfWeek.Friday)
            {
                if (heure > 9 && heure < 18)
                {
                    Console.WriteLine("Bonjour Mr A");
                }
                else
                    Console.WriteLine("Bonjour Mr B");
            }

 * exercice 8
            int nb = 0;
            while (nb < 4)
            {
                Console.WriteLine("Entrez un nb entre 1 et 4");
                nb = int.Parse(Console.ReadLine());
                Console.WriteLine($"vous avez saisi {nb}");
            }
            Console.WriteLine("Le programme va se fermer");
            
*/