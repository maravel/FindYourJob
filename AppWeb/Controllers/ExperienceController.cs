using AppWeb.Adapter;
using AppWeb.Controllers.Common;
using AppWeb.Models;
using Dto.Dto;
using Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    /// <summary>
    /// Contrôleur gérant les actions relatives aux expériences des employés.
    /// </summary>
    public class ExperienceController : BaseController
    {
        /// <summary>
        /// Renvoie le formulaire de creation et modification d'expérience
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateView()
        {
            ExperienceViewModel vm = new ExperienceViewModel
            {
                EmployeId = idUser
            };

            return View("CreateExperience", vm);
        }

        /// <summary>
        /// Crée une expérience
        /// </summary>
        /// <param name="vm">La nouvelle expérience</param>
        /// <returns>Un json avec les erreurs si elles existent ou la vue Account</returns>
        public async Task<ActionResult> CreateExperienceAsync(ExperienceViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Result res;

                if (vm.Date > DateTime.Today)
                {
                    return Json(new { error = true }, JsonRequestBehavior.AllowGet);
                }

                if (vm.Id != 0)
                {
                    //on modifie
                    res = await service.AddUpdateExperience(ExperienceAdapter.ConvertToDto(vm), false);
                }
                else
                {
                    // on crée
                    res = await service.AddUpdateExperience(ExperienceAdapter.ConvertToDto(vm), true);
                }

                if (res.HasError())
                {
                    return Json(new { error = true }, JsonRequestBehavior.AllowGet);
                }

                return RedirectToAction("GetEmployeeViewAsync", "Employe");
            }

            return View("CreateExperience", vm);
        }

        /// <summary>
        /// Renvoie le formulaire de modification
        /// </summary>
        /// <param name="id">id de la formation à modifier</param>
        /// <returns>Une erreur json ou la vue Account</returns>
        public async Task<ActionResult> EditViewAsync(int id)
        {
            ExperienceDto dto = (await service.GetExperiences(id: id)).SingleOrDefault();

            if (dto == null)
            {
                // return json
                //return View("")
            }

            if (dto.EmployeId != idUser)
            {
                // pas le droit de modif
                return Json(new { error = true }, JsonRequestBehavior.AllowGet);
            }

            ExperienceViewModel vm = ExperienceAdapter.ConvertToViewModel(dto);

            return View("CreateExperience", vm);
        }

        /// <summary>
        /// Supprime une experience à partir de son identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'experience</param>
        /// <returns>Un json avec les potentiels erreurs.</returns>
        public async Task<ActionResult> DeleteExperienceAsync(int id)
        {
            Result res = await service.RemoveExperience(id);

            if (res.HasError())
            {
                return Json(new { error = true, message = "Impossible de supprimer l'expérience" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { error = false }, JsonRequestBehavior.AllowGet);
        }
    }
}