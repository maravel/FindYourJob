using AppWeb.Adapter;
using AppWeb.Models;
using Dto.Dto;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    public class OffreController : Controller
    {
        private IService service = new Service();

        public async Task<ActionResult> LitesOffresAsync()
        {
            List<OffreDto> offres = await service.GetOffres();

            List<OffreViewModel> vms = OffreAdapter.ConvertToViewModel(offres);

            return View("ListesOffres", vms);
        }

        public async Task<ActionResult> DetailOffreAsync(int idOffre)
        {
            List<OffreDto> offres = await service.GetOffres(id: idOffre);
            
            OffreViewModel vm = OffreAdapter.ConvertToViewModel(offres.FirstOrDefault());

            return View("DetailOffre", vm);
        }

        public async Task<ActionResult> SearchOffre(string searchText)
        {
            List<OffreDto> offres = await service.GetOffres();

            offres = offres.Where(o => o.Intitule.ToUpper().Contains(searchText.ToUpper())).ToList();

            List<OffreViewModel> vms = OffreAdapter.ConvertToViewModel(offres);

            return View("ListesOffres", vms);
        }
    }
}