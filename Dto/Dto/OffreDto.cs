using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Dto
{
    [DataContract]
    public class OffreDto
    {
        /// <summary>Identifiant (primary key)</summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>Intitulé d'une offre</summary>
        [DataMember]
        public string Intitule { get; set; }

        /// <summary>Date de l'offre</summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>Salaire proposé par l'offre</summary>
        [DataMember]
        public double Salaire { get; set; }

        /// <summary>Description d'une offre</summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>L'id du <see cref="Statut"/> de l'offre</summary>
        [DataMember]
        public int StatutId { get; set; }

        /// <summary><see cref="Statut"/> d'une offre</summary>
        [DataMember]
        public StatutDto Statut { get; set; }

        /// <summary>Responsable de l'offre</summary>
        [DataMember]
        public string Responsable { get; set; }
    }
}
