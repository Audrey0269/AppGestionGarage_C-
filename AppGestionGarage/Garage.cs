using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Remoting.Lifetime;
using System.Xml.Serialization;
using System.Xml;

namespace AppGestionGarage
{
    [Serializable]
    internal class Garage 
    {
        //Attribut
        private string nom;
        private List<Vehicule> vehicules = new List<Vehicule>();
        private List<Moteur> moteurs = new List<Moteur>();
        private List<Option> options = new List<Option>();

        //Propriété
        public string Nom { get => nom; set => nom = value; }

        //Constructeur
        public Garage(string nom)
        {
            this.nom = nom;
        }

        //Méthodes
        public void AjouterVehicule(Vehicule vehicule)
        {
            vehicules.Add(vehicule);
        }

        //Afficher les véhicules du garage avec l'ensemble de leurs informations
        public void Afficher()
        {
            //Console.WriteLine("Garage {0} :", nom);
            foreach (Vehicule vehicule in vehicules)
            {
                    vehicule.Afficher();
            }
        }

        public void AfficherVoiture()
        {
            foreach (Vehicule vehicule in vehicules)
            {
                if (vehicule is Voiture)
                {
                    vehicule.Afficher();
                }
            }
        }

        public void AfficherCamion()
        {
            foreach (Vehicule vehicule in vehicules)
            {
                if (vehicule is Camion)
                {
                    vehicule.Afficher();
                }
            }
        }

        public void AfficherMoto()
        {
            foreach (Vehicule vehicule in vehicules)
            {
                if (vehicule is Moto)
                {
                    vehicule.Afficher();
                }
            }
        }

        public void TrierVehicule()
        {
            vehicules.Sort();
        }


        //********************************PART 2**************************************
        //Commande menu : 1
        public bool AsVehicules()
        {
            return vehicules.Any();
        }


        //Commande menu : 2
        //Marque
        public void AfficherMarques()
        {
            int numeroMarque = 0;

            foreach (Marque marque in Enum.GetValues(typeof(Marque)))
            {
                Console.WriteLine("{0} - {1}", numeroMarque, marque);
                numeroMarque++;
            }
        }

        public Marque RecupererMarque(int indexMarque)
        {

            if (!Enum.IsDefined(typeof(Marque), indexMarque))
            {
                throw new MarqueInexistanteException(); 
            }

            Marque marque = (Marque)Enum.GetValues(typeof(Marque)).GetValue(indexMarque);

            return marque;
        }

        //MOTEUR
        public void AjouterMoteur(Moteur moteur)
        {
            moteurs.Add(moteur);
        }

        //Type moteur
        public void AfficherTypeMoteur()
        {
            int numeroTypeMoteur = 0;

            foreach (TypeMoteur type in Enum.GetValues(typeof(TypeMoteur)))
            {
                Console.WriteLine("{0} - {1}", numeroTypeMoteur, type);
                numeroTypeMoteur++;
            }
        }

        public TypeMoteur RecupererTypeMoteur(int indexTypeMoteur)
        {
            if (!Enum.IsDefined(typeof(TypeMoteur), indexTypeMoteur))
            {
                throw new TypeMoteurInexistanteException();
            }

            TypeMoteur typeMoteur = (TypeMoteur)Enum.GetValues(typeof(TypeMoteur)).GetValue(indexTypeMoteur);

            return typeMoteur;
        }

        //Commande menu : 3
        public void SupprimerVehicule(Vehicule vehicule)
        {
            vehicules.Remove(vehicule);
        }

        //Commande menu : 4 
        public void AfficherNomVehicule()
        {
            foreach (Vehicule vehicule in vehicules)
            {
                Console.WriteLine("{0} - Nom : {1}", vehicule.Id, vehicule.Nom);
            }
        }

        public Vehicule RecupererVehicule(int index)
        {
            return vehicules[index-1];
        }

        public Vehicule SelectionnerVehicule()
        {
            if (!AsVehicules())
            {
                throw new GarageVideException();
            }
            else
            {
                try
                {
                    int numeroVehicule = 0;

                    Console.WriteLine("Véhicules du garage : ");
                    AfficherNomVehicule();

                    Console.WriteLine("Sélectionner un véhicule : ");
                    Console.Write("Choix : ");

                    numeroVehicule = Convert.ToInt32(Console.ReadLine());
                    Vehicule vehicule = RecupererVehicule(numeroVehicule);

                    Console.WriteLine("Vous avez sélectionner le vehicule : " + vehicule.Id + " - " + vehicule.Nom);

                    return vehicule;
                }
                catch
                {
                    throw new VehiculeInexistantException();
                }
            }
        }

        //Commande menu : 6
        public void AjouterOptionsVehicule(Vehicule vehicule)
        {
            int choixMenuOptionVehicule = 0;

            while (choixMenuOptionVehicule != 3)
            {
                Console.WriteLine("");
                Console.WriteLine("Options disponibles dans le garage : ");
                AfficherOptions();
                Console.WriteLine("");

                Console.WriteLine("Sélectionner un choix : ");
                Console.WriteLine("1 - Créer et ajouter une option au véhicule.");
                Console.WriteLine("2 - Sélectionner une option existante dans le garage et l'ajouter au véhicule.");
                Console.WriteLine("3 - Ne plus ajouter d'option au véhicule.");
               
                choixMenuOptionVehicule = Convert.ToInt32(Console.ReadLine());

                while (choixMenuOptionVehicule != 1 && choixMenuOptionVehicule != 2 && choixMenuOptionVehicule != 3)
                {
                    Console.WriteLine("La valeur est incorrecte, saisissez un nombre entre 1 et 3.");
                    choixMenuOptionVehicule = Convert.ToInt32(Console.ReadLine());
                }

                switch (choixMenuOptionVehicule)
                {
                    case 1:
                        Console.WriteLine("Création d'une nouvelle option");

                        Console.WriteLine("Nom de l'option :");
                        string nom = Console.ReadLine();

                        Console.WriteLine("Prix de l'option :");
                        decimal prix = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("L'option a été ajouté au véhicule");

                        Option option = new Option(nom, prix);

                        //Ajout de l'option au véhicule et au garage
                        vehicule.AjouterOption(option);
                        AjouterOptionGarage(option);

                        break;

                    case 2:

                      
                        int choixOptionVehicule = 0;

                        if (!AsOptions())
                        {
                            Console.WriteLine("Le garage ne possède pas d'option.");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Sélectionner l'option que vous souhaitez ajouter au véhicule : ");
                            AfficherOptions();

                            choixOptionVehicule = Convert.ToInt32(Console.ReadLine());

                            //Si l'option existe déja dans le véhicule
                            if(vehicules.Any(v => v.Id == choixOptionVehicule))
                            {
                                Console.WriteLine("Cette option existe déja dans le véhicule.");
                            }
                            else
                            {
                                Option option2 = RecupererOption(choixOptionVehicule);
                                Console.WriteLine("Vous avez ajouter l'option au véhicule.");

                                vehicule.AjouterOption(option2);
                            }
                        }
                      
                    break;
                }
            }   
        }

        public Option RecupererOption(int index)
        {
            //Si l'option récupérer n'existe pas > exception
            foreach(Option option in options) 
            {
                if (index != option.Id)
                {
                    throw new OptionInexistanteException();
                }
            }
            return options[index - 1];
        }


        //Commande menu : 7
        public void SupprimerOptionsVehicule(Vehicule vehicule)
        {
            int choixMenuOptionVehiculeSupp = 0;

            while (choixMenuOptionVehiculeSupp != 2)
            {
                Console.WriteLine("");
                Console.WriteLine("Sélectionner un choix : ");
                Console.WriteLine("1 - Sélectionner une option à supprimer du véhicule.");
                Console.WriteLine("2 - Ne plus supprimer d'option au véhicule.");

                choixMenuOptionVehiculeSupp = Convert.ToInt32(Console.ReadLine());

                while (choixMenuOptionVehiculeSupp != 1 && choixMenuOptionVehiculeSupp != 2)
                {
                    Console.WriteLine("La valeur est incorrecte, saisissez un nombre entre 1 et 2.");
                    choixMenuOptionVehiculeSupp = Convert.ToInt32(Console.ReadLine());
                }

                if(choixMenuOptionVehiculeSupp == 1) 
                {
                    if (!vehicule.VehiculeAsOptions())
                    {
                        Console.WriteLine("Le véhicule n'a pas d'option.");
                    }
                    else
                    {
                        int choixOption = 0;

                        Console.WriteLine("");
                        Console.WriteLine("Sélectionner l'option à supprimer");
                        vehicule.AfficherOptions();

                        choixOption = Convert.ToInt32(Console.ReadLine());
                        Option option = vehicule.RecupererOptionVehicule(choixOption);

                        vehicule.SupprimerOption(option);

                        Console.WriteLine("L'option " + option.Nom + " a été supprimé du véhicule");
                    }
                }
            }      
        }

        //Commande menu : 8
        public bool AsOptions()
        {
            return options.Any();
        }
        public void AjouterOptionGarage(Option option)
        {
            options.Add(option);
        }

        public void AfficherOptions()
        {
            if (!AsOptions())
            {
                Console.WriteLine("Le garage n'a pas d'option.");
            }

            foreach (Option option in options)
            {
                Console.WriteLine("{0} - Nom :  {1}, Prix : {2}", option.Id, option.Nom, option.Prix);
            }
        }

        //Commande menu : 11
        public void Enregistrer(object toSave, string path)
        {
            //Utilisation classe BinaryFormatter (fonctionne avec un flux)
            BinaryFormatter formatter = new BinaryFormatter();

            //Utilisation de FileStream (flux)
            FileStream flux = null;

            try
            {
                //Ouverture du flux en mode création et donne au flux droit écriture seulement
                flux = new FileStream(path, FileMode.Create, FileAccess.Write);

                //Sérialise
                formatter.Serialize(flux, toSave);

                //S'assurer que tout est écrit dans le fichier
                flux.Flush();
            }
            catch
            {

            }
            finally
            {
                //Fermeture des flux
                if (flux != null)
                {
                    flux.Close();
                }
            }
        }


        //Commande menu : 12
        public T Charger<T>(String path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;
            try
            {
                //Ouverture du fichier en mode readOnly, si le fichier n'existe pas = exception
                flux = new FileStream(path, FileMode.Open, FileAccess.Read);

                return (T)formatter.Deserialize(flux);
        }
            catch
            {
                //Retourne la valeur par défaut du type T
                return default(T);
            }
            finally
            {
                if (flux != null)
                {
                    flux.Close();
                }
            }
        }


        #region BROUILLON

        //Vérifier qu'un nom de vehicule n'existe pas déja (attribut nom en protected)
        //public void CheckNameNoAlreadyExist(string name)
        //{
        //    if (vehicule.Any(v => v.nom == name))
        //    {
        //        Console.WriteLine("Ce nom existe déja, veuillez en saisir un autre.");
        //    }
        //}

        //public bool AsMoteurs()
        //{
        //    return moteurs.Any();
        //}


        //public void AfficherMoteurs()
        //{
        //    if (!AsMoteurs())
        //    {
        //        Console.WriteLine("Le garage n'a pas de moteur.");
        //    }

        //    foreach (Moteur moteur in moteurs)
        //    {
        //        Console.WriteLine("{0} - Nom :  {1}, Puissance : {2}, Type : {3}", moteur.Id, moteur.Nom, moteur.Puissance, moteur.Type);
        //    }
        //}


        //public void AjouterMoteurVehicule(Vehicule vehicule)
        //{
        //    int choixMenuMoteurVehicule = 0;

        //    //while (choixMenuMoteurVehicule != 3)
        //    //{
        //        Console.WriteLine("");
        //        Console.WriteLine("Moteurs disponibles dans le garage : ");
        //        AfficherMoteurs();
        //        Console.WriteLine("");

        //        Console.WriteLine("Sélectionner un choix : ");
        //        Console.WriteLine("1 - Créer et ajouter un moteur au véhicule.");
        //        Console.WriteLine("2 - Sélectionner un moteur existant dans le garage et l'ajouter au véhicule.");
        //        Console.WriteLine("3 - Ne plus ajouter de moteur au véhicule.");

        //        choixMenuMoteurVehicule = Convert.ToInt32(Console.ReadLine());

        //        while (choixMenuMoteurVehicule != 1 && choixMenuMoteurVehicule != 2 && choixMenuMoteurVehicule != 3)
        //        {
        //            Console.WriteLine("La valeur est incorrecte, saisissez un nombre entre 1 et 3.");
        //            choixMenuMoteurVehicule = Convert.ToInt32(Console.ReadLine());
        //        }

        //        switch (choixMenuMoteurVehicule)
        //        {
        //            case 1:
        //                Console.WriteLine("Création d'un nouveau moteur");

        //                //Nom moteur véhicule
        //                Console.WriteLine("Nom du moteur : ");
        //                string nomMoteur = Console.ReadLine();

        //                //Puissance moteur véhicule
        //                Console.WriteLine("Puissance du moteur : ");
        //                int puissance = Convert.ToInt32(Console.ReadLine());

        //                //Type moteur véhicule
        //                int choixTypeMoteur = 0;

        //                Console.WriteLine("Choisissez le type de moteur : ");
        //                AfficherTypeMoteur();

        //                choixTypeMoteur = Convert.ToInt32(Console.ReadLine());
        //                TypeMoteur type = RecupererTypeMoteur(choixTypeMoteur);
        //                Console.WriteLine("Vous avez sélectionner le type de moteur : " + type);

        //                Console.WriteLine("Le moteur a été ajouté au véhicule");

        //                Moteur moteur = new Moteur(nomMoteur, puissance, type);

        //                //Ajout de l'option au véhicule et au garage
        //                vehicule.add(moteur);
        //                AjouterMoteur(moteur);

        //                break;

        //            case 2:

        //                int choixOptionVehicule = 0;

        //                if (!AsMoteurs())
        //                {
        //                    Console.WriteLine("Le garage ne possède pas de moteur.");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("");
        //                    Console.WriteLine("Sélectionner le moteur que vous souhaitez ajouter au véhicule : ");
        //                    AfficherOptions();

        //                    choixOptionVehicule = Convert.ToInt32(Console.ReadLine());

        //                    //Si l'option existe déja dans le véhicule
        //                    if (vehicules.Any(v => v.Id == choixOptionVehicule))
        //                    {
        //                        Console.WriteLine("Cette option existe déja dans le véhicule.");
        //                    }
        //                    else
        //                    {
        //                        Option option2 = RecupererOption(choixOptionVehicule);
        //                        Console.WriteLine("Vous avez ajouter l'option au véhicule.");

        //                        vehicule.AjouterOption(option2);
        //                    }
        //                }

        //                break;
        //        }
        //    }
        //}


        //public void CreerMoteur()
        //{
        //    int choix = 0;

        //    Console.WriteLine("Création d'un nouveau moteur");

        //    Console.WriteLine("Entrer le nom du moteur :");
        //    string nom = Console.ReadLine();

        //    Console.WriteLine("Entrer le puissance du moteur :");
        //    int puissance = Convert.ToInt32(Console.ReadLine());

        //    Console.WriteLine("Choisisser le Type du moteur :");
        //    AfficherTypesMoteur();
        //    Console.Write("Choix : ");
        //    choix = Convert.ToInt32(Console.ReadLine());
        //    TypeMoteur typeMoteur = RecupererTypeMoteur(choix);
        //    Console.WriteLine("Vous avez sélectionner le type de moteur : " + typeMoteur);

        //    AjouterMoteur(new Moteur(nom, puissance, typeMoteur));
        //    Console.WriteLine("Le moteur a été ajouté à la liste de moteur disponibles");
        //}

        //public Moteur RecupererMoteur(int index)
        //{
        //    return moteurs[index - 1];
        //}
        #endregion
    }
}

