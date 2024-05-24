using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionGarage
{
    [Serializable]
    internal class Option
    {
        //Attributs
        private static int increment = 1;
        private int id;
        private string nom;
        private decimal prix;

        //Propriété
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public decimal Prix { get => prix; set => prix = value; }

        //Constructeur
        public Option(string nom, decimal prix)
        {
            id = increment++;
            this.nom = nom;
            this.prix = prix;
        }

        //Méthode
        public void Afficher()
        {
            Console.WriteLine("{0} - Nom : {1}, Prix : {2} euros", id, nom, prix);
        }
    }


}
