using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWeb.Models
{
    public class OffreViewModel
    {
        /// <summary>Identifiant (primary key)</summary>
        public int Id { get; set; }

        /// <summary>Intitulé d'une offre</summary>
        [Display(Name = "Intitulé")]
        public string Intitule { get; set; }

        /// <summary>Date de l'offre</summary>
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        /// <summary>Salaire proposé par l'offre</summary>
        [Display(Name = "Salaire")]
        public double Salaire { get; set; }

        /// <summary>Description d'une offre</summary>
        [Display(Name = "Description")]
        public string Description { get; set; }

        /// <summary>L'id du <see cref="Statut"/> de l'offre</summary>
        public int StatutId { get; set; }
        
        /// <summary>Responsable de l'offre</summary>
        [Display(Name = "Responsable")]
        public string Responsable { get; set; }
    }
}