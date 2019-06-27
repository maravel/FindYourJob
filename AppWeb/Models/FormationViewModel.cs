using AppWeb.Ressources;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppWeb.Models
{
    /// <summary>Classe d'affichage représentant une formation</summary>
    public class FormationViewModel
    {
        /// <summary>Identifiant (primary key)</summary>
        public int Id { get; set; }

        /// <summary>Intitulé d'une formation</summary>
        [Display(Name = "Intitule", ResourceType = typeof(ResourceEN))]
        public string Intitule { get; set; }

        /// <summary>Date d'une offre</summary>
        [Display(Name = "Date", ResourceType = typeof(ResourceEN))]
        public DateTime Date { get; set; }

        /// <summary>L'id de l'<see cref="Employe"/> participant à la formation</summary>
        public int EmployeId { get; set; }

        /// <summary>L'<see cref="Employe"/> participant à la formation</summary>
        [Display(Name = "Employe", ResourceType = typeof(ResourceEN))]
        public EmployeViewModel Employe { get; set; }
    }
}