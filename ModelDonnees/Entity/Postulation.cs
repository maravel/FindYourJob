using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees.Entity
{
    /// <summary>Entité représentant une postulation</summary>
    [DataContract]
    public class Postulation
    {
        /// <summary>L'id d'une <see cref="Offre"/> (primary key)</summary>
        [DataMember]
        public int OffreId { get; set; }

        /// <summary>L'id d'un <see cref="Employe"/> (primary key)</summary>
        [DataMember]
        public int EmployeId { get; set; }

        /// <summary>L'<see cref="Employe"/> concerné</summary>
        [DataMember]
        public Employe Employe { get; set; }

        /// <summary>Date de la postulation</summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>Identitidant du statut de la postulation</summary>
        [DataMember]
        public int StatutId { get; set; }

        /// <summary>Statut de la postulation</summary>
        [DataMember]
        public Statut Statut { get; set; }

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
