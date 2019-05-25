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

        /// <summary>
        /// Obtient une liste d'offres selon les critères
        /// </summary>
        /// <param name="id">Critère identifiant</param>
        /// <returns>Liste d'offres</returns>
        Task<List<Offre>> GetOffres(int? id = null);

        /// <summary>
        /// Crée ou modifie une offre
        /// </summary>
        /// <param name="offre">L'offre</param>
        /// <param name="isNew">Valeur à true si création, false si modification</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        Task<Result> AddUpdateOffre(Offre offre, bool isNew);

        /// <summary>
        /// Supprime une offre à partir de son identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'offre à supprimer</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        Task<Result> RemoveOffre(int id);



        #endregion

        #region Formation

        /// <summary>
        /// Obtient une liste de formations selon les critères
        /// </summary>
        /// <param name="id">Critère identifiant</param>
        /// <returns>Liste de formations</returns>
        Task<List<Formation>> GetFormations(int? id = null);

        /// <summary>
        /// Crée ou modifie une formation
        /// </summary>
        /// <param name="formation">La formation</param>
        /// <param name="isNew">Valeur à true si création, false si modification</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        Task<Result> AddUpdateFormation(Formation formation, bool isNew);

        /// <summary>
        /// Supprime une formation à partir de son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la formation à supprimer</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        Task<Result> RemoveFormation(int id);

        #endregion

        #region Postulation

        /// <summary>
        /// Obtient une liste de postulations selon les critères
        /// </summary>
        /// <param name="id">Critère identifiant</param>
        /// <returns>Liste de postulations</returns>
        Task<List<Postulation>> GetPostulations(int? employeId = null, int? offreId = null);

        /// <summary>
        /// Crée ou modifie une postulation
        /// </summary>
        /// <param name="postulation">La postulation</param>
        /// <param name="isNew">Valeur à true si création, false si modification</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        Task<Result> AddUpdatePostulation(Postulation employe, bool isNew);

        /// <summary>
        /// Supprime un postulation à partir de son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la postulation à supprimer</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        Task<Result> RemovePostulation(int employeId, int offreId);

        #endregion

        #region Statut

        /// <summary>
        /// Obtient une liste de statuts selon les critères
        /// </summary>
        /// <param name="id">Critère identifiant</param>
        /// <returns>Liste de statuts</returns>
        Task<List<Statut>> GetStatuts(int? id = null);

        /// <summary>
        /// Crée ou modifie un statut
        /// </summary>
        /// <param name="statut">Le statut</param>
        /// <param name="isNew">Valeur à true si création, false si modification</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        Task<Result> AddUpdateStatut(Statut formation, bool isNew);

        /// <summary>
        /// Supprime un statut à partir de son identifiant
        /// </summary>
        /// <param name="id">Identifiant de le statut à supprimer</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        Task<Result> RemoveStatut(int id);

        #endregion

        #region Expériences

        /// <summary>
        /// Obtient une liste d'expériences selon les critères
        /// </summary>
        /// <param name="id">Critère identifiant</param>
        /// <returns>Liste d'expériences</returns>
        Task<List<Experience>> GetExperiences(int? id = null);

        /// <summary>
        /// Crée ou modifie une expérience
        /// </summary>
        /// <param name="exp">L'expérience</param>
        /// <param name="isNew">Valeur à true si création, false si modification</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        Task<Result> AddUpdateExperience(Experience exp, bool isNew);

        /// <summary>
        /// Supprime une expérience à partir de son identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'expérience à supprimer</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        Task<Result> RemoveExperience(int id);

        #endregion

    }
}
