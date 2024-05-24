using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionGarage
{
    internal class Program
    {
        private static Garage garage = new Garage("AutoPro");

        static void Main(string[] args)
        {
            /*
            //Création d'options
            Option optionAirbag = new Option("Airbag", 2000);
            Option optionClimatisation = new Option("Climatisation", 200);
            Option optionRadar = new Option("Radar", 150);
            Option optionPoigneeChauffantes = new Option("Poignées chauffantes", 250);
            Option optionGPS = new Option("GPS", 400);

            //Création de moteurs tests
            Moteur moteurElectrique = new Moteur("moteur électrique", 90, TypeMoteur.Electrique);
            Moteur moteurEssence = new Moteur("moteur essence", 70, TypeMoteur.Essence);
            Moteur moteurHybride = new Moteur("moteur hybride", 80, TypeMoteur.Hydride);
            Moteur moteurDiesel = new Moteur("moteur diesele", 60, TypeMoteur.Diesel);

            //Création des véhicules tests
            //VOITURES
            Voiture voiture208 = new Voiture("Peugot 208", 8000, Marque.Peugeot, 80, 5, 5, 500, moteurEssence);
            Voiture voitureC3 = new Voiture("Citroen C3", 15000, Marque.Citroen, 60, 5, 5, 400, moteurHybride);
            //CAMIONS
            Camion camionAmericain = new Camion("Camion américain", 100000, Marque.Ferrari,3, 44, 20, moteurEssence);
            Camion camionGrue = new Camion("Camion grue",160000, Marque.Renault, 3, 35, 15, moteurDiesel);
            //MOTOS
            Moto motoRoadster = new Moto("Moto roadster", 12000, Marque.Audi, 4, moteurEssence);
            Moto motoSportive = new Moto("Moto sportive", 120000, Marque.Ferrari, 4, moteurElectrique);

            //Ajout des options aux véhicules
            voiture208.AjouterOption(optionAirbag);
            voiture208.AjouterOption(optionClimatisation);
            voitureC3.AjouterOption(optionClimatisation);
            camionAmericain.AjouterOption(optionAirbag);
            camionGrue.AjouterOption(optionGPS);
            motoRoadster.AjouterOption(optionRadar);
            motoSportive.AjouterOption(optionPoigneeChauffantes);

            //Création d'un garage test
            Garage garage = new Garage("AutoPro");

            //Afficher les informations d'un véhicule
            //voiture208.Afficher();
            //camionGrue.Afficher();
            //motoSportive.Afficher();

            //Ajout de véhicules au garage 
            garage.AjouterVehicule(voiture208);
            garage.AjouterVehicule(camionAmericain);
            garage.AjouterVehicule(motoRoadster);
            garage.AjouterVehicule(camionGrue);
            garage.AjouterVehicule(motoSportive);
            garage.AjouterVehicule(voitureC3);

            //Afficher tous les véhicules du garage (non trié)
            //garage.Afficher();

            //Affichage des véhicules triés par prix
            garage.TrierVehicule();
            garage.Afficher();

            Console.ReadKey();
            */



            //PARTIE 2

            Menu menu = new Menu(garage);
            menu.Start();
        }
    }
}
