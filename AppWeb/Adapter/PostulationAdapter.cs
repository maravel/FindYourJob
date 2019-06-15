using AppWeb.Models;
using Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.Adapter
{
    /// <summary>
    /// Convertisseur de <see cref="PostulationDto"/> en <see cref="PostulationViewModel"/> et vice versa.
    /// </summary>
    internal static class PostulationAdapter
    {
        /// <summary>
        /// Convertit une liste de <see cref="PostulationDto"/> en liste de <see cref="PostulationViewModel"/>.
        /// </summary>
        /// <param name="dtos">La liste de Dto.</param>
        /// <returns>La liste de ViewModel convertie.</returns>
        internal static List<PostulationViewModel> ConvertToViewModel(List<PostulationDto> dtos)
        {
            if(dtos == null)
            {
                return null;
            }

            List<PostulationViewModel> vms = new List<PostulationViewModel>();

            foreach (var dto in dtos)
            {
                vms.Add(ConvertToViewModel(dto));
            }

            return vms;
        }

        /// <summary>
        /// Convertit un <see cref="PostulationDto"/> en <see cref="PostulationViewModel"/>.
        /// </summary>
        /// <param name="dto">Le dto à convertir.</param>
        /// <returns>Le ViewModel convertit</returns>
        internal static PostulationViewModel ConvertToViewModel(PostulationDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            PostulationViewModel vm = new PostulationViewModel
            {
                Date = dto.Date,
                EmployeId = dto.EmployeId,
                OffreId = dto.OffreId,
                StatutId = dto.StatutId
            };

            return vm;
        }
    }
}