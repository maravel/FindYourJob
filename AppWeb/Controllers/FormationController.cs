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
    /// <summary>
    /// Contrôleur gérant les actions sur les formations
    /// </summary>
    public class FormationController : BaseController
    {
        /// <summary>
        /// Renvoie le formulaire de creation et modification de formation
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateView()
        {
            FormationViewModel vm = new FormationViewModel
            {
                EmployeId = idUser
            };

            return View("CreateFormation", vm);
        }

        /// <summary>
        /// Crée une formation
        /// </summary>
        /// <param name="vm">La nouvelle formation</param>
        /// <returns>Un json avec les erreurs si elles existent ou la vue Account</returns>
        public async Task<ActionResult> CreateFormationAsync(FormationViewModel vm)
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
                    res = await service.AddUpdateFormation(FormationAdapter.ConvertToDto(vm), false);
                }
                else
                {
                    // on crée
                    res = await service.AddUpdateFormation(FormationAdapter.ConvertToDto(vm), true);
                }

                if (res.HasError())
                {
                    return Json(new { error = true }, JsonRequestBehavior.AllowGet);
                }

                return RedirectToAction("GetEmployeeViewAsync", "Employe");
            }

            return View("CreateFormation", vm);
        }

        /// <summary>
        /// Renvoie le formulaire de modification
        /// </summary>
        /// <param name="id">id de la formation à modifier</param>
        /// <returns>Une erreur json ou la vue Account</returns>
        public async Task<ActionResult> EditViewAsync(int id)
        {
            FormationDto dto = (await service.GetFormations(id: id)).SingleOrDefault();

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

            FormationViewModel vm = FormationAdapter.ConvertToViewModel(dto);

            return View("CreateFormation", vm);
        }

        /// <summary>
        /// Supprime une formation à partir de son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la formation</param>
        /// <returns>Un json avec les potentiels erreurs.</returns>
        public async Task<ActionResult> DeleteFormationAsync(int id)
        {
            Result res = await service.RemoveFormation(id);

            if (res.HasError())
            {
                return Json(new { error = true, message = "Impossible de supprimer la formation" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { error = false }, JsonRequestBehavior.AllowGet);
        }
    }
}