using System;
using System.ComponentModel.DataAnnotations;

namespace AppWeb.Models
{
    /// <summary>Entité représentant une formation</summary>
    public class FormationViewModel
    {
        /// <summary>Identifiant (primary key)</summary>
        public int Id { get; set; }

        /// <summary>Intitulé d'une formation</summary>
        [Display(Name = "Intitulé")]
        public string Intitule { get; set; }

        /// <summary>Date d'une offre</summary>
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        /// <summary>L'id de l'<see cref="Employe"/> participant à la formation</summary>
        public int EmployeId { get; set; }

        /// <summary>L'<see cref="Employe"/> participant à la formation</summary>
        [Display(Name = "Employé")]
        public EmployeViewModel Employe { get; set; }
    }
}