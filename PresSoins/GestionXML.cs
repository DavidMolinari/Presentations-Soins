using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classesMetier;
using System.Xml;

namespace PresSoins
{
    public static class GestionXML
    {

        public static void initDossiersVides(XmlDocument myDoc, List<Dossier> mesDossier)
        {
            XmlNodeList listeDossiers = myDoc.GetElementsByTagName("dossier");
            XmlNodeList xmlMeh = myDoc.GetElementsByTagName("Dossiers");
            foreach (XmlNode item in xmlMeh)
            {
                if (item.SelectSingleNode("\\prestations") == null)
                {
                    DateTime dateDossierVide = new DateTime(
                    Convert.ToInt32(listeDossiers[0].ChildNodes[2].ChildNodes[0].InnerXml),
                    Convert.ToInt32(listeDossiers[0].ChildNodes[2].ChildNodes[1].InnerXml),
                    Convert.ToInt32(listeDossiers[0].ChildNodes[2].ChildNodes[2].InnerXml));
                    // Instantiation d'un dossier vide
                    Dossier unDossierVide = new Dossier(listeDossiers[0].ChildNodes[0].InnerXml, listeDossiers[0].ChildNodes[1].InnerXml, dateDossierVide);
                } 
            }

        }
    }
}
