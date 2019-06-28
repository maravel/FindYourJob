using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees
{
    /// <summary>
    /// Initialise le context avec des données
    /// </summary>
    public class Initializer : DropCreateDatabaseIfModelChanges<ContextDA>
    {
        protected override void Seed(ContextDA context)
        {
            context.Statuts.Add(new Statut() { Libelle = "Disponible" });
            context.Statuts.Add(new Statut() { Libelle = "Indisponible" });

            int id_statut_1 = context.Statuts.FirstOrDefault().Id;
            int id_statut_2 = context.Statuts.LastOrDefault().Id;

            context.Offres.Add(new Offre() {
                Intitule = "DÉVELOPPEUR C#",
                Date = DateTime.Parse("05/11/2018"),
                Description = "Il s’agit d’une mission qui sera basée à Londres dans un 1er temps (6 mois à Canary Wharf) puis dans les locaux du client, en Ile-de-France (La Défense). (tous les frais d'hébergement + transports les 6 premiers mois sont pris en charge)",
                Responsable = "Aubay",
                Salaire = 2000,
                StatutId = id_statut_1
            });

            context.Offres.Add(new Offre()
            {
                Intitule = "Responsable Infrastructure et Applications h/f",
                Date = DateTime.Parse("05/12/2018"),
                Description = "Il s’agit d’une mission qui sera basée à Londres dans un 1er temps (6 mois à Canary Wharf) puis dans les locaux du client, en Ile-de-France (La Défense). (tous les frais d'hébergement + transports les 6 premiers mois sont pris en charge)",
                Responsable = "PMU",
                Salaire = 3000,
                StatutId = id_statut_1
            });

            context.Offres.Add(new Offre()
            {
                Intitule = "Développeur Python/Golang",
                Date = DateTime.Parse("10/05/2019"),
                Description = "EFFITEK est une ESN qui fournit des prestations de services informatiques dans le domaine des infrastructures. Ses prestations répondent aux enjeux et aux problématiques techniques de ses clients. L’entreprise poursuit sa croissance en 2016 avec la création d’une filiale dans les prestations de développement applicatif, qui se nomme Quovadev.",
                Responsable = "EFFITEK",
                Salaire = 1900,
                StatutId = id_statut_1
            });

            context.Offres.Add(new Offre()
            {
                Intitule = "Développeur IOS",
                Date = DateTime.Parse("09/09/2018"),
                Description = "EFFITEK est une ESN qui fournit des prestations de services informatiques dans le domaine des infrastructures. Ses prestations répondent aux enjeux et aux problématiques techniques de ses clients. L’entreprise poursuit sa croissance en 2016 avec la création d’une filiale dans les prestations de développement applicatif, qui se nomme Quovadev.",
                Responsable = "EFFITEK",
                Salaire = 2100,
                StatutId = id_statut_1
            });

            context.Offres.Add(new Offre()
            {
                Intitule = "Ingénieur système MICROSOFT",
                Date = DateTime.Parse("12/05/2019"),
                Description = " EFFITEK est une ESN qui fournit des prestations de services informatiques dans le domaine des infrastructures. Ses prestations répondent aux enjeux et aux problématiques techniques de ses clients. L’entreprise poursuit sa croissance en 2016 avec la création d’une filiale dans les prestations de développement applicatif, qui se nomme Quovadev.",
                Responsable = "EFFITEK",
                Salaire = 2101,
                StatutId = id_statut_1
            });

            context.Offres.Add(new Offre()
            {
                Intitule = "Ingénieur poste de travail",
                Date = DateTime.Parse("20/06/2019"),
                Description = "EFFITEK est une ESN qui fournit des prestations de services informatiques dans le domaine des infrastructures. Ses prestations répondent aux enjeux et aux problématiques techniques de ses clients. L’entreprise poursuit sa croissance en 2016 avec la création d’une filiale dans les prestations de développement applicatif, qui se nomme Quovadev.",
                Responsable = "EFFITEK",
                Salaire = 2150,
                StatutId = id_statut_2
            });

            context.Offres.Add(new Offre()
            {
                Intitule = "CHEF DE PROJET AUTOMATISATION",
                Date = DateTime.Parse("30/05/2019"),
                Description = "Vous aurez pour mission la conception des processus d'automatisation de la production graphique de la société ainsi que la responsabilité de leurs développements et de leur mise en œuvre :Missions :• Audit des différents processus existants au sein de nos unités de production",
                Responsable = "infolor",
                Salaire = 2150,
                StatutId = id_statut_2
            });

            context.Employes.Add(new Employe { Nom = "Ravel", Prenom = "Mathieu", Anciennete = 1, Biographie = "Super élève", DateNaissance = DateTime.Parse("04/09/1998") });
            context.Employes.Add(new Employe { Nom = "Aberthany", Prenom = "Dolores", Anciennete = 1000, Biographie = "Oldest host in the park", DateNaissance = DateTime.Parse("04/09/1900") });
            
            base.Seed(context);
        }
    }
}
