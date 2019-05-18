using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees.Entity
{
    /// <summary>Entité représentant un statut</summary>
    public class Statut
    {
        /// <summary>Identifiant (primary key)</summary>
        public int Id { get; set; }

        /// <summary>Libellé d'un statut</summary>
        public string Libelle { get; set; }

        /// <summary>Offres</summary>
        public List<Offre> Offres { get; set; }
    }
}
