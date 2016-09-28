using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classesMetier;
using maBoiteAOutils;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using maBoiteAOutils.Extensions;
using System.Xml.Linq;

namespace PresSoins
{
    class Program
    {
        static void Main(string[] args)
        {
            /** 
             * XML
             * **/
            // var xmlString = desPrestations.Serialize();
            // Utilisation de la bibliothéque LINQ

            string fileName = "jeudEssai.xml";
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList lesPrestations = doc.GetElementsByTagName("prestations");
           XmlNodeList listeDossiers = doc.GetElementsByTagName("dossier");
            XmlNodeList lesIntervenants = doc.GetElementsByTagName("intervenant");

            /*
            // Date de naissance dossier Vide
            DateTime dateDossierVide = new DateTime(
                Convert.ToInt32(listeDossiers[0].ChildNodes[2].ChildNodes[0].InnerXml), 
                Convert.ToInt32(listeDossiers[0].ChildNodes[2].ChildNodes[1].InnerXml), 
                Convert.ToInt32(listeDossiers[0].ChildNodes[2].ChildNodes[2].InnerXml));
            // Instantiation d'un dossier vide
            Dossier unDossierVide = new Dossier(listeDossiers[0].ChildNodes[0].InnerXml, listeDossiers[0].ChildNodes[1].InnerXml, dateDossierVide);
            */
            // Date Naissance Dossier une seule Prestation
            DateTime dateDossierUnePres = new DateTime(
               Convert.ToInt32(listeDossiers[2].ChildNodes[2].ChildNodes[0].InnerXml),
               Convert.ToInt32(listeDossiers[2].ChildNodes[2].ChildNodes[1].InnerXml),
               Convert.ToInt32(listeDossiers[2].ChildNodes[2].ChildNodes[2].InnerXml));

            // Heure Prestation
            DateTime heurePres = new DateTime(
                        Convert.ToInt32(lesPrestations[1].ChildNodes[0].ChildNodes[1].ChildNodes[0].InnerXml),
                        Convert.ToInt32(lesPrestations[1].ChildNodes[0].ChildNodes[1].ChildNodes[1].InnerXml),
                        Convert.ToInt32(lesPrestations[1].ChildNodes[0].ChildNodes[1].ChildNodes[2].InnerXml),
                        Convert.ToInt32(lesPrestations[1].ChildNodes[0].ChildNodes[1].ChildNodes[3].InnerXml),
                        Convert.ToInt32(lesPrestations[1].ChildNodes[0].ChildNodes[1].ChildNodes[4].InnerXml), 00);

            // Date Prestation
            DateTime datePres = new DateTime(
                        Convert.ToInt32(lesPrestations[1].ChildNodes[0].ChildNodes[1].ChildNodes[0].InnerXml),
                        Convert.ToInt32(lesPrestations[1].ChildNodes[0].ChildNodes[1].ChildNodes[1].InnerXml),
                        Convert.ToInt32(lesPrestations[1].ChildNodes[0].ChildNodes[1].ChildNodes[2].InnerXml));


            // Un Intervenant
            Intervenant unIntervenant = new Intervenant(lesPrestations[1].ChildNodes[0].ChildNodes[2].ChildNodes[0].InnerXml, lesPrestations[1].ChildNodes[0].ChildNodes[2].ChildNodes[1].InnerXml);

            // Une Prestation
            Prestation unePrestation = new Prestation(lesPrestations[1].ChildNodes[0].InnerXml, datePres, heurePres, unIntervenant);

            // Dossier avec une Prestation
            Dossier unDossierUnePrestation = new Dossier(listeDossiers[2].ChildNodes[0].InnerXml, listeDossiers[2].ChildNodes[1].InnerXml, dateDossierUnePres, unePrestation); ///FIXME PRESTATIONS



            //GestionXML.initDossiersVides(doc);




            Console.Read();
        }
    }
}
