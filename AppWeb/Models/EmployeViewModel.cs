using AppWeb.Ressources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppWeb.Models
{
    /// <summary>
    /// Classe d'affichage représentant un employé
    /// </summary>
    public class EmployeViewModel
    {
        /// <summary>Identifiant (primary key)</summary>
        public int Id { get; set; }

        /// <summary>Nom de l'employé</summary>
        [Display(Name = "Nom", ResourceType = typeof(ResourceEN))]
        public string Nom { get; set; }

        /// <summary>Prénom de l'employé</summary>
        [Display(Name = "Prenom", ResourceType = typeof(ResourceEN))]
        public string Prenom { get; set; }

        /// <summary>Date de naissance de l'employé</summary>
        [Display(Name = "DateNaissance", ResourceType = typeof(ResourceEN))]
        public DateTime DateNaissance { get; set; }

        /// <summary>Ancienneté de l'employé dans l'entreprise</summary>
        [Display(Name = "Anciennete", ResourceType = typeof(ResourceEN))]
        public int Anciennete { get; set; }

        /// <summary>Biographie de l'employé</summary>
        [Display(Name = "Biographie", ResourceType = typeof(ResourceEN))]
        public string Biographie { get; set; }

        /// <summary>Liste des <see cref="Experience"/> de l'employé</summary>
        public List<ExperienceViewModel> Experiences { get; set; }

        /// <summary>Liste des <see cref="Formation"/> de l'employé</summary>
        public List<FormationViewModel> Formations { get; set; }

        /// <summary>Liste des <see cref="Postulation"/> de l'employé</summary>
        public List<PostulationViewModel> Postulations { get; set; }

        /// <summary>Les offres pour lesquelles l'employé à postulé</summary>
        public List<OffreViewModel> OffresPostulees { get; set; }

        /// <summary>true si c'est l'utilisateur connecté</summary>
        public bool IsConnectedUser { get; set; }
    }
}
