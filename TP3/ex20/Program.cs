using System;

namespace ex20
{
    class Produit
    {
        public string nom;
        public double prix;
        public Produit(){}
        public Produit(string N, double P){nom=N; prix=P;}

        public override string ToString()
            {
                return this.nom + " " + this.prix.ToString();
            }
        
        public Produit Saisie()
        {
            Console.WriteLine("Saisissez les caractéristiques du produit:");
            Console.WriteLine("Nom:");
            string N = Console.ReadLine();
            Console.WriteLine("prix:");
            double P = Convert.ToDouble(Console.ReadLine());
            Produit prod = new Produit(N,P);
            return prod;
        }
    }

    class Catalogue
    {
        public Produit[] tab;
        public int annee;

        public new string ToString()
        {
            string description_catalogue="Catalogue" + this.annee.ToString();
            int i=0;
            while(this.tab[i]!= null)
            {
                description_catalogue= description_catalogue + "\n" + this.tab[i].ToString();
                i++;
            }
            return description_catalogue;
        }
        public Catalogue Saisie()
        {
            Console.WriteLine("Combien de produits souhaitez vous ajouter?");
            int nb_produits = int.Parse(Console.ReadLine());
            Produit[] cata = new Produit[nb_produits];

            Console.WriteLine("Quel type de produit souhaitez vous ajouter?");
            Console.WriteLine("1 - Alimentaire");
            Console.WriteLine("2 - Non Alimentaire");
            int choix = int.Parse(Console.ReadLine());
            switch(choix)
            {
                case 1:
                    

            }

        }
    }

    class ProduitAlimentaire : Produit
    {
        public DateTime date_peremption;
        public ProduitAlimentaire(string N, double P, DateTime dateP): base(N,P)
        {
            this.date_peremption = dateP;
        }
        public new ProduitAlimentaire Saisie()
        {
            Produit prod = new Produit();
            prod = base.Saisie();
            Console.WriteLine("Entrez la date de peremption du produit: (annee, month, day)");
            int date_year = int.Parse(Console.ReadLine());
            int date_month = int.Parse(Console.ReadLine());
            int date_day = int.Parse(Console.ReadLine());
            DateTime date = new DateTime(date_year, date_month, date_day);
            ProduitAlimentaire prod_ali = new ProduitAlimentaire(prod.nom, prod.prix, date);
            return prod_ali;
        }
        public new string ToString()
        {
            return base.ToString() + this.date_peremption.ToString("MM/dd/yyyy");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var date1 = new DateTime(2008, 5, 1);
            Console.WriteLine(date1.ToString("MM/dd/yyyy"));
        }
    }
}
