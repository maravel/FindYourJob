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
    /// Convertisseur de <see cref="Formation"/> en <see cref="FormationDto"/> et vice versa.
    /// </summary>
    internal class FormationConverter
    {
        /// <summary>
        /// Convertit une liste de <see cref="Formation"/> en liste de <see cref="FormationDto"/>.
        /// </summary>
        /// <param name="dtos">La liste de Dto.</param>
        /// <returns>La liste d'entity convertie.</returns>
        internal static List<FormationDto> ConvertToDto(List<Formation> entities)
        {
            if(entities == null)
            {
                return null;
            }

            List<FormationDto> dtos = new List<FormationDto>();

            foreach(var entity in entities)
            {
                dtos.Add(ConvertToDto(entity));
            }

            return dtos;
        }

        /// <summary>
        /// Convertit un <see cref="Formation"/> en <see cref="FormationDto"/>.
        /// </summary>
        /// <param name="dto">Le dto à convertir.</param>
        /// <returns>L'entity convertit</returns>
        internal static FormationDto ConvertToDto(Formation entity)
        {
            if(entity == null)
            {
                return null;
            }

            FormationDto dto = new FormationDto();
            dto.Id = entity.Id;
            dto.Intitule = entity.Intitule;
            dto.EmployeId = entity.EmployeId;
            dto.Date = entity.Date;

            return dto;
        }

        /// <summary>
        /// Convertit une liste de <see cref="FormationDto"/> en liste de <see cref="Formation"/>.
        /// </summary>
        /// <param name="vms">La liste de entity.</param>
        /// <returns>La liste de dto convertie.</returns>
        internal static List<Formation> ConvertToEntity(List<FormationDto> dtos)
        {
            if (dtos == null)
            {
                return null;
            }

            List<Formation> entities = new List<Formation>();

            foreach (var dto in dtos)
            {
                entities.Add(ConvertToEntity(dto));
            }

            return entities;
        }

        /// <summary>
        /// Convertit un <see cref="FormationDto"/> en <see cref="Formation"/>.
        /// </summary>
        /// <param name="vm">L'entity à convertir.</param>
        /// <returns>Le dto convertit</returns>
        internal static Formation ConvertToEntity(FormationDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            Formation entity = new Formation();
            entity.Id = dto.Id;
            entity.Intitule = dto.Intitule;
            entity.EmployeId = dto.EmployeId;
            entity.Date = dto.Date;

            return entity;
        }
    }
}
