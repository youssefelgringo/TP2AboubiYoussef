using System;
using System.Collections.Generic;

namespace GestionPoulailler
{
    class Poulailler
    {
        public string Nom { get; set; }
        public int CapaciteMaximale { get; set; }
        public List<Poule> Poules { get; set; }

        public Poulailler(string nom, int capaciteMaximale)
        {
            Nom = nom;
            CapaciteMaximale = capaciteMaximale;
            Poules = new List<Poule>();
        }

        public void AjouterPoule(Poule poule)
        {
            if (Poules.Count < CapaciteMaximale)
            {
                Poules.Add(poule);
                Console.WriteLine("La poule a été ajoutée au poulailler.");
            }
            else
            {
                Console.WriteLine("Le poulailler est déjà plein. Impossible d'ajouter une nouvelle poule.");
            }
        }

        public void AfficherPoules()
        {
            Console.WriteLine($"Liste des poules du poulailler {Nom}:");
            for (int i = 0; i < Poules.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {Poules[i].ToString()}");
            }
            Console.WriteLine($"Total : {Poules.Count} poules");
        }

        public void SupprimerPoule(int numeroAffichage)
        {
            if (numeroAffichage >= 1 && numeroAffichage <= Poules.Count)
            {
                Poules.RemoveAt(numeroAffichage - 1);
                Console.WriteLine("La poule a été supprimée du poulailler.");
            }
            else
            {
                Console.WriteLine("Numéro d'affichage invalide. Veuillez spécifier un numéro valide.");
            }
        }
    }

    class Poule
    {
        public string Nom { get; set; }
        public int Age { get; set; }

        public Poule(string nom, int age)
        {
            Nom = nom;
            Age = age;
        }

        public override string ToString()
        {
            return $"Poule {Nom} (âge: {Age})";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Poulailler poulailler = new Poulailler("Poulailler 1", 10);

            poulailler.AjouterPoule(new Poule("Poule 1", 2));
            poulailler.AjouterPoule(new Poule("Poule 2", 3));
            poulailler.AjouterPoule(new Poule("Poule 3", 1));

            poulailler.AfficherPoules();

            poulailler.SupprimerPoule(2);

            poulailler.AfficherPoules();

            // Fonctionnalité supplémentaire - Calcul de la moyenne d'âge des poules
            double sommeAges = 0;
            foreach (Poule poule in poulailler.Poules)
            {
                sommeAges += poule.Age;
            }
            double moyenneAge = sommeAges / poulailler.Poules.Count;
            Console.WriteLine($"Moyenne d'âge des poules : {moyenneAge}");

            Console.ReadLine();
        }
    }
}
