using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees.Entity
{
    /// <summary>Entité représentant une postulation</summary>
    public class Postulation
    {
        /// <summary>L'id d'une <see cref="Offre"/> (primary key)</summary>
        public int OffreId { get; set; }

        /// <summary>L'id d'un <see cref="Employe"/> (primary key)</summary>
        public int EmployeId { get; set; }

        /// <summary>Date de la postulation</summary>
        public DateTime Date { get; set; }

        /// <summary>Statut de la postulation</summary>
        public int Statut { get; set; }
        
    }
}
