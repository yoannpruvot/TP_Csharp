using System;

namespace ex30
{
    public enum Resultat{ j1gagne, j0gagne, partieNulle, indetermine }
    public abstract class Position
    { 
        public bool j1aletrait; 
        public Position(bool j1aletrait){ this.j1aletrait=j1aletrait; } 
        public abstract Resultat Eval(); 
    }
    public class PositionTA : Position
    {
         public double seuil;
         public double score_j1;
         public double score_j0;
         public bool j1aletrait;
         public Resultat Eval()
         {
             if (!j1aletrait)
             {
                 return Resultat.indetermine;
             }
         }
    }
    public abstract class Joueur{ 
        public abstract Position Jouer(Position p); 
    }
    public class JoueurUnif : Joueur
    {
        private Random random;
        public Position Jouer(Position p)
        {
            
        }
        random = new Random();
        val_unif = random.Ne
        
    }
    public class Partie
    { 
        Position pCourante; 
        Joueur j1,j0; 
        public Resultat Re;
        public Partie(Joueur j1, Joueur j0, Position pInitiale){ this.j1 = j1; this.j0 = j0; pCourante = pInitiale; }
        public void Commencer()
        { 
            Resultat r; 
            Affiche (); 
            do 
            { 
                if (pCourante.j1aletrait) 
                {
                    pCourante = j1.Jouer(pCourante);
                } 
                else 
                {
                    pCourante = j0.Jouer(pCourante);
                } 
                Affiche (); 
                r = pCourante.Eval (); 
            } 
            while(r == Resultat.indetermine);
            Re = r; 
            switch (r)
            { 
                case Resultat.j1gagne : 
                    Console.WriteLine("j1 a gagné."); 
                    break; 
                case Resultat.j0gagne : 
                    Console.WriteLine("j0 a gagné."); 
                    break; 
                case Resultat.partieNulle : 
                    Console.WriteLine("Partie nulle."); 
                    break; 
            } 
        } 
        void Affiche()
        {
            Console.WriteLine(pCourante);
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
