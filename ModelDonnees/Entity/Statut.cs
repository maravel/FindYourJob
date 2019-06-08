using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees.Entity
{
    /// <summary>Entité représentant un statut</summary>
    [DataContract]
    public class Statut
    {
        /// <summary>Identifiant (primary key)</summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>Libellé d'un statut</summary>
        [DataMember]
        public string Libelle { get; set; }

        /// <summary>Liste d'<see cref="Offre"/> possèdant le statut</summary>
        [DataMember]
        public List<Offre> Offres { get; set; }

        /// <summary>Liste d'<see cref="Postulation"/> possèdant le statut</summary>
        [DataMember]
        public List<Postulation> Postulations { get; set; }
    }
}
