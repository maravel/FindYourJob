using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Interface du Service de gestion des données relatives à l'application
    /// </summary>
    public interface IService
    {
        
        #region Employés

        /// <summary>
        /// Obtient une liste d'employés selon les critères
        /// </summary>
        /// <param name="id">Critère identifiant</param>
        /// <returns>Liste d'employés</returns>
        Task<List<Employe>> GetEmployes(int? id = null);

        /// <summary>
        /// Crée ou modifie un employé
        /// </summary>
        /// <param name="employe">L'employé</param>
        /// <param name="isNew">Valeur à true si création, false si modification</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        Task<Result> AddUpdateEmploye(Employe employe, bool isNew);

        /// <summary>
        /// Supprime un employé à partir de son identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'employé à supprimer</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        Task<Result> RemoveEmploye(int id);

        #endregion

        #region Offre

        Task<List<Offre>> GetOffres(int? id = null);

        #endregion

        #region Formation

        Task<List<Formation>> GetFormations(int? id = null);

        #endregion

        #region Postulation

        Task<List<Postulation>> GetPostulations(int? employeId = null, int? offreId = null);

        #endregion

        #region Status

        Task<List<Statut>> GetStatuts(int? id = null);

        #endregion

        #region Expériences

        Task<List<Experience>> GetExperiences(int? id = null);

        Task<Result> AddUpdateExperience(Experience ex, bool isNew);

        #endregion

    }
}
