using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees.Entity
{
    /// <summary>Entité représentant un employé"/></summary>
    public class Employe
    {
        /// <summary>Identifiant (primary key)</summary>
        public int Id { get; set; }

        /// <summary>Nom de l'employé</summary>
        public string Nom { get; set; }

        /// <summary>Prénom de l'employé</summary>
        public string Prenom { get; set; }

        /// <summary>Date de naissance de l'employé</summary>
        public DateTime DateNaissance { get; set; }

        /// <summary>Ancienneté de l'employé dans l'entreprise</summary>
        public int Anciennete { get; set; }

        /// <summary>Biographie de l'employé</summary>
        public string Biographie { get; set; }

        /// <summary>Liste des <see cref="Experience"/> de l'employé</summary>
        public List<Experience> Experiences { get; set; }

        /// <summary>Liste des <see cref="Formation"/> de l'employé</summary>
        public List<Formation> Formations { get; set; }
    }
}
