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

        /// <summary>
        /// Convertit une liste de <see cref="FormationViewModel"/> en liste de <see cref="FormationDto"/>.
        /// </summary>
        /// <param name="vms">La liste de ViewModel.</param>
        /// <returns>La liste de dto convertie.</returns>
        internal static List<FormationDto> ConvertToDto(List<FormationViewModel> vms)
        {
            if (vms == null)
            {
                return null;
            }

            List<FormationDto> dtos = new List<FormationDto>();

            foreach (var vm in vms)
            {
                dtos.Add(ConvertToDto(vm));
            }

            return dtos;
        }

        /// <summary>
        /// Convertit un <see cref="FormationViewModel"/> en <see cref="FormationDto"/>.
        /// </summary>
        /// <param name="vm">Le ViewModel à convertir.</param>
        /// <returns>Le dto convertit</returns>
        internal static FormationDto ConvertToDto(FormationViewModel vm)
        {
            if (vm == null)
            {
                return null;
            }

            FormationDto dto = new FormationDto
            {
                Date = vm.Date,
                EmployeId = vm.EmployeId,
                Id = vm.Id,
                Intitule = vm.Intitule
            };

            return dto;
        }
    }
}