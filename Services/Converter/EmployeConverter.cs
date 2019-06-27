using Dto.Dto;
using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Converter
{
    /// <summary>
    /// Convertisseur de <see cref="Employe"/> en <see cref="EmployeDto"/> et vice versa.
    /// </summary>
    internal class EmployeConverter
    {
        /// <summary>
        /// Convertit une liste de <see cref="Employe"/> en liste de <see cref="EmployeDto"/>.
        /// </summary>
        /// <param name="dtos">La liste de Dto.</param>
        /// <returns>La liste d'entity convertie.</returns>
        internal static List<EmployeDto> ConvertToDto(List<Employe> entities)
        {
            if (entities == null)
            {
                return null;
            }

            List<EmployeDto> dtos = new List<EmployeDto>();

            foreach(var entity in entities)
            {
                dtos.Add(ConvertToDto(entity));
            }

            return dtos;
        }

        /// <summary>
        /// Convertit un <see cref="Employe"/> en <see cref="EmployeDto"/>.
        /// </summary>
        /// <param name="dto">Le dto à convertir.</param>
        /// <returns>L'entity convertit</returns>
        internal static EmployeDto ConvertToDto(Employe entity)
        {
            if (entity == null)
            {
                return null;
            }

            EmployeDto dto = new EmployeDto();
            dto.Id = entity.Id;
            dto.Anciennete = entity.Anciennete;
            dto.Biographie = entity.Biographie;
            dto.DateNaissance = entity.DateNaissance;
            dto.Nom = entity.Nom;
            dto.Prenom = entity.Prenom;
            dto.Formations = FormationConverter.ConvertToDto(entity.Formations);
            dto.Experiences = ExperienceConverter.ConvertToDto(entity.Experiences);
            dto.Postulations = PostulationConverter.ConvertToDto(entity.Postulations);

            return dto;
        }

        /// <summary>
        /// Convertit une liste de <see cref="EmployeDto"/> en liste de <see cref="Employe"/>.
        /// </summary>
        /// <param name="vms">La liste de entity.</param>
        /// <returns>La liste de dto convertie.</returns>
        internal static List<Employe> ConvertToEntity(List<EmployeDto> dtos)
        {
            if (dtos == null)
            {
                return null;
            }

            List<Employe> entities = new List<Employe>();

            foreach (var dto in dtos)
            {
                entities.Add(ConvertToEntity(dto));
            }

            return entities;
        }

        /// <summary>
        /// Convertit un <see cref="EmployeDto"/> en <see cref="Employe"/>.
        /// </summary>
        /// <param name="vm">L'entity à convertir.</param>
        /// <returns>Le dto convertit</returns>
        internal static Employe ConvertToEntity(EmployeDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            Employe entity = new Employe();
            entity.Id = dto.Id;
            entity.Anciennete = dto.Anciennete;
            entity.Biographie = dto.Biographie;
            entity.DateNaissance = dto.DateNaissance;
            entity.Nom = dto.Nom;
            entity.Prenom = dto.Prenom;

            return entity;
        }
    }
}
