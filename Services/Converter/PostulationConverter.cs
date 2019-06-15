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
    /// Convertisseur de <see cref="Postulation"/> en <see cref="PostulationDto"/> et vice versa.
    /// </summary>
    internal class PostulationConverter
    {
        /// <summary>
        /// Convertit une liste de <see cref="Postulation"/> en liste de <see cref="PostulationDto"/>.
        /// </summary>
        /// <param name="dtos">La liste de Dto.</param>
        /// <returns>La liste d'entity convertie.</returns>
        internal static List<PostulationDto> ConvertToDto(List<Postulation> entities)
        {
            if(entities == null)
            {
                return null;
            }

            List<PostulationDto> dtos = new List<PostulationDto>();

            foreach(var entity in entities)
            {
                dtos.Add(ConvertToDto(entity));
            }

            return dtos;
        }

        /// <summary>
        /// Convertit un <see cref="Postulation"/> en <see cref="PostulationDto"/>.
        /// </summary>
        /// <param name="dto">Le dto à convertir.</param>
        /// <returns>L'entity convertit</returns>
        internal static PostulationDto ConvertToDto(Postulation entity)
        {
            if(entity == null)
            {
                return null;
            }

            PostulationDto dto = new PostulationDto();
            dto.EmployeId = entity.EmployeId;
            dto.OffreId = entity.OffreId;
            dto.StatutId = entity.StatutId;
            dto.Date = entity.Date;

            return dto;
        }

        /// <summary>
        /// Convertit une liste de <see cref="PostulationDto"/> en liste de <see cref="Postulation"/>.
        /// </summary>
        /// <param name="vms">La liste de entity.</param>
        /// <returns>La liste de dto convertie.</returns>
        internal static List<Postulation> ConvertToEntity(List<PostulationDto> dtos)
        {
            if (dtos == null)
            {
                return null;
            }

            List<Postulation> entities = new List<Postulation>();

            foreach (var dto in dtos)
            {
                entities.Add(ConvertToEntity(dto));
            }

            return entities;
        }

        /// <summary>
        /// Convertit un <see cref="PostulationDto"/> en <see cref="Postulation"/>.
        /// </summary>
        /// <param name="vm">L'entity à convertir.</param>
        /// <returns>Le dto convertit</returns>
        internal static Postulation ConvertToEntity(PostulationDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            Postulation entity = new Postulation();
            entity.EmployeId = dto.EmployeId;
            entity.OffreId = dto.OffreId;
            entity.StatutId = dto.StatutId;
            entity.Date = dto.Date;

            return entity;
        }
    }
}
