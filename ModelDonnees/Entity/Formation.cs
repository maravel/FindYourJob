using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees.Entity
{
    /// <summary>Entité représentant une formation</summary>
    public class Formation
    {
        /// <summary>Identifiant (primary key)</summary>
        public int Id { get; set; }

        /// <summary>Intitulé d'une formation</summary>
        public string Intitule { get; set; }

        /// <summary>Date d'une offre</summary>
        public DateTime Date { get; set; }

        /// <summary>L'id de l'<see cref="Employe"/> participant à la formation</summary>
        public int EmployeId { get; set; }

        /// <summary>L'<see cref="Employe"/> participant à la formation</summary>
        public Employe Emmploye { get; set; }
    }
}
