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
    /// Convertisseur de <see cref="Experience"/> en <see cref="ExperienceDto"/> et vice versa.
    /// </summary>
    internal class ExperienceConverter
    {
        /// <summary>
        /// Convertit une liste de <see cref="Experience"/> en liste de <see cref="ExperienceDto"/>.
        /// </summary>
        /// <param name="dtos">La liste de Dto.</param>
        /// <returns>La liste d'entity convertie.</returns>
        internal static List<ExperienceDto> ConvertToDto(List<Experience> entities)
        {
            if (entities == null)
            {
                return null;
            }

            List<ExperienceDto> dtos = new List<ExperienceDto>();

            foreach(var entity in entities)
            {
                dtos.Add(ConvertToDto(entity));
            }

            return dtos;
        }

        /// <summary>
        /// Convertit un <see cref="Experience"/> en <see cref="ExperienceDto"/>.
        /// </summary>
        /// <param name="dto">Le dto à convertir.</param>
        /// <returns>L'entity convertit</returns>
        internal static ExperienceDto ConvertToDto(Experience entity)
        {
            if (entity == null)
            {
                return null;
            }

            ExperienceDto dto = new ExperienceDto();
            dto.Id = entity.Id;
            dto.Intitule = entity.Intitule;
            dto.EmployeId = entity.EmployeId;
            dto.Date = entity.Date;

            return dto;
        }

        /// <summary>
        /// Convertit une liste de <see cref="ExperienceDto"/> en liste de <see cref="Experience"/>.
        /// </summary>
        /// <param name="vms">La liste de entity.</param>
        /// <returns>La liste de dto convertie.</returns>
        internal static List<Experience> ConvertToEntity(List<ExperienceDto> dtos)
        {
            if (dtos == null)
            {
                return null;
            }

            List<Experience> entities = new List<Experience>();

            foreach (var dto in dtos)
            {
                entities.Add(ConvertToEntity(dto));
            }

            return entities;
        }

        /// <summary>
        /// Convertit un <see cref="ExperienceDto"/> en <see cref="Experience"/>.
        /// </summary>
        /// <param name="vm">L'entity à convertir.</param>
        /// <returns>Le dto convertit</returns>
        internal static Experience ConvertToEntity(ExperienceDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            Experience entity = new Experience();
            entity.Id = dto.Id;
            entity.Intitule = dto.Intitule;
            entity.EmployeId = dto.EmployeId;
            entity.Date = dto.Date;

            return entity;
        }
    }
}
