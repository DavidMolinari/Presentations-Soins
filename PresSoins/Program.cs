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
           XmlNodeList lesDossiers = doc.GetElementsByTagName("dossier");
            XmlNodeList lesIntervenants = doc.GetElementsByTagName("intervenant");

            Dossier unDossier = GestionXML.XMLToDossier(lesDossiers[0]);


            GestionXML.XMLToListePrestations(lesPrestations);

            Console.Read();




            Console.Read();
        }
    }
}
