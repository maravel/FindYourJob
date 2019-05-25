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
    public class Service : IService
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
        /// <returns>Liste d'employés</returns>
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

                if(entity == null)
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

        #endregion
        
        #region Offre

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

        #endregion
        
        #region Postulation

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

        #endregion

        #region Statuts

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

        #endregion

        #region Experiences


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
