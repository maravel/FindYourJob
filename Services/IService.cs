using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IService
    {
        Task<List<Formation>> GetFormations(int id = -1);

        Task<List<Employe>> GetEmployes(int? id = null);

        Task<List<Offre>> GetOffres(int? id = null);

        Task<List<Formation>> GetFormations(int? id = null);

        Task<List<Postulation>> GetPostulations(int? employeId = null, int? offreId = null);

        Task<List<Statut>> GetStatuts(int? id = null);

        Task<List<Experience>> GetExperiences(int? id = null);

    }
}
