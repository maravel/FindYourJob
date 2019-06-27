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
            if (dtos == null)
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
            if (dto == null)
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
                StatutId = dto.StatutId,
                Statut = StatutAdapter.ConvertToViewModel(dto.Statut)                
            };

            return vm;
        }

        /// <summary>
        /// Convertit une liste de <see cref="OffreViewModel"/> en liste de <see cref="OffreDto"/>.
        /// </summary>
        /// <param name="vms">La liste de ViewModel.</param>
        /// <returns>La liste de dto convertie.</returns>
        internal static List<OffreDto> ConvertToDto(List<OffreViewModel> vms)
        {
            if (vms == null)
            {
                return null;
            }

            List<OffreDto> dtos = new List<OffreDto>();

            foreach (var vm in vms)
            {
                dtos.Add(ConvertToDto(vm));
            }

            return dtos;
        }

        /// <summary>
        /// Convertit un <see cref="OffreViewModel"/> en <see cref="OffreDto"/>.
        /// </summary>
        /// <param name="vm">Le ViewModel à convertir.</param>
        /// <returns>Le dto convertit</returns>
        internal static OffreDto ConvertToDto(OffreViewModel vm)
        {
            if (vm == null)
            {
                return null;
            }

            OffreDto dto = new OffreDto
            {
                Date = vm.Date,
                Description = vm.Description,
                Id = vm.Id,
                Intitule = vm.Intitule,
                Responsable = vm.Responsable,
                Salaire = vm.Salaire,
                StatutId = vm.StatutId
            };

            return dto;
        }
    }
}