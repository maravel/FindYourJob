using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Dto
{
    /// <summary>Dto représentant une experience</summary>
    [DataContract]
    public class ExperienceDto
    {
        /// <summary>Identifiant (primary key)</summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>L'id de l'<see cref="Employe"/> ayant acquis cette expérience</summary>
        [DataMember]
        public int EmployeId { get; set; }

        /// <summary>Intitulé d'une expérience</summary>
        [DataMember]
        public string Intitule { get; set; }

        /// <summary>Date d'une expérience</summary>
        [DataMember]
        public DateTime Date { get; set; }

    }
}
