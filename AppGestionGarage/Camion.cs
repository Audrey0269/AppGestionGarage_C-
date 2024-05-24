using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionGarage
{
    [Serializable]
    internal class Camion : Vehicule
    {
        //Attributs
        private int nbEssieu;
        private int poids;
        private int volume;

        //Propriétés
        public int NbEssieu { get => nbEssieu; set => nbEssieu = value; }
        public int Poids { get => poids; set => poids = value; }
        public int Volume { get => volume; set => volume = value; }

        //Constructeur
        public Camion(string nom, decimal prixHT, Marque marque, int nbEssieu, int poids, int volume, Moteur moteur)
            : base (nom, prixHT, marque, moteur)
        {
            this.nbEssieu = nbEssieu;
            this.poids = poids;
            this.volume = volume;
        }

        //Méthodes
        public override decimal CalculerTaxe()
        {
            return nbEssieu*50; 
        }

        public override void Afficher()
        {
            Console.WriteLine("Informations sur le véhicule {0} : {1} ", id, nom);
            Console.WriteLine("******************************************");

            base.Afficher();

            Console.WriteLine("");
            Console.WriteLine("Informations techniques");
            Console.WriteLine("Nombre d'essieux : {0}", nbEssieu);
            Console.WriteLine("Poids de chargement : {0}", poids);
            Console.WriteLine("Volume de chargement : {0}", volume);
            Console.WriteLine("");

            Console.WriteLine("Moteur");
            Moteur.Afficher();
            Console.WriteLine("");

            AfficherOptions();
            Console.WriteLine("");
        }
    }
}
