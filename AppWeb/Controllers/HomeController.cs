using AppWeb.Adapter;
using AppWeb.Controllers.Common;
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
    public class HomeController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            // retourne les 9 plus récentes offres
            List<OffreDto> offres = (await service.GetOffres()).OrderBy(o => o.Date).Take(9).ToList();

            List<OffreViewModel> vms = OffreAdapter.ConvertToViewModel(offres);
            
            return View(vms);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}