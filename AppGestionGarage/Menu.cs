using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionGarage
{
    //Exception personnalisée
    [Serializable]
    public class MenuException : Exception
    {
        public MenuException()
            : base("Le choix n'est pas compris entre 0 et 13.") { }
    }

    [Serializable]
    public class VehiculeInexistantException : Exception
    {
        public VehiculeInexistantException()
            : base("Ce véhicule n'existe pas.") { }
    }

    [Serializable]
    public class GarageVideException : Exception
    {
        public GarageVideException()
            : base("Le garage ne contient pas de véhicule.") { }
    }

    [Serializable]
    public class MarqueInexistanteException : Exception
    {
        public MarqueInexistanteException()
            : base("Cette marque n'existe pas.") { }
    }

    [Serializable]
    public class TypeMoteurInexistanteException : Exception
    {
        public TypeMoteurInexistanteException()
            : base("Ce type de moteur n'existe pas.") { }
    }
    [Serializable]
    public class OptionInexistanteException : Exception
    {
        public OptionInexistanteException()
            : base("Cette option n'existe pas.") { }
    }



    [Serializable]
    internal class Menu
    {
        //Attribut
        private Garage garage;

        //Propriété
        public Garage Garage { get => garage; set => garage = value; }  

        //Constructeur
        public Menu(Garage garage) 
        {
            this.garage = garage;
        }

        //Méthodes
        public void Start() 
        {
            int choixMenu = 0;

            while (choixMenu != 13)
            {
                try
                {
                    AfficherMenu();
                    choixMenu = GetChoixMenu();

                    switch (choixMenu)
                    {
                        case 1:
                            AfficherVehicules();
                            break;
                        case 2:
                            AjouterUnVehicule();
                            break;
                        case 3:
                            SupprimerUnVehicule();
                            break;
                        case 4:
                            SelectionnerUnVehicule();
                            break;
                        case 5:
                            AfficherOptionVehicule();
                            break;
                        case 6:
                            AjouterOptionVehicule();
                            break;
                        case 7:
                            SupprimerOptionVehicule();
                            break;
                        case 8:
                            AfficherOptions();
                            break;
                        case 9:
                            AfficherMarques();
                            break;
                        case 10:
                            AfficherTypesMoteurs();
                            break;
                        case 11:
                            ChargerGarage();
                            break;
                        case 12:
                            SauvegarderGarage();
                            break;
                    }
                }
                catch (MenuException ex)
                {
                    Console.WriteLine("************** ERREUR ********************");
                    Console.WriteLine($"{ex.Message}");
                    Console.WriteLine("******************************************");
                }
                catch (VehiculeInexistantException ex)
                {
                    Console.WriteLine("************* ERREUR *********************");
                    Console.WriteLine($"{ex.Message}");
                    Console.WriteLine("******************************************");
                }
                catch (GarageVideException ex)
                {
                    Console.WriteLine("******************************************");
                    Console.WriteLine($"{ex.Message}");
                    Console.WriteLine("******************************************");
                }
                catch (OptionInexistanteException ex)
                {
                    Console.WriteLine("************** ERREUR ********************");
                    Console.WriteLine($"{ex.Message}");
                    Console.WriteLine("******************************************");
                }
                catch (FormatException)
                {
                    Console.WriteLine("************** ERREUR ********************");
                    Console.WriteLine("Le choix saisie n'est pas un nombre.");
                    Console.WriteLine("******************************************");
                }
            }  
        }

        public void AfficherMenu()
        {
            Console.WriteLine(
@"1. Afficher les véhicules 
2. Ajouter un véhicule
3. Supprimer un véhicule
4. Sélectionner un véhicule
5. Afficher les options d'un véhicule
6. Ajouter des options à un véhicule
7. Supprimer des options à un véhicule
8. Afficher les options
9. Afficher les marques
10. Afficher les types de moteurs
11. Charger le garage
12. Sauvegarder le garage
13. Quitter l'application
            ");

            Console.WriteLine("Choix : ");
        }

        public int GetChoix()
        {
            try
            {
                //Récupérer le choix saisie par l'utilisateur 
                string choixUtilisateurString = Console.ReadLine();

                //Le convertir en int 
                int choixUtilisateurInt = Convert.ToInt32(choixUtilisateurString);

                //Retourner le résultat converti
                return choixUtilisateurInt;

            }
            catch (FormatException)
            {
                throw new FormatException();
            }
        }

        public int GetChoixMenu()
        {
            int choixMenu = GetChoix();

            if (choixMenu < 1 || choixMenu > 13)
            {
                throw new MenuException();
            }

            return choixMenu;
        }

        //MENU OPT 1 : AFFICHER VEHICULES
        public void AfficherVehicules()
        {

            //Console.WriteLine("**********************************");
            if (!garage.AsVehicules())
            {
                throw new GarageVideException();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Liste des véhicules présent dans le garage " + garage.Nom);
                garage.Afficher();
            }
            //Console.WriteLine("**********************************");
        }


        //MENU OPT 2 : AJOUTER UN VEHICULE
        public void AjouterUnVehicule()
        {
            try
            {
                //Choix du type véhicule
                Console.WriteLine("Choisissez le type de véhicule : ");
                Console.WriteLine("1 - Voiture");
                Console.WriteLine("2 - Camion");
                Console.WriteLine("3 - Moto");
                int typeVehicule = GetChoix();

                //Boucle while (tant que l'utilisateur ne saisi pas une valeur correct (1,2,3) il ne peut pas passer aux étape suivantes 
                while(typeVehicule != 1 && typeVehicule != 2 && typeVehicule != 3) 
                { 
                    Console.WriteLine("La valeur est incorrecte, saisissez un nombre entre 1 et 3.");
                    typeVehicule = GetChoix();
                }
                
                //Nom véhicule
                Console.WriteLine("Nom du véhicule : ");
                string nom = Console.ReadLine();

               

                //PrixHT véhicule
                Console.WriteLine("Prix HT du véhicule : ");
                int prixHT = GetChoix();
                
                //Marque véhicule
                int choixMarque = 0;

                Console.WriteLine("Choisissez la marque du véhicule : ");
                garage.AfficherMarques();

                choixMarque = Convert.ToInt32(Console.ReadLine());
                Marque marque = garage.RecupererMarque(choixMarque);
                Console.WriteLine("Vous avez sélectionner la marque : " + marque);

                //Moteur vehicule
                //Nom moteur véhicule
                Console.WriteLine("Nom du moteur : ");
                string nomMoteur = Console.ReadLine();

                //Puissance moteur véhicule
                Console.WriteLine("Puissance du moteur : ");
                int puissance = Convert.ToInt32(Console.ReadLine());

                //Type moteur véhicule
                int choixTypeMoteur = 0;

                Console.WriteLine("Choisissez le type de moteur : ");
                garage.AfficherTypeMoteur();

                choixTypeMoteur = Convert.ToInt32(Console.ReadLine());
                TypeMoteur type = garage.RecupererTypeMoteur(choixTypeMoteur);
                Console.WriteLine("Vous avez sélectionner le type de moteur : " + type);

                Moteur moteur = new Moteur(nomMoteur, puissance, type);

                garage.AjouterMoteur(moteur);

                switch (typeVehicule)
                {
                    //Voiture
                    case 1:
                        Console.WriteLine("Chevaux fiscaux : ");
                        int chevauxFiscaux = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Nombre de portes : ");
                        int nbPorte = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Nombre de sièges : ");
                        int nbSiege = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Taille du coffre : ");
                        int tailleCoffre = Convert.ToInt32(Console.ReadLine());

                        Voiture voiture = new Voiture(nom, prixHT, marque, chevauxFiscaux, nbPorte, nbSiege, tailleCoffre, moteur);

                        garage.AjouterVehicule(voiture);

                        break;

                    //Camion
                    case 2:
                        Console.WriteLine("Nombre d'essieux : ");
                        int nbEssieu = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Poids : ");
                        int poids = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Volume : ");
                        int volume = Convert.ToInt32(Console.ReadLine());

                        Camion camion = new Camion(nom, prixHT, marque, nbEssieu, poids, volume, moteur);

                        garage.AjouterVehicule(camion);

                        break;

                    //Moto
                    case 3: 
                        Console.WriteLine("Cylindrée : ");
                        int cylindree = Convert.ToInt32(Console.ReadLine());

                        Moto moto = new Moto(nom, prixHT, marque, cylindree, moteur);

                        garage.AjouterVehicule(moto);

                        break;
                } 
            }
            catch (MarqueInexistanteException ex)
            {
                Console.WriteLine("************** ERREUR ********************");
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine("******************************************");
            }
            catch (TypeMoteurInexistanteException ex)
            {
                Console.WriteLine("************** ERREUR ********************");
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine("******************************************");
            }
            catch (FormatException)
            {
                Console.WriteLine("************** ERREUR ********************");
                Console.WriteLine("Le choix saisie n'est pas un nombre.");
                Console.WriteLine("************** ERREUR ********************");
            }
        }


        //MENU OPT 3
        public void SupprimerUnVehicule()
        {
            Console.WriteLine("**********************************");
            garage.SupprimerVehicule(garage.SelectionnerVehicule());
            Console.WriteLine("Ce véhicule a été supprimé du garage.");
            Console.WriteLine("**********************************");

        }

        //MENU OPT 4
        public void SelectionnerUnVehicule()
        {
            Console.WriteLine("**********************************");
            garage.SelectionnerVehicule();
            Console.WriteLine("**********************************");
        }

        //MENU OPT 5
        public void AfficherOptionVehicule()
        {
            Console.WriteLine("**********************************");
            Vehicule vehicule = garage.SelectionnerVehicule();
            vehicule.AfficherOptions();
            Console.WriteLine("**********************************");
        }

        //MENU OPT 6
        public void AjouterOptionVehicule()
        {
            Console.WriteLine("**********************************");
            garage.AjouterOptionsVehicule(garage.SelectionnerVehicule());
            Console.WriteLine("**********************************");
        }

        //MENU OPT 7
        public void SupprimerOptionVehicule()
        {
            Console.WriteLine("**********************************");
            garage.SupprimerOptionsVehicule(garage.SelectionnerVehicule());
            Console.WriteLine("**********************************");
        }

        //MENU OPT 8
        public void AfficherOptions()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("Options disponibles dans le garage : ");
            garage.AfficherOptions(); 
            Console.WriteLine("**********************************");
        }

        //MENU OPT 9
        public void AfficherMarques()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("Liste des marques présentes dans le garage : ");
            garage.AfficherMarques();
            Console.WriteLine("**********************************");
        }

        //MENU OPT 10
        public void AfficherTypesMoteurs()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("Types de moteur présent dans le garage : ");
            garage.AfficherTypeMoteur();
            Console.WriteLine("**********************************");
        }

        //MENU OPT 12
        public void SauvegarderGarage()
        {
            garage.Enregistrer(garage, "monGarage.dat");
            Console.WriteLine("Le garage a été sauvegardé.");
            Console.WriteLine("");
        }

        //MENU OPT 11
        public void ChargerGarage()
        {
            garage = garage.Charger<Garage>("monGarage.dat");
            Console.WriteLine("Le garage a été chargé.");
            Console.WriteLine("");
        }

        //Chemin du fichier créé (pour serialization) :
        //C:\Users\GAUDILL1\Documents\Docs travail\IPI\Programmation .Net POO\AppGestionGarage LAST\AppGestionGarage\AppGestionGarage\bin\Debug\monFichier.dat


        #region BROUILLON
        //OPTION
        //Console.WriteLine("**********************");
        //Console.WriteLine("Options disponibles : ");

        //int choixMenuOption = 0;

        //while(choixMenuOption != 2)
        //{
        //    //Afficher Menu
        //    if (!garage.AsOptions())
        //    {
        //        Console.WriteLine("Le garage ne contient pas d'options");
        //        Console.WriteLine("1 - Créer une nouvelle option.");
        //        Console.WriteLine("2 - Ne pas ajouter d'option à ce vehicule.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Liste des options : ");
        //        garage.AfficherOptions();
        //        Console.WriteLine("====================");
        //        Console.WriteLine("1 - Créer une nouvelle option.");
        //        Console.WriteLine("2 - Ne pas ajouter d'option supplémentaire à ce vehicule.");
        //        Console.WriteLine("3 - Ajouter une option au véhicule parmis celle existante.");
        //    }

        //    Console.WriteLine("Choix : ");
        //    choixMenuOption = Convert.ToInt32(Console.ReadLine());

        //    if(choixMenuOption == 1)
        //    {
        //        garage.CreerOption();
        //    }

        //    if(choixMenuOption == 3)
        //    {
        //        try
        //        {
        //            int numeroOption = 0;

        //            Console.WriteLine("Saisissez le numéro de l'option que vous souhaitez ajouter au vehicule : ");
        //            garage.AfficherOptions();
        //            Console.WriteLine("Choix : ");
        //            numeroOption = Convert.ToInt32(Console.ReadLine());
        //            Option option = garage.RecupererOption(numeroOption);
        //            Console.WriteLine("Vous avez sélectionner l'option : " + option.Nom);
        //            //Revoir exception si utilisateur selectionne autre numéro : arret sur catch mais pas message console

        //        }
        //        catch
        //        {
        //            throw new Exception("Option introuvable");
        //        }
        //    }
        //}
        //Console.WriteLine("**********************");
        #endregion

    }
}
