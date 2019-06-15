using AppWeb.Models;
using Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.Adapter
{
    /// <summary>
    /// Convertisseur de <see cref="FormationDto"/> en <see cref="FormationViewModel"/> et vice versa.
    /// </summary>
    internal static class FormationAdapter
    {
        /// <summary>
        /// Convertit une liste de <see cref="FormationDto"/> en liste de <see cref="FormationViewModel"/>.
        /// </summary>
        /// <param name="dtos">La liste de Dto.</param>
        /// <returns>La liste de ViewModel convertie.</returns>
        internal static List<FormationViewModel> ConvertToViewModel(List<FormationDto> dtos)
        {
            if(dtos == null)
            {
                return null;
            }

            List<FormationViewModel> vms = new List<FormationViewModel>();

            foreach (var dto in dtos)
            {
                vms.Add(ConvertToViewModel(dto));
            }

            return vms;
        }

        /// <summary>
        /// Convertit un <see cref="FormationDto"/> en <see cref="FormationViewModel"/>.
        /// </summary>
        /// <param name="dto">Le dto à convertir.</param>
        /// <returns>Le ViewModel convertit</returns>
        internal static FormationViewModel ConvertToViewModel(FormationDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            FormationViewModel vm = new FormationViewModel
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