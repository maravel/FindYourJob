using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Dto.Dto;
using ModelDonnees.Entity;
using Services;

namespace ServiceWebWCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceWeb : IServiceWeb
    {
        private IService service = new Service();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// Retourne toutes les offres
        /// </summary>
        /// <returns>Une liste de toutes les offres</returns>
        public async Task<List<OffreDto>> GetOffresAsync()
        {
            try
            {
                return await service.GetOffres();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Postule pour un employe à une offre
        /// </summary>
        /// <param name="idEmploye">L'identifiant de l'employé</param>
        /// <param name="idOffre">L'identifiant de l'offre</param>
        /// <returns>Une chaine avec le message de retour.</returns>
        public async Task<string> PostulerAsync(int idEmploye, int idOffre)
        {
            try
            {
                OffreDto offre = (await service.GetOffres(id: idOffre)).SingleOrDefault();
                EmployeDto employe = (await service.GetEmployes(id: idEmploye)).SingleOrDefault();

                if (offre == null || employe == null)
                {
                    return "Offre ou employé non trouvé";
                }

                PostulationDto postulation = new PostulationDto();
                postulation.EmployeId = employe.Id;
                postulation.OffreId = offre.Id;
                postulation.Date = DateTime.Now;
                postulation.StatutId = 1;

                Result res = await service.AddUpdatePostulation(postulation, true);

                if (res.HasError())
                {
                    return "Echec postulation";
                }

                return "Posulation réussie";
            }
            catch (Exception ex)
            {
                return "Echec de la postulation : " + ex.Message;
            }
        }
    }
}
