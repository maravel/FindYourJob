using AppWeb.Adapter;
using AppWeb.Controllers.Common;
using AppWeb.Models;
using Dto.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    /// <summary>
    /// Contrôleur gérant la page d'accueil.
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// Renvoie la vue Index avec les offres récentes
        /// </summary>
        /// <returns>Vue Index</returns>
        public async Task<ActionResult> Index()
        {
            // retourne les 9 plus récentes offres
            List<OffreDto> offres = (await service.GetOffres()).OrderBy(o => o.Date).Take(9).ToList();

            List<OffreViewModel> vms = OffreAdapter.ConvertToViewModel(offres);
            
            return View(vms);
        }
    }
}