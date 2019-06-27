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
    /// Convertisseur de <see cref="Statut"/> en <see cref="StatutDto"/> et vice versa.
    /// </summary>
    internal class StatutConverter
    {
        /// <summary>
        /// Convertit une liste de <see cref="Statut"/> en liste de <see cref="StatutDto"/>.
        /// </summary>
        /// <param name="dtos">La liste de Dto.</param>
        /// <returns>La liste d'entity convertie.</returns>
        internal static List<StatutDto> ConvertToDto(List<Statut> entities)
        {
            if (entities == null)
            {
                return null;
            }

            List<StatutDto> dtos = new List<StatutDto>();

            foreach(var entity in entities)
            {
                dtos.Add(ConvertToDto(entity));
            }

            return dtos;
        }

        /// <summary>
        /// Convertit un <see cref="Statut"/> en <see cref="StatutDto"/>.
        /// </summary>
        /// <param name="dto">Le dto à convertir.</param>
        /// <returns>L'entity convertit</returns>
        internal static StatutDto ConvertToDto(Statut entity)
        {
            if (entity == null)
            {
                return null;
            }

            StatutDto dto = new StatutDto();
            dto.Id = entity.Id;
            dto.Libelle = entity.Libelle;

            return dto;
        }

        /// <summary>
        /// Convertit une liste de <see cref="StatutDto"/> en liste de <see cref="Statut"/>.
        /// </summary>
        /// <param name="vms">La liste de entity.</param>
        /// <returns>La liste de dto convertie.</returns>
        internal static List<Statut> ConvertToEntity(List<StatutDto> dtos)
        {
            if (dtos == null)
            {
                return null;
            }

            List<Statut> entities = new List<Statut>();

            foreach (var dto in dtos)
            {
                entities.Add(ConvertToEntity(dto));
            }

            return entities;
        }

        /// <summary>
        /// Convertit un <see cref="StatutDto"/> en <see cref="Statut"/>.
        /// </summary>
        /// <param name="vm">L'entity à convertir.</param>
        /// <returns>Le dto convertit</returns>
        internal static Statut ConvertToEntity(StatutDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            Statut entity = new Statut();
            entity.Id = dto.Id;
            entity.Libelle = dto.Libelle;

            return entity;
        }
    }
}
