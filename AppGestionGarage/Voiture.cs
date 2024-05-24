using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionGarage 
{
    [Serializable]
    internal class Voiture : Vehicule
    {
        //Attributs
        private int chevauxFiscaux;
        private int nbPorte;
        private int nbSiege;
        private int tailleCoffre;

        //Propriétés
        public int ChevauxFiscaux { get => chevauxFiscaux; set => chevauxFiscaux = value; }
        public int NbPorte { get => nbPorte; set => nbPorte = value; }
        public int NbSiege { get => nbSiege; set => nbSiege = value; }
        public int TailleCoffre { get => tailleCoffre; set => tailleCoffre = value; }

        //Constructeur
        public Voiture (string nom, decimal prixHT, Marque marque, int chevauxFiscaux, int nbPorte, int nbSiege, int tailleCoffre, Moteur moteur)
            : base (nom, prixHT, marque, moteur)
        {
            this.chevauxFiscaux=chevauxFiscaux;
            this.nbPorte=nbPorte;
            this.nbSiege = nbSiege;  
            this.tailleCoffre=tailleCoffre;
        }

        //Méthodes
        public override decimal CalculerTaxe()
        {
            return chevauxFiscaux * 10; 
        }

        public override void Afficher()
        {
            Console.WriteLine("Informations sur le véhicule {0} : {1} ", id, nom);
            Console.WriteLine("******************************************");

            base.Afficher();

            Console.WriteLine("");
            Console.WriteLine("Informations techniques");
            Console.WriteLine("Chevaux fiscaux : {0}", chevauxFiscaux);
            Console.WriteLine("Nombre de porte : {0}", nbPorte);
            Console.WriteLine("Nombre de siège : {0}", nbSiege);
            Console.WriteLine("Taille du coffre : {0} m3", tailleCoffre);
            Console.WriteLine("");

            Console.WriteLine("Moteur");
            Moteur.Afficher();
            Console.WriteLine("");

            AfficherOptions();
            Console.WriteLine("");
        }
    }
}
