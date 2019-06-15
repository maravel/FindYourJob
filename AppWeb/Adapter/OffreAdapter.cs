using AppWeb.Models;
using Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.Adapter
{
    /// <summary>
    /// Convertisseur de <see cref="OffreDto"/> en <see cref="OffreViewModel"/> et vice versa.
    /// </summary>
    internal static class OffreAdapter
    {
        /// <summary>
        /// Convertit une liste de <see cref="OffreDto"/> en liste de <see cref="OffreViewModel"/>.
        /// </summary>
        /// <param name="dtos">La liste de Dto.</param>
        /// <returns>La liste de ViewModel convertie.</returns>
        internal static List<OffreViewModel> ConvertToViewModel(List<OffreDto> dtos)
        {
            if(dtos == null)
            {
                return null;
            }

            List<OffreViewModel> vms = new List<OffreViewModel>();

            foreach (var dto in dtos)
            {
                vms.Add(ConvertToViewModel(dto));
            }

            return vms;
        }

        /// <summary>
        /// Convertit un <see cref="OffreDto"/> en <see cref="OffreViewModel"/>.
        /// </summary>
        /// <param name="dto">Le dto à convertir.</param>
        /// <returns>Le ViewModel convertit</returns>
        internal static OffreViewModel ConvertToViewModel(OffreDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            OffreViewModel vm = new OffreViewModel
            {
                Date = dto.Date,
                Description = dto.Description,
                Id = dto.Id,
                Intitule = dto.Intitule,
                Responsable = dto.Responsable,
                Salaire = dto.Salaire,
                StatutId = dto.StatutId
            };

            return vm;
        }
    }
}