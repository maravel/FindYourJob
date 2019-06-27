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
    /// Convertisseur de <see cref="Offre"/> en <see cref="OffreDto"/> et vice versa.
    /// </summary>
    internal class OffreConverter
    {
        /// <summary>
        /// Convertit une liste de <see cref="Offre"/> en liste de <see cref="OffreDto"/>.
        /// </summary>
        /// <param name="dtos">La liste de Dto.</param>
        /// <returns>La liste d'entity convertie.</returns>
        internal static List<OffreDto> ConvertToDto(List<Offre> entities)
        {
            if (entities == null)
            {
                return null;
            }

            List<OffreDto> dtos = new List<OffreDto>();

            foreach(var entity in entities)
            {
                dtos.Add(ConvertToDto(entity));
            }

            return dtos;
        }

        /// <summary>
        /// Convertit un <see cref="Offre"/> en <see cref="OffreDto"/>.
        /// </summary>
        /// <param name="dto">Le dto à convertir.</param>
        /// <returns>L'entity convertit</returns>
        internal static OffreDto ConvertToDto(Offre entity)
        {
            if (entity == null)
            {
                return null;
            }

            OffreDto dto = new OffreDto();
            dto.Id = entity.Id;
            dto.Intitule = entity.Intitule;
            dto.Responsable = entity.Responsable;
            dto.Salaire = entity.Salaire;
            dto.StatutId = entity.StatutId;
            dto.Statut = StatutConverter.ConvertToDto(entity.Statut);
            dto.Description = entity.Description;
            dto.Date = entity.Date;

            return dto;
        }

        /// <summary>
        /// Convertit une liste de <see cref="OffreDto"/> en liste de <see cref="Offre"/>.
        /// </summary>
        /// <param name="vms">La liste de entity.</param>
        /// <returns>La liste de dto convertie.</returns>
        internal static List<Offre> ConvertToEntity(List<OffreDto> dtos)
        {
            if (dtos == null)
            {
                return null;
            }

            List<Offre> entities = new List<Offre>();

            foreach (var dto in dtos)
            {
                entities.Add(ConvertToEntity(dto));
            }

            return entities;
        }

        /// <summary>
        /// Convertit un <see cref="OffreDto"/> en <see cref="Offre"/>.
        /// </summary>
        /// <param name="vm">L'entity à convertir.</param>
        /// <returns>Le dto convertit</returns>
        internal static Offre ConvertToEntity(OffreDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            Offre entity = new Offre();
            entity.Id = dto.Id;
            entity.Intitule = dto.Intitule;
            entity.Responsable = dto.Responsable;
            entity.Salaire = dto.Salaire;
            entity.StatutId = dto.StatutId;
            entity.Description = dto.Description;
            entity.Date = dto.Date;

            return entity;
        }
    }
}
