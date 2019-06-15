using Dto.Dto;
using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Converter
{
    internal class StatutConverter
    {

        internal static List<StatutDto> ConvertToDto(List<Statut> entities)
        {
            if(entities == null)
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

        internal static StatutDto ConvertToDto(Statut entity)
        {
            if(entity == null)
            {
                return null;
            }

            StatutDto dto = new StatutDto();
            dto.Id = entity.Id;
            dto.Libelle = entity.Libelle;

            return dto;
        }

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
