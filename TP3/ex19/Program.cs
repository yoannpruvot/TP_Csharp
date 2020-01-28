using System;

namespace ex19
{
    class calcul_age
    {
        public static int demande()
        {
            Console.WriteLine("Entre votre année de naissance");
            int annee = int.Parse(Console.ReadLine());
            return annee;
        }
        public static int age()
        {
            calcul_age calcul = new calcul_age();
            int annee = calcul_age.demande();
            int age = DateTime.Today.Year - annee;
            return age;
        }
        public static void afficher()
        {
            int age = calcul_age.age();
            Console.WriteLine($"Votre age est de: {age} ans.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            calcul_age age = new calcul_age();
            calcul_age.afficher();
        }
    }
}
