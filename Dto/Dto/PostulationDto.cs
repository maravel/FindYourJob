using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Dto
{
    /// <summary>Dto représentant un statut</summary>
    [DataContract]
    public class PostulationDto
    {
        /// <summary>L'id d'une <see cref="Offre"/> (primary key)</summary>
        [DataMember]
        public int OffreId { get; set; }

        /// <summary>L'id d'un <see cref="Employe"/> (primary key)</summary>
        [DataMember]
        public int EmployeId { get; set; }
        
        /// <summary>Date de la postulation</summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>Identitidant du statut de la postulation</summary>
        [DataMember]
        public int StatutId { get; set; }
        

        /// <summary>Nom et prénom du postulant</summary>
        [DataMember]
        public string NomPrenomPostulant
        {
            get
            {
                return $"{Employe?.Nom} {Employe?.Prenom}";
            }
        }
    }
}
