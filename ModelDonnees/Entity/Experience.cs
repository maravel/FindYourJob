using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees.Entity
{
    /// <summary>Entité représentant une expérience</summary>
    public class Experience
    {
        /// <summary>Identifiant (primary key)</summary>
        public int Id { get; set; }

        /// <summary>L'id de l'<see cref="Employe"/> ayant acquis cette expérience</summary>
        public int EmployeId { get; set; }

        /// <summary>Intitulé d'une expérience</summary>
        public string Intitule { get; set; }

        /// <summary>Date d'une expérience</summary>
        public DateTime Date { get; set; }

        /// <summary>L'<see cref="Employe"/> ayant acquis cette expérience</summary>
        public Employe Employe { get; set; }
    }
}
