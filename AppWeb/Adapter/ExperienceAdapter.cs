using AppWeb.Models;
using Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.Adapter
{
    /// <summary>
    /// Convertisseur de <see cref="ExperienceDto"/> en <see cref="ExperienceViewModel"/> et vice versa.
    /// </summary>
    internal static class ExperienceAdapter
    {
        /// <summary>
        /// Convertit une liste de <see cref="ExperienceDto"/> en liste de <see cref="ExperienceViewModel"/>.
        /// </summary>
        /// <param name="dtos">La liste de Dto.</param>
        /// <returns>La liste de ViewModel convertie.</returns>
        internal static List<ExperienceViewModel> ConvertToViewModel(List<ExperienceDto> dtos)
        {
            if(dtos == null)
            {
                return null;
            }

            List<ExperienceViewModel> vms = new List<ExperienceViewModel>();

            foreach (var dto in dtos)
            {
                vms.Add(ConvertToViewModel(dto));
            }

            return vms;
        }

        /// <summary>
        /// Convertit un <see cref="ExperienceDto"/> en <see cref="ExperienceViewModel"/>.
        /// </summary>
        /// <param name="dto">Le dto à convertir.</param>
        /// <returns>Le ViewModel convertit</returns>
        internal static ExperienceViewModel ConvertToViewModel(ExperienceDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            ExperienceViewModel vm = new ExperienceViewModel
            {
                Date = dto.Date,
                EmployeId = dto.EmployeId,
                Id = dto.Id,
                Intitule = dto.Intitule
            };

            return vm;
        }
    }
}