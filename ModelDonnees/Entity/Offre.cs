using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees.Entity
{
    /// <summary>Entité représentant une offre</summary>
    public class Offre
    {
        /// <summary>Identifiant (primary key)</summary>
        public int Id { get; set; }

        /// <summary>Intitulé d'une offre</summary>
        public string Intitule { get; set; }

        /// <summary>Date de l'offre</summary>
        public DateTime Date { get; set; }

        /// <summary>Salaire proposé par l'offre</summary>
        public double Salaire { get; set; }

        /// <summary>Description d'une offre</summary>
        public string Description { get; set; }

        /// <summary>L'id du <see cref="Statut"/> de l'offre</summary>
        public int StatutId { get; set; }

        /// <summary><see cref="ModelDonnees.Entity.Statut"/> d'une offre</summary>
        public Statut Statut { get; set; }

        /// <summary>Responsable de l'offre</summary>
        public string Responsable { get; set; }

    }
}
