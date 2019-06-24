using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppWeb.Models
{
    /// <summary>Entité représentant un employé"/></summary>
    public class EmployeViewModel
    {
        /// <summary>Identifiant (primary key)</summary>
        public int Id { get; set; }

        /// <summary>Nom de l'employé</summary>
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        /// <summary>Prénom de l'employé</summary>
        [Display(Name = "Prenom")]
        public string Prenom { get; set; }

        /// <summary>Date de naissance de l'employé</summary>
        [Display(Name = "Date de Naissance")]
        public DateTime DateNaissance { get; set; }

        /// <summary>Ancienneté de l'employé dans l'entreprise</summary>
        [Display(Name = "Ancienneté")]
        public int Anciennete { get; set; }

        /// <summary>Biographie de l'employé</summary>
        [Display(Name = "Biographie")]
        public string Biographie { get; set; }

        /// <summary>Liste des <see cref="Experience"/> de l'employé</summary>
        public List<ExperienceViewModel> Experiences { get; set; }

        /// <summary>Liste des <see cref="Formation"/> de l'employé</summary>
        public List<FormationViewModel> Formations { get; set; }

        /// <summary>Liste des <see cref="Postulation"/> de l'employé</summary>
        public List<PostulationViewModel> Postulations { get; set; }

        public List<OffreViewModel> OffresPostulees { get; set; }
    }
}
