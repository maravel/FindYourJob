using AppWeb.Models;
using Dto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.Adapter
{
    /// <summary>
    /// Convertisseur de <see cref="EmployeDto"/> en <see cref="EmployeViewModel"/> et vice versa.
    /// </summary>
    internal static class EmployeAdapter
    {
        /// <summary>
        /// Convertit une liste de <see cref="EmployeDto"/> en liste de <see cref="EmployeViewModel"/>.
        /// </summary>
        /// <param name="dtos">La liste de Dto.</param>
        /// <returns>La liste de ViewModel convertie.</returns>
        internal static List<EmployeViewModel> ConvertToViewModel(List<EmployeDto> dtos)
        {
            if(dtos == null)
            {
                return null;
            }

            List<EmployeViewModel> vms = new List<EmployeViewModel>();

            foreach (var dto in dtos)
            {
                vms.Add(ConvertToViewModel(dto));
            }

            return vms;
        }

        /// <summary>
        /// Convertit un <see cref="EmployeDto"/> en <see cref="EmployeViewModel"/>.
        /// </summary>
        /// <param name="dto">Le dto à convertir.</param>
        /// <returns>Le ViewModel convertit</returns>
        internal static EmployeViewModel ConvertToViewModel(EmployeDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            EmployeViewModel vm = new EmployeViewModel
            {
                Anciennete = dto.Anciennete,
                Biographie = dto.Biographie,
                Id = dto.Id,
                DateNaissance = dto.DateNaissance,
                Nom = dto.Nom,
                Prenom = dto.Prenom
            };

            return vm;
        }
    }
}