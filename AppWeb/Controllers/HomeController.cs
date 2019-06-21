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
    public class HomeController : Controller
    {
        private IService service = new Service();

        public async Task<ActionResult> Index()
        {
            List<OffreDto> offres = await service.GetOffres();

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