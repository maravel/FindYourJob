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
            if (dtos == null)
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
            if (dto == null)
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

        /// <summary>
        /// Convertit une liste de <see cref="ExperienceViewModel"/> en liste de <see cref="ExperienceDto"/>.
        /// </summary>
        /// <param name="vms">La liste de ViewModel.</param>
        /// <returns>La liste de dto convertie.</returns>
        internal static List<ExperienceDto> ConvertToDto(List<ExperienceViewModel> vms)
        {
            if (vms == null)
            {
                return null;
            }

            List<ExperienceDto> dtos = new List<ExperienceDto>();

            foreach (var vm in vms)
            {
                dtos.Add(ConvertToDto(vm));
            }

            return dtos;
        }

        /// <summary>
        /// Convertit un <see cref="ExperienceViewModel"/> en <see cref="ExperienceDto"/>.
        /// </summary>
        /// <param name="vm">Le ViewModel à convertir.</param>
        /// <returns>Le dto convertit</returns>
        internal static ExperienceDto ConvertToDto(ExperienceViewModel vm)
        {
            if (vm == null)
            {
                return null;
            }

            ExperienceDto dto = new ExperienceDto
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