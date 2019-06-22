using AppWeb.Adapter;
using AppWeb.Models;
using Dto.Dto;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    public class EmployeController : Controller
    {
        private IService service = new Service();
        private int idUser;

        public EmployeController()
        {
            int.TryParse(ConfigurationManager.AppSettings["connectedUser"], out int idconnected);
            this.idUser = idconnected;
        }


        public async Task<ActionResult> GetOffresPostuleesAsync()
        {
            int.TryParse(ConfigurationManager.AppSettings["connectedUser"], out int idUser);

            List<PostulationDto> postulations = await service.GetPostulations(employeId: idUser);

            // TODO : faire dans le service ?
            List<OffreDto> offreDtos = new List<OffreDto>();

            foreach (var post in postulations)
            {
                offreDtos.AddRange(await service.GetOffres(id: post.OffreId));
            }
            
            return View("ListesOffresPostulees", OffreAdapter.ConvertToViewModel(offreDtos));
        }

        public async Task<ActionResult> Postuler(int idOffre)
        {
            OffreDto offreDto = (await service.GetOffres(id: idOffre)).SingleOrDefault();

            if(offreDto == null)
            {
                return Json(new { error = true, message = "Offer not found" }, JsonRequestBehavior.AllowGet);
            }

            PostulationDto postulation = new PostulationDto();
            postulation.Date = DateTime.Now;
            postulation.EmployeId = idUser;
            postulation.OffreId = idOffre;
            postulation.StatutId = 1;

            Result res = await service.AddUpdatePostulation(postulation, true);

            if(res.HasError())
            {
                return Json(new { error = true, message = res.Error }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { error = false, message = "Successful postulation" }, JsonRequestBehavior.AllowGet);
        }

        
    }
}