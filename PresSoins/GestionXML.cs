using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classesMetier;
using System.Xml;
using System.IO;

namespace PresSoins
{
    public abstract class GestionXML
    {
        /// <summary>
        /// Recupére un dossier
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static Dossier XMLToDossier(XmlNode nodeDossier)
        {
            var nom = nodeDossier.ChildNodes[0].InnerText;
            var prenom = nodeDossier.ChildNodes[1].InnerText;
            DateTime date = getDate(nodeDossier.ChildNodes[2], true);

         if (nodeDossier.SelectSingleNode("prestations") == null)
            {
                // Si le dossier n'a qu'une seule prestation
                //   if (nodeDossier.ChildNodes[4].SelectNodes("prestation").Count <= 1)
                //   return new Dossier(nom, prenom, date, XMLToPrestation(nodeDossier.ChildNodes[3].ChildNodes[0]));
                // sinon, donc si le dossier à plusieurs prestations

                //  else return new Dossier(nom, prenom, date, XMLToListePrestations(nodeDossier.ChildNodes[3]));
                return new Dossier(nom, prenom, date, XMLToListePrestations(nodeDossier.ChildNodes[3]));

            }
            else return new Dossier(nom, prenom, date);
        }
        /// <summary>
        /// Recupére une prestation
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static Prestation XMLToPrestation(XmlNode nodePrestation)
        {
            String libelle = nodePrestation.ChildNodes[0].InnerText;
            DateTime datePrestation = getDate(nodePrestation.ChildNodes[1], true);
            DateTime heurePrestation = getDate(nodePrestation.ChildNodes[1], false);
            Intervenant unInter = XMLToIntervenant(nodePrestation.ChildNodes[2]);
            return new Prestation(libelle, datePrestation, heurePrestation, unInter);
        }
        /// <summary>
        /// Recupére une liste de Prestations
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static List<Prestation> XMLToListePrestations(XmlNode nodePrestations)
        {


            string fileName = "jeudEssai.xml";
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList lesPrestations = doc.GetElementsByTagName("prestations");
            List<Prestation> mesPres = new List<Prestation>();

            var meh = nodePrestations.SelectNodes("prestation").Count;
            for (int i = 0; i < nodePrestations.SelectNodes("prestations").Count; i++)
            {
                mesPres.Add(XMLToPrestation(nodePrestations));
            }
            return mesPres;
        }



        public static List<Prestation> XMLToListePrestations(XmlNodeList nodePrestations)
        {
            var count = nodePrestations.Count;
            List<Prestation> mesPres = new List<Prestation>();


            for (int i = 0; i < count; i++)
            {
                mesPres.Add(XMLToPrestation(nodePrestations[i]));
            }
            return mesPres;
        }
        
        /// <summary>
        /// Permet de récupérer une DateTame , si dateOnly est vrai on retourne YYYY/MM/JJ sinon on retourne YYYY/MM/JJ/HH/MI/SS
        /// </summary>
        /// <param name="nodeDate"></param>
        /// <returns></returns>
        public static DateTime getDate(XmlNode nodeDate, Boolean dateOnly)
        {
            var meh = nodeDate.ChildNodes[0].InnerText + " - " + nodeDate.ChildNodes[1].InnerText + " - " +  nodeDate.ChildNodes[2].InnerText;
            var yyyy = Convert.ToInt32(nodeDate.ChildNodes[0].InnerText);
            var mm = Convert.ToInt32(nodeDate.ChildNodes[1].InnerText);
            var jj = Convert.ToInt32(nodeDate.ChildNodes[2].InnerText);

            //           if (dateOnly) return new DateTime(yyyy, mm, jj);
            if (dateOnly) return new DateTime(yyyy, mm, jj);

            else {
                var hh = Convert.ToInt32(nodeDate.ChildNodes[3].InnerText);
                var mi = Convert.ToInt32(nodeDate.ChildNodes[4].InnerText);
                return new DateTime(yyyy, mm, jj, hh, mi, 00);
            }
        }
        /// <summary>
        /// Retourne un intervenant Interne ou Externe
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static Intervenant XMLToIntervenant(XmlNode node)
        {
            string nomIntervenant = node.ChildNodes[0].InnerText;
            string prenomIntervenant = node.ChildNodes[1].InnerText;
            if (node.SelectSingleNode("specialite") == null)return new Intervenant(nomIntervenant, prenomIntervenant);
            else return new IntervenantExterne(nomIntervenant, prenomIntervenant, node.ChildNodes[2].InnerText, node.ChildNodes[3].InnerText, node.ChildNodes[4].InnerText);

        }

    }
}
