using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classesMetier;
using System.Xml;

namespace PresSoins
{
    public abstract class GestionXML
    {

        public static Dossier XMLToDossier(XmlNode node)
        {
            var nom = node.ChildNodes[0].InnerText;
            var prenom = node.ChildNodes[1].InnerText;
            DateTime ddn = new DateTime(Convert.ToInt32(node.ChildNodes[2].ChildNodes[0].InnerText),
                Convert.ToInt32(node.ChildNodes[2].ChildNodes[1].InnerText),
                Convert.ToInt32(node.ChildNodes[2].ChildNodes[2].InnerText));
            
            // Si le dossier contient un Intervenant
            if (node.SelectSingleNode("intervenant") == null)
            {
                
                return new Dossier();
            }
            else if (node.SelectSingleNode("prestation") == null)
            {
                return new Dossier();
            }
            else return new Dossier(nom, prenom, ddn);
        }

        public static Prestation XMLToPrestation(XmlNode node)
        {


            Prestation unePres = new Prestation();
            return unePres;
        }

        public static DateTime getDatePrestation(XmlNode node)
        {
            return new DateTime();
        }
        public static DateTime getHeurePrestation(XmlNode node)
        {
            
            return new DateTime();
        }

        public static Intervenant XMLToIntervenant(XmlNode node)
        {
            string nomIntervenant = node.ChildNodes[0].InnerText;
            string prenomIntervenant = node.ChildNodes[1].InnerText;
            if (node.SelectSingleNode("specialite") == null)
            {
                return new Intervenant(nomIntervenant, prenomIntervenant);
            }
            else
            {
                return new IntervenantExterne(nomIntervenant, prenomIntervenant, node.ChildNodes[2].InnerText, node.ChildNodes[3].InnerText, node.ChildNodes[4].InnerText);
            }
        }

    }
}
