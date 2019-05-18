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
    public class Service
    {
        private ContextDA DbContext { get; set; }

        public Service()
        {
            DbContext = new ContextDA();
        }


        #region Employés
        
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

        #endregion
        

    }
}
