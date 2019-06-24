using AppWeb.Adapter;
using AppWeb.Controllers.Common;
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
    public class EmployeController : BaseController
    {
        
        public async Task<ActionResult> GetEmployeeViewAsync()
        {
            int.TryParse(ConfigurationManager.AppSettings["connectedUser"], out int idUser);

            EmployeDto dto = (await service.GetEmployes(id: idUser, includeData: true)).SingleOrDefault();

            EmployeViewModel vm = EmployeAdapter.ConvertToViewModel(dto);

            vm.OffresPostulees = new List<OffreViewModel>();

            foreach (var postulation in vm.Postulations)
            {
                OffreViewModel offrevm = OffreAdapter.ConvertToViewModel((await service.GetOffres(id: postulation.OffreId)).SingleOrDefault());
                if(offrevm != null)
                {
                    vm.OffresPostulees.Add(offrevm);
                }
            }           

            return View("Account", vm);
        }

        public async Task<ActionResult> Postuler(int idOffre)
        {
            OffreDto offreDto = (await service.GetOffres(id: idOffre)).SingleOrDefault();

            if(offreDto == null)
            {
                return Json(new { error = true, message = "Offer not found" }, JsonRequestBehavior.AllowGet);
            }

            PostulationDto postulation = new PostulationDto
            {
                Date = DateTime.Now,
                EmployeId = idUser,
                OffreId = idOffre,
                StatutId = 1
            };

            Result res = await service.AddUpdatePostulation(postulation, true);

            if(res.HasError())
            {
                return Json(new { error = true, message = res.Error }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { error = false, message = "Successful postulation" }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DePostuler(int idOffre)
        {

            PostulationDto postulationdto = (await service.GetPostulations(offreId:idOffre,employeId:idUser)).SingleOrDefault();
            
            if (postulationdto == null)
            {
                return Json(new { error = true, message = "Postulation not found" }, JsonRequestBehavior.AllowGet);
            }
            
            Result res = await service.RemovePostulation(idUser, idOffre);

            if (res.HasError())
            {
                return Json(new { error = true, message = res.Error }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { error = false, message = "Unapplied with success !" }, JsonRequestBehavior.AllowGet);
        }


    }
}