using AppWeb.Ressources;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppWeb.Models
{
    /// <summary>
    /// Classe représentant un statut
    /// </summary>
    public class StatutViewModel
    {
        /// <summary>Identifiant (primary key)</summary>
        public int Id { get; set; }

        /// <summary>Libellé d'un statut</summary>
        [Display(Name = "Libelle", ResourceType = typeof(ResourceEN))]
        public string Libelle { get; set; }
    }
}