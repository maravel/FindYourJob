using AppWeb.Ressources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWeb.Models
{
    /// <summary>
    /// Classe d'affichage représentant une postulation.
    /// </summary>
    public class PostulationViewModel
    {
        /// <summary>L'id d'une <see cref="Offre"/> (primary key)</summary>
        public int OffreId { get; set; }

        /// <summary>L'id d'un <see cref="Employe"/> (primary key)</summary>
        public int EmployeId { get; set; }

        /// <summary>Date de la postulation</summary>
        [Display(Name = "Date", ResourceType = typeof(ResourceEN))]
        public DateTime Date { get; set; }

        /// <summary>Identitidant du statut de la postulation</summary>
        public int StatutId { get; set; }
    }
}