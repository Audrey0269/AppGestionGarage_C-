using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionGarage
{
    [Serializable]
    public enum TypeMoteur
    {
        Diesel,
        Essence,
        Hydride,
        Electrique
    }

    [Serializable]
    internal class Moteur
    {
        //Attributs
        private static int increment = 1;
        private int id;
        private string nom;
        private int puissance;
        private TypeMoteur type;

        //Propriétés
        public int Id { get => id; }
        public string Nom { get => nom; set => nom = value; }
        public int Puissance { get => puissance; set => puissance = value; }
        public TypeMoteur Type { get => type; set => type = value; }

        //Constructeurs
        public Moteur(string nom, int puissance, TypeMoteur type)
        {
            id = increment++;
            this.nom = nom;
            this.puissance = puissance;
            this.type = type;
        }

        //Methodes
        public void Afficher()
        {
            Console.WriteLine("Nom : {0}", nom);
            Console.WriteLine("Puissance : {0}", puissance);
            Console.WriteLine("Type : {0}", type);
        }

        

    }
}
