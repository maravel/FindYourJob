using AppWeb.Models;
using Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.Adapter
{
    /// <summary>
    /// Convertisseur de <see cref="StatutDto"/> en <see cref="StatutViewModel"/> et vice versa.
    /// </summary>
    internal static class StatutAdapter
    {
        /// <summary>
        /// Convertit une liste de <see cref="StatutDto"/> en liste de <see cref="StatutViewModel"/>.
        /// </summary>
        /// <param name="dtos">La liste de Dto.</param>
        /// <returns>La liste de ViewModel convertie.</returns>
        internal static List<StatutViewModel> ConvertToViewModel(List<StatutDto> dtos)
        {
            if (dtos == null)
            {
                return null;
            }

            List<StatutViewModel> vms = new List<StatutViewModel>();

            foreach (var dto in dtos)
            {
                vms.Add(ConvertToViewModel(dto));
            }

            return vms;
        }

        /// <summary>
        /// Convertit un <see cref="StatutDto"/> en <see cref="StatutViewModel"/>.
        /// </summary>
        /// <param name="dto">Le dto à convertir.</param>
        /// <returns>Le ViewModel convertit</returns>
        internal static StatutViewModel ConvertToViewModel(StatutDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            StatutViewModel vm = new StatutViewModel
            {
                Libelle = dto.Libelle,
                Id = dto.Id
            };

            return vm;
        }

        /// <summary>
        /// Convertit une liste de <see cref="StatutViewModel"/> en liste de <see cref="StatutDto"/>.
        /// </summary>
        /// <param name="vms">La liste de ViewModel.</param>
        /// <returns>La liste de dto convertie.</returns>
        internal static List<StatutDto> ConvertToDto(List<StatutViewModel> vms)
        {
            if (vms == null)
            {
                return null;
            }

            List<StatutDto> dtos = new List<StatutDto>();

            foreach (var vm in vms)
            {
                dtos.Add(ConvertToDto(vm));
            }

            return dtos;
        }

        /// <summary>
        /// Convertit un <see cref="StatutViewModel"/> en <see cref="StatutDto"/>.
        /// </summary>
        /// <param name="vm">Le ViewModel à convertir.</param>
        /// <returns>Le dto convertit</returns>
        internal static StatutDto ConvertToDto(StatutViewModel vm)
        {
            if (vm == null)
            {
                return null;
            }

            StatutDto dto = new StatutDto
            {
                Id = vm.Id,
                Libelle = vm.Libelle
            };

            return dto;
        }
    }
}