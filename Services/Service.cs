using Dto.Dto;
using ModelDonnees;
using ModelDonnees.Entity;
using Services.Converter;
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
        /// <returns>Liste d'<see cref="EmployeDto"/></returns>
        public async Task<List<EmployeDto>> GetEmployes(int? id = null, bool includeData = false)
        {
            try
            {
                if (id.HasValue && includeData)
                {
                    return EmployeConverter.ConvertToDto(await DbContext.Employes.Include("Experiences").Include("Formations").Include("Postulations").Where(e => e.Id == id.Value).ToListAsync());
                }
                else if (id.HasValue)
                {
                    return EmployeConverter.ConvertToDto(await DbContext.Employes.Where(e => e.Id == id.Value).ToListAsync());
                }
                else if (includeData)
                {
                    return EmployeConverter.ConvertToDto(await DbContext.Employes.Include("Experiences").Include("Formations").Include("Postulations").ToListAsync());
                }

                return EmployeConverter.ConvertToDto(await DbContext.Employes.ToListAsync());
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

                if (isNew && entity == null)
                {
                    entity = employe;
                    DbContext.Employes.Add(entity);
                }
                else if (!isNew && entity != null)
                {
                    entity.Nom = employe.Nom;
                    entity.Prenom = employe.Prenom;
                    entity.Anciennete = employe.Anciennete;
                    entity.Biographie = employe.Biographie;
                    entity.DateNaissance = employe.DateNaissance;
                }
                else
                {
                    if (isNew)
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
        /// <returns>Liste d'<see cref="OffreDto"/></returns>
        public async Task<List<OffreDto>> GetOffres(int? id = null)
        {
            try
            {
                if (id.HasValue)
                {
                    return OffreConverter.ConvertToDto(await DbContext.Offres.Include("Statut").Where(o => o.Id == id.Value).ToListAsync());
                }
                return OffreConverter.ConvertToDto(await DbContext.Offres.Include("Statut").ToListAsync());
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
        public async Task<Result> AddUpdateOffre(OffreDto offre, bool isNew)
        {
            try
            {
                Offre entity = await DbContext.Offres.Where(o => o.Id == offre.Id).SingleOrDefaultAsync();

                if (isNew && entity == null)
                {
                    entity = OffreConverter.ConvertToEntity(offre);
                    DbContext.Offres.Add(entity);
                }
                else if (!isNew && entity != null)
                {
                    entity.Date = offre.Date;
                    entity.Description = offre.Description;
                    entity.Intitule = offre.Intitule;
                    entity.Responsable = offre.Responsable;
                    entity.Salaire = offre.Salaire;
                    entity.Statut = StatutConverter.ConvertToEntity(offre.Statut);
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
        /// <returns>Liste de <see cref="FormationDto"/></returns>
        public async Task<List<FormationDto>> GetFormations(int? id = null)
        {
            try
            {
                if (id.HasValue)
                {
                    return FormationConverter.ConvertToDto(await DbContext.Formations.Where(f => f.Id == id.Value).ToListAsync());
                }

                return FormationConverter.ConvertToDto(await DbContext.Formations.ToListAsync());
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
        public async Task<Result> AddUpdateFormation(FormationDto formation, bool isNew)
        {
            try
            {
                Formation entity = await DbContext.Formations.Where(f => f.Id == formation.Id).SingleOrDefaultAsync();

                if (isNew && entity == null)
                {
                    entity = FormationConverter.ConvertToEntity(formation);
                    DbContext.Formations.Add(entity);
                }
                else if (!isNew && entity != null)
                {
                    entity.Date = formation.Date;
                    entity.EmployeId = formation.EmployeId;
                    entity.Intitule = formation.Intitule;
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
        /// <returns>Liste de <see cref="PostulationDto"/></returns>
        public async Task<List<PostulationDto>> GetPostulations(int? employeId = null, int? offreId = null)
        {
            try
            {
                if (employeId.HasValue && offreId.HasValue)
                {
                    return PostulationConverter.ConvertToDto(await DbContext.Postulations.Where(p => p.EmployeId == employeId.Value && p.OffreId == offreId.Value).ToListAsync());
                }
                else if (employeId.HasValue)
                {
                    return PostulationConverter.ConvertToDto(await DbContext.Postulations.Where(p => p.EmployeId == employeId.Value).ToListAsync());
                }
                else if (offreId.HasValue)
                {
                    return PostulationConverter.ConvertToDto(await DbContext.Postulations.Where(p => p.OffreId == offreId.Value).ToListAsync());
                }

                return PostulationConverter.ConvertToDto(await DbContext.Postulations.ToListAsync());
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
        public async Task<Result> AddUpdatePostulation(PostulationDto postulation, bool isNew)
        {
            try
            {
                Postulation entity = await DbContext.Postulations.Where(p => p.EmployeId == postulation.EmployeId && p.OffreId == postulation.OffreId).SingleOrDefaultAsync();

                if (isNew && entity == null)
                {
                    entity = PostulationConverter.ConvertToEntity(postulation);
                    DbContext.Postulations.Add(entity);
                }
                else if (!isNew && entity != null)
                {
                    entity.Date = postulation.Date;
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
        /// <returns>Liste de <see cref="StatutDto"/></returns>
        public async Task<List<StatutDto>> GetStatuts(int? id = null)
        {
            try
            {
                if (id.HasValue)
                {
                    return StatutConverter.ConvertToDto(await DbContext.Statuts.Where(s => s.Id == id.Value).ToListAsync());
                }

                return StatutConverter.ConvertToDto(await DbContext.Statuts.ToListAsync());
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
        /// <returns>Liste de <see cref="ExperienceDto"/></returns>
        public async Task<List<ExperienceDto>> GetExperiences(int? id = null)
        {
            try
            {
                if (id.HasValue)
                {
                    return ExperienceConverter.ConvertToDto(await DbContext.Experiences.Where(e => e.Id == id.Value).ToListAsync());
                }

                return ExperienceConverter.ConvertToDto(await DbContext.Experiences.ToListAsync());
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
        public async Task<Result> AddUpdateExperience(ExperienceDto exp, bool isNew)
        {
            try
            {
                Experience entity = await DbContext.Experiences.Where(e => e.Id == exp.Id).SingleOrDefaultAsync();

                if (isNew && entity == null)
                {
                    entity = ExperienceConverter.ConvertToEntity(exp);
                    DbContext.Experiences.Add(entity);
                }
                else if (!isNew && entity != null)
                {
                    entity = ExperienceConverter.ConvertToEntity(exp);
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
