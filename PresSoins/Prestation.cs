using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classesMetier
{
    /// <summary>
    /// 
    /// </summary>
    public class Prestation
    {
        public string Libelle { get; }
        public DateTime DateSoin { get; }
        public DateTime HeureSoin { get; }
        public Intervenant L_intervenant { get; }

        /// <summary>
        /// Constructeur de la classe Prestation
        /// </summary>
        /// <param name="libelle"></param>
        /// <param name="dateSoin"></param>
        /// <param name="heureSoin"></param>
        /// <param name="intervenant"></param>
        public Prestation(string libelle, DateTime dateSoin,DateTime heureSoin, Intervenant intervenant )
        {
            this.Libelle = libelle;
            this.DateSoin = dateSoin;
            this.HeureSoin = heureSoin;
            this.L_intervenant = intervenant;
        }

    }
}
