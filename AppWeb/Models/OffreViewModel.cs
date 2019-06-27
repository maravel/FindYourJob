using AppWeb.Ressources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AppWeb.Models
{
    /// <summary>
    /// Classe d'affichage représentant une offre.
    /// </summary>
    public class OffreViewModel
    {
        /// <summary>Identifiant (primary key)</summary>
        public int Id { get; set; }

        /// <summary>Intitulé d'une offre</summary>
        [Display(Name = "Intitule", ResourceType = typeof(ResourceEN))]
        public string Intitule { get; set; }

        /// <summary>Date de l'offre</summary>
        [Display(Name = "Date", ResourceType = typeof(ResourceEN))]
        public DateTime Date { get; set; }

        /// <summary>Salaire proposé par l'offre</summary>
        [Display(Name = "Salaire", ResourceType = typeof(ResourceEN))]
        public double Salaire { get; set; }

        /// <summary>Description d'une offre</summary>
        [Display(Name = "Description", ResourceType = typeof(ResourceEN))]
        public string Description { get; set; }

        /// <summary>L'id du <see cref="Statut"/> de l'offre</summary>
        public int StatutId { get; set; }
        
        /// <summary>Responsable de l'offre</summary>
        [Display(Name = "Responsable", ResourceType = typeof(ResourceEN))]
        public string Responsable { get; set; }

        /// <summary>Statut de l'offre</summary>
        public StatutViewModel Statut { get; set; }

        /// <summary>Affire sur l'utilisateur connecté a postulé à l'offre.</summary>
        public bool isApplied { get; set; }
        
        public List<StatutViewModel> Statuts { get; set; }
    }
}