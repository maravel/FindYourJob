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

        /// <summary>Liste d'<see cref="Offre"/> possèdant le statut</summary>
        public List<Offre> Offres { get; set; }

        /// <summary>Liste d'<see cref="Postulation"/> possèdant le statut</summary>
        public List<Postulation> Postulations { get; set; }
    }
}
