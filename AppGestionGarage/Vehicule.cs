using AppGestionGarage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionGarage
{
    [Serializable]
    public enum Marque
    {
        Peugeot,
        Renault,
        Citroen,
        Audi,
        Ferrari
    }

    [Serializable]
    internal abstract class Vehicule : IComparable
    {
        //Attributs
        private static int increment = 1;
        protected int id; 
        protected string nom;
        protected decimal prixHT;
        protected Marque marque;
        private List<Option> options = new List<Option>();
        private Moteur moteur;


        //Propriétés
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public decimal PrixHT { get => prixHT; set => prixHT = value; }
        public Marque Marque { get => marque; set => marque = value; }
        public Moteur Moteur { get => moteur; set => moteur = value; }


        //Constructeurs
        public Vehicule(string nom, decimal prixHT, Marque marque, Moteur moteur) 
        {
            id = increment ++;
            this.nom = nom;
            this.prixHT = prixHT;
            this.marque = marque;
            this.moteur = moteur;
        }

        //Méthodes
        public bool VehiculeAsOptions()
        {
            return options.Any();
        }
        public void AfficherOptions()
        {
            Console.WriteLine("Options");

            if(!VehiculeAsOptions())
            {
                Console.WriteLine("Le véhicule n'a pas d'option.");
            }

            foreach (Option option in options)
            {
                option.Afficher();
            }
        }

        public virtual void Afficher()
        {
            Console.WriteLine("Nom : {0}", nom );
            Console.WriteLine("Marque : {0}", marque);
            Console.WriteLine("Prix HT et hors options : {0} euros", prixHT);
            Console.WriteLine("Prix total (taxe et options comprises) : {0} euros", PrixTotal());
        }

        
        public void AjouterOption(Option option) 
        {
            options.Add(option);
        }

        //Méthode abstract
        public abstract decimal CalculerTaxe();
        

        //Prix HT + Taxe + Options
        public decimal PrixTotal()
        {
            return prixHT + CalculerTaxe() + options.Sum(option => option.Prix);
        }


        // méthode implémentée pour l'interface IComparable
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Vehicule vehicule = obj as Vehicule;
            if (vehicule != null)
                return this.prixHT.CompareTo(vehicule.prixHT);
            else
                throw new ArgumentException("Object is not a Vehicule");
        }


        //Partie 2 - Commande 7
        public void SupprimerOption(Option option)
        {
            options.Remove(option);
        }
        public Option RecupererOptionVehicule(int index)
        {
            //Si l'option récupérer n'existe pas > exception
            foreach (Option option in options)
            {
                if (index != option.Id)
                {
                    throw new OptionInexistanteException();
                }
            }
            return options[index-1];
        }
    }
}




