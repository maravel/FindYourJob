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
    public class StatutDto
    {
        /// <summary>Identifiant (primary key)</summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>Libellé d'un statut</summary>
        [DataMember]
        public string Libelle { get; set; }
        
    }
}
