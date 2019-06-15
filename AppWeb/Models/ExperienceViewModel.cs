using System;
using System.ComponentModel.DataAnnotations;

namespace AppWeb.Models
{
    /// <summary>Entité représentant une expérience</summary>
    public class ExperienceViewModel
    {
        /// <summary>Identifiant (primary key)</summary>
        public int Id { get; set; }

        /// <summary>L'id de l'<see cref="Employe"/> ayant acquis cette expérience</summary>
        public int EmployeId { get; set; }

        /// <summary>Intitulé d'une expérience</summary>
        [Display(Name = "Intitulé")]
        public string Intitule { get; set; }

        /// <summary>Date d'une expérience</summary>
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        /// <summary>L'<see cref="Employe"/> ayant acquis cette expérience</summary>
        [Display(Name = "Employé")]
        public EmployeViewModel Employe { get; set; }
    }
}
