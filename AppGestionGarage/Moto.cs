using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionGarage
{
    [Serializable]
    internal class Moto : Vehicule
    {
        //Attribut
        private int cylindree;

        //Propriété
        public int Cylindree { get => cylindree; set => cylindree = value; }

        //Constructeur
        public Moto(string nom, decimal prixHT, Marque marque, int cylindree, Moteur moteur) 
            : base (nom, prixHT, marque, moteur)
        {
            this.cylindree = cylindree;
        }

        //Méthodes
        public override decimal CalculerTaxe()
        {
            return cylindree * (decimal)0.3; 
        }

        public override void Afficher()
        {
            Console.WriteLine("Informations sur le véhicule {0} : {1} ", id, nom);
            Console.WriteLine("******************************************");

            base.Afficher();

            Console.WriteLine("");
            Console.WriteLine("Informations techniques");
            Console.WriteLine("Cylindrée : {0}", cylindree);

            Console.WriteLine("");
            Console.WriteLine("Moteur");
            Moteur.Afficher();
            Console.WriteLine("");

            AfficherOptions();
            Console.WriteLine("");
        }
    }
}
