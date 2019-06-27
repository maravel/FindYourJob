using AppWeb.Adapter;
using AppWeb.Controllers.Common;
using AppWeb.Models;
using Dto.Dto;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    /// <summary>
    /// Contrôleur gérant les employés
    /// </summary>
    public class EmployeController : BaseController
    {
        /// <summary>
        /// Donne la liste des employés
        /// </summary>
        /// <returns>La vue ListEmployees</returns>
        public async Task<ActionResult> GetListEmployeesViewAsync()
        {
            List<EmployeDto> employeDtos = await service.GetEmployes();

            return View("ListEmployees", EmployeAdapter.ConvertToViewModel(employeDtos));
        }

        /// <summary>
        /// Renvoie sur la vue Account l'utilisateur connecté
        /// </summary>
        /// <returns>Vue Account</returns>
        public async Task<ActionResult> GetEmployeeViewAsync()
        {
            EmployeDto dto = (await service.GetEmployes(id: idUser, includeData: true)).SingleOrDefault();

            EmployeViewModel vm = EmployeAdapter.ConvertToViewModel(dto);

            vm.IsConnectedUser = true;
            vm.OffresPostulees = new List<OffreViewModel>();

            foreach (var postulation in vm.Postulations)
            {
                OffreViewModel offrevm = OffreAdapter.ConvertToViewModel((await service.GetOffres(id: postulation.OffreId)).SingleOrDefault());

                if (offrevm != null)
                {
                    vm.OffresPostulees.Add(offrevm);
                }
            }           

            return View("Account", vm);
        }

        /// <summary>
        /// Donne les détails d'un employe
        /// </summary>
        /// <param name="id">L'id de l'employe</param>
        /// <returns>La vue Account</returns>
        public async Task<ActionResult> GetDetailEmployeeViewAsync(int id)
        {
            
            EmployeDto dto = (await service.GetEmployes(id: id, includeData: true)).SingleOrDefault();

            EmployeViewModel vm = EmployeAdapter.ConvertToViewModel(dto);

            vm.IsConnectedUser = id == idUser;
            vm.OffresPostulees = new List<OffreViewModel>();

            foreach (var postulation in vm.Postulations)
            {
                OffreViewModel offrevm = OffreAdapter.ConvertToViewModel((await service.GetOffres(id: postulation.OffreId)).SingleOrDefault());
                if (offrevm != null)
                {
                    vm.OffresPostulees.Add(offrevm);
                }
            }

            return View("Account", vm);
        }

        /// <summary>
        /// Postule l'employe connecté à une offre
        /// </summary>
        /// <param name="idOffre">L'id de l'offre à postuler</param>
        /// <returns>Un message de retour</returns>
        public async Task<ActionResult> Postuler(int idOffre)
        {
            OffreDto offreDto = (await service.GetOffres(id: idOffre)).SingleOrDefault();

            if (offreDto == null)
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

            if (res.HasError())
            {
                return Json(new { error = true, message = res.Error }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { error = false, message = "Successful postulation" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Annule une postulation pour l'utilisateur connecté
        /// </summary>
        /// <param name="idOffre">L'id de l'offre à depostuler</param>
        /// <returns>Un message de retour</returns>
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