using ModelDonnees;
using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Service de gestion des données relatives à l'application
    /// </summary>
    public class Service
    {
        private ContextDA DbContext { get; set; }

        public Service()
        {
            DbContext = new ContextDA();
        }

        #region Employés
        
        /// <summary>
        /// Obtient une liste d'employés selon les critères
        /// </summary>
        /// <param name="id">Critère identifiant</param>
        /// <returns>Liste d'<see cref="Employe"/></returns>
        public async Task<List<Employe>> GetEmployes(int? id = null)
        {
            try
            {
                if (id.HasValue)
                {
                    return await DbContext.Employes.Where(e => e.Id == id.Value).ToListAsync();
                }
                return await DbContext.Employes.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Crée ou modifie un employé
        /// </summary>
        /// <param name="employe">L'employé</param>
        /// <param name="isNew">Valeur à true si création, false si modification</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        public async Task<Result> AddUpdateEmploye(Employe employe, bool isNew)
        {
            try
            {
                Employe entity = await DbContext.Employes.Where(e => e.Id == employe.Id).SingleOrDefaultAsync();

                if(isNew && entity == null)
                {
                    entity = employe;
                    DbContext.Employes.Add(entity);
                }
                else if(!isNew && entity != null)
                {
                    entity.Nom = employe.Nom;
                    entity.Prenom = employe.Prenom;
                    entity.Anciennete = employe.Anciennete;
                    entity.Biographie = employe.Biographie;
                    entity.DateNaissance = employe.DateNaissance;
                }
                else
                {
                    if(isNew)
                    {
                        return new Result(TypeRetour.Error, "Employé déjà existant.");
                    }

                    return new Result(TypeRetour.Error, "Employé non trouvé.");
                }

                await DbContext.SaveChangesAsync();

                return new Result(TypeRetour.Success);
            }
            catch (Exception ex)
            {
                return new Result(TypeRetour.Error, ex.Message);
            }
        }

        /// <summary>
        /// Supprime un employé à partir de son identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'employé à supprimer</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        public async Task<Result> RemoveEmploye(int id)
        {
            try
            {
                Employe entity = await DbContext.Employes.Where(e => e.Id == id).SingleOrDefaultAsync();

                if (entity == null)
                {
                    return new Result(TypeRetour.Error, "Employé non trouvé.");
                }

                DbContext.Employes.Remove(entity);
                await DbContext.SaveChangesAsync();

                return new Result(TypeRetour.Success);
            }
            catch (Exception ex)
            {
                return new Result(TypeRetour.Error, ex.Message);
            }
        }

        #endregion

        #region Offres

        /// <summary>
        /// Obtient une liste d'offres selon les critères
        /// </summary>
        /// <param name="id">Critère identifiant</param>
        /// <returns>Liste d'<see cref="Offre"/></returns>
        public async Task<List<Offre>> GetOffres(int? id = null)
        {
            try
            {
                if (id.HasValue)
                {
                    return await DbContext.Offres.Where(o => o.Id == id.Value).ToListAsync();
                }

                return await DbContext.Offres.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Crée ou modifie une offre
        /// </summary>
        /// <param name="offre">L'offre</param>
        /// <param name="isNew">Valeur à true si création, false si modification</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        public async Task<Result> AddUpdateOffre(Offre offre, bool isNew)
        {
            try
            {
                Offre entity = await DbContext.Offres.Where(o => o.Id == offre.Id).SingleOrDefaultAsync();

                if (isNew && entity == null)
                {
                    entity = offre;
                    DbContext.Offres.Add(entity);
                }
                else if (!isNew && entity != null)
                {
                    entity.Date = offre.Date;
                    entity.Description = offre.Description;
                    entity.Intitule = offre.Intitule;
                    entity.Responsable = offre.Responsable;
                    entity.Salaire = offre.Salaire;
                    entity.Statut = offre.Statut;
                    entity.StatutId = offre.StatutId;
                }
                else
                {
                    if (isNew)
                    {
                        return new Result(TypeRetour.Error, "Offre déjà existante.");
                    }

                    return new Result(TypeRetour.Error, "Offre non trouvée.");
                }

                await DbContext.SaveChangesAsync();

                return new Result(TypeRetour.Success);
            }
            catch (Exception ex)
            {
                return new Result(TypeRetour.Error, ex.Message);
            }
        }

        /// <summary>
        /// Supprime une offre à partir de son identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'offre à supprimer</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        public async Task<Result> RemoveOffre(int id)
        {
            try
            {
                Offre entity = await DbContext.Offres.Where(o => o.Id == id).SingleOrDefaultAsync();

                if (entity == null)
                {
                    return new Result(TypeRetour.Error, "Offre non trouvée.");
                }

                DbContext.Offres.Remove(entity);
                await DbContext.SaveChangesAsync();

                return new Result(TypeRetour.Success);
            }
            catch (Exception ex)
            {
                return new Result(TypeRetour.Error, ex.Message);
            }
        }

        #endregion

        #region Formations

        /// <summary>
        /// Obtient une liste de formation selon les critères
        /// </summary>
        /// <param name="id">Critère identifiant</param>
        /// <returns>Liste de <see cref="Formation"/></returns>
        public async Task<List<Formation>> GetFormations(int? id = null)
        {
            try
            {
                if (id.HasValue)
                {
                    return await DbContext.Formations.Where(f => f.Id == id.Value).ToListAsync();
                }

                return await DbContext.Formations.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Crée ou modifie une formation
        /// </summary>
        /// <param name="formation">La formation</param>
        /// <param name="isNew">Valeur à true si création, false si modification</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        public async Task<Result> AddUpdateFormation(Formation formation, bool isNew)
        {
            try
            {
                Formation entity = await DbContext.Formations.Where(f => f.Id == formation.Id).SingleOrDefaultAsync();

                if (isNew && entity == null)
                {
                    entity = formation;
                    DbContext.Formations.Add(entity);
                }
                else if (!isNew && entity != null)
                {
                    entity.Date = formation.Date;
                    entity.EmployeId = formation.EmployeId;
                    entity.Intitule = formation.Intitule;
                    entity.Employe = formation.Employe;
                }
                else
                {
                    if (isNew)
                    {
                        return new Result(TypeRetour.Error, "Formation déjà existante.");
                    }

                    return new Result(TypeRetour.Error, "Formation non trouvée.");
                }

                await DbContext.SaveChangesAsync();

                return new Result(TypeRetour.Success);
            }
            catch (Exception ex)
            {
                return new Result(TypeRetour.Error, ex.Message);
            }
        }

        /// <summary>
        /// Supprime une formation à partir de son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la formation à supprimer</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        public async Task<Result> RemoveFormation(int id)
        {
            try
            {
                Formation entity = await DbContext.Formations.Where(f => f.Id == id).SingleOrDefaultAsync();

                if (entity == null)
                {
                    return new Result(TypeRetour.Error, "Formation non trouvée.");
                }

                DbContext.Formations.Remove(entity);
                await DbContext.SaveChangesAsync();

                return new Result(TypeRetour.Success);
            }
            catch (Exception ex)
            {
                return new Result(TypeRetour.Error, ex.Message);
            }
        }

        #endregion

        #region Postulations

        /// <summary>
        /// Obtient une liste de postulations selon les critères
        /// </summary>
        /// <param name="id">Critère identifiant</param>
        /// <returns>Liste de <see cref="Postulation"/></returns>
        public async Task<List<Postulation>> GetPostulations(int? employeId = null, int? offreId = null)
        {
            try
            {
                if (employeId.HasValue && offreId.HasValue)
                {
                    return await DbContext.Postulations.Where(p => p.EmployeId == employeId.Value && p.OffreId == offreId.Value).ToListAsync();
                }

                return await DbContext.Postulations.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Crée ou modifie une postulation
        /// </summary>
        /// <param name="postulation">La postulation</param>
        /// <param name="isNew">Valeur à true si création, false si modification</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        public async Task<Result> AddUpdatePostulation(Postulation postulation, bool isNew)
        {
            try
            {
                Postulation entity = await DbContext.Postulations.Where(p => p.EmployeId == postulation.EmployeId && p.OffreId == postulation.OffreId).SingleOrDefaultAsync();

                if (isNew && entity == null)
                {
                    entity = postulation;
                    DbContext.Postulations.Add(entity);
                }
                else if (!isNew && entity != null)
                {
                    entity.Date = postulation.Date;
                    entity.Statut = postulation.Statut;
                }
                else
                {
                    if (isNew)
                    {
                        return new Result(TypeRetour.Error, "Postulation déjà existante.");
                    }

                    return new Result(TypeRetour.Error, "Postulation non trouvée.");
                }

                await DbContext.SaveChangesAsync();

                return new Result(TypeRetour.Success);
            }
            catch (Exception ex)
            {
                return new Result(TypeRetour.Error, ex.Message);
            }
        }

        /// <summary>
        /// Supprime une postulation à partir de son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la postulation à supprimer</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        public async Task<Result> RemovePostulation(int employeId, int offreId)
        {
            try
            {
                Postulation entity = await DbContext.Postulations.Where(p => p.EmployeId == employeId && p.OffreId == offreId).SingleOrDefaultAsync();

                if (entity == null)
                {
                    return new Result(TypeRetour.Error, "Postulation non trouvée.");
                }

                DbContext.Postulations.Remove(entity);
                await DbContext.SaveChangesAsync();

                return new Result(TypeRetour.Success);
            }
            catch (Exception ex)
            {
                return new Result(TypeRetour.Error, ex.Message);
            }
        }

        #endregion

        #region Statuts

        /// <summary>
        /// Obtient une liste de statuts selon les critères
        /// </summary>
        /// <param name="id">Critère identifiant</param>
        /// <returns>Liste de <see cref="Statut"/></returns>
        public async Task<List<Statut>> GetStatuts(int? id = null)
        {
            try
            {
                if (id.HasValue)
                {
                    return await DbContext.Statuts.Where(s => s.Id == id.Value).ToListAsync();
                }

                return await DbContext.Statuts.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Crée ou modifie un statut
        /// </summary>
        /// <param name="statut">Le statut</param>
        /// <param name="isNew">Valeur à true si création, false si modification</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        public async Task<Result> AddUpdateStatut(Statut statut, bool isNew)
        {
            try
            {
                Statut entity = await DbContext.Statuts.Where(s => s.Id == statut.Id).SingleOrDefaultAsync();

                if (isNew && entity == null)
                {
                    entity = statut;
                    DbContext.Statuts.Add(entity);
                }
                else if (!isNew && entity != null)
                {
                    entity.Libelle = statut.Libelle;
                    entity.Offres = statut.Offres;
                }
                else
                {
                    if (isNew)
                    {
                        return new Result(TypeRetour.Error, "Statut déjà existant.");
                    }

                    return new Result(TypeRetour.Error, "Statut non trouvé.");
                }

                await DbContext.SaveChangesAsync();

                return new Result(TypeRetour.Success);
            }
            catch (Exception ex)
            {
                return new Result(TypeRetour.Error, ex.Message);
            }
        }

        /// <summary>
        /// Supprime un statut à partir de son identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'expérience à supprimer</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        public async Task<Result> RemoveStatut(int id)
        {
            try
            {
                Statut entity = await DbContext.Statuts.Where(s => s.Id == id).SingleOrDefaultAsync();

                if (entity == null)
                {
                    return new Result(TypeRetour.Error, "Statut non trouvé.");
                }

                DbContext.Statuts.Remove(entity);
                await DbContext.SaveChangesAsync();

                return new Result(TypeRetour.Success);
            }
            catch (Exception ex)
            {
                return new Result(TypeRetour.Error, ex.Message);
            }
        }

        #endregion

        #region Experiences

        /// <summary>
        /// Obtient une liste de expériences selon les critères
        /// </summary>
        /// <param name="id">Critère identifiant</param>
        /// <returns>Liste de <see cref="Experience"/></returns>
        public async Task<List<Experience>> GetExperiences(int? id = null)
        {
            try
            {
                if (id.HasValue)
                {
                    return await DbContext.Experiences.Where(e => e.Id == id.Value).ToListAsync();
                }

                return await DbContext.Experiences.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Crée ou modifie une expérience
        /// </summary>
        /// <param name="exp">L'expérience</param>
        /// <param name="isNew">Valeur à true si création, false si modification</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        public async Task<Result> AddUpdateExperience(Experience exp, bool isNew)
        {
            try
            {
                Experience entity = await DbContext.Experiences.Where(e => e.Id == exp.Id).SingleOrDefaultAsync();

                if (isNew && entity == null)
                {
                    entity = exp;
                    DbContext.Experiences.Add(entity);
                }
                else if (!isNew && entity != null)
                {
                    entity.Intitule = exp.Intitule;
                }
                else
                {
                    if (isNew)
                    {
                        return new Result(TypeRetour.Error, "Expérience déjà existant.");
                    }

                    return new Result(TypeRetour.Error, "Expérience non trouvé.");
                }

                await DbContext.SaveChangesAsync();

                return new Result(TypeRetour.Success);
            }
            catch (Exception ex)
            {
                return new Result(TypeRetour.Error, ex.Message);
            }
        }

        /// <summary>
        /// Supprime une expérience à partir de son identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'expérience à supprimer</param>
        /// <returns>Un <see cref="Result"/> avec le type de retour</returns>
        public async Task<Result> RemoveExperience(int id)
        {
            try
            {
                Experience entity = await DbContext.Experiences.Where(e => e.Id == id).SingleOrDefaultAsync();

                if (entity == null)
                {
                    return new Result(TypeRetour.Error, "Expérience non trouvé.");
                }

                DbContext.Experiences.Remove(entity);
                await DbContext.SaveChangesAsync();

                return new Result(TypeRetour.Success);
            }
            catch (Exception ex)
            {
                return new Result(TypeRetour.Error, ex.Message);
            }
        }

        #endregion

    }
}
