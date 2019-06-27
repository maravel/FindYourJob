using AppWeb.Adapter;
using AppWeb.Controllers.Common;
using AppWeb.Models;
using Dto.Dto;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    /// <summary>
    /// Contrôleur gérant les actions sur les offres
    /// </summary>
    public class OffreController : BaseController
    {
        /// <summary>
        /// Recupère et renvoie toutes les offres à la vue.
        /// </summary>
        /// <returns>Une liste de <see cref="OffreViewModel"/></returns>
        public async Task<ActionResult> LitesOffresAsync()
        {
            List<OffreDto> offres = await service.GetOffres();

            List<OffreViewModel> vms = OffreAdapter.ConvertToViewModel(offres);

            return View("ListesOffres", vms);
        }

        /// <summary>
        /// Renvoie la vue de détail d'une offre à partir de son identifiant
        /// </summary>
        /// <param name="id">Id de l'offre</param>
        /// <returns>La vue detail avec l'offre</returns>
        public async Task<ActionResult> DetailOffreAsync(int id)
        {
            List<OffreDto> offres = await service.GetOffres(id: id);
            
            OffreViewModel vm = OffreAdapter.ConvertToViewModel(offres.FirstOrDefault());

            List<PostulationDto> posts = await service.GetPostulations(offreId: id, employeId: idUser);

            if (posts?.Any() ?? false)
            {
                vm.isApplied = true;
            }
            else
            {
                vm.isApplied = false;
            }

            return View("DetailOffre", vm);
        }

        /// <summary>
        /// Recherche des offres
        /// </summary>
        /// <param name="searchText">La recherche</param>
        /// <returns>La liste des offres trouvées</returns>
        public async Task<ActionResult> SearchOffre(string searchText)
        {
            List<OffreDto> offres = await service.GetOffres();

            offres = offres.Where(o => o.Intitule.ToUpper().Contains(searchText.ToUpper())).ToList();

            List<OffreViewModel> vms = OffreAdapter.ConvertToViewModel(offres);

            return View("ListesOffres", vms);
        }

        /// <summary>
        /// Renvoie la vue de creation d'offre
        /// </summary>
        /// <returns>Vue CreateOffre</returns>
        public async Task<ActionResult> CreateOfferView()
        {
            OffreViewModel vm = new OffreViewModel();

            List<StatutDto> statuts = await service.GetStatuts();

            vm.Statuts = StatutAdapter.ConvertToViewModel(statuts);

            return View("CreateOffre", vm);
        }

        /// <summary>
        /// Crée une offre si elle est valide
        /// </summary>
        /// <param name="vm">La nouvelle offre</param>
        /// <returns>La liste des offres</returns>
        public async Task<ActionResult> CreateOfferAsync(OffreViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.StatutId = 1;
                OffreDto dto = OffreAdapter.ConvertToDto(vm);
                Result res = await service.AddUpdateOffre(dto, true);

                if (res.HasError())
                {
                    return View("CreateOffre", vm);
                }

                return await LitesOffresAsync();
            }

            List<StatutDto> statuts = await service.GetStatuts();

            vm.Statuts = StatutAdapter.ConvertToViewModel(statuts);

            return View("CreateOffre", vm);
        }
    }
}