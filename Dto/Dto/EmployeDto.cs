using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Dto
{
    /// <summary>Dto représentant un employe</summary>
    [DataContract]
    public class EmployeDto
    {
        /// <summary>Identifiant (primary key)</summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>Nom de l'employé</summary>
        [DataMember]
        public string Nom { get; set; }

        /// <summary>Prénom de l'employé</summary>
        [DataMember]
        public string Prenom { get; set; }

        /// <summary>Date de naissance de l'employé</summary>
        [DataMember]
        public DateTime DateNaissance { get; set; }

        /// <summary>Ancienneté de l'employé dans l'entreprise</summary>
        [DataMember]
        public int Anciennete { get; set; }

        /// <summary>Biographie de l'employé</summary>
        [DataMember]
        public string Biographie { get; set; }

        /// <summary>Liste des <see cref="Experience"/> de l'employé</summary>
        public List<ExperienceDto> Experiences { get; set; }

        /// <summary>Liste des <see cref="Formation"/> de l'employé</summary>
        public List<FormationDto> Formations { get; set; }

        /// <summary>Liste des <see cref="Postulation"/> de l'employé</summary>
        public List<PostulationDto> Postulations { get; set; }
    }
}
