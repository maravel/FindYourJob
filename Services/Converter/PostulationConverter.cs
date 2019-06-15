using Dto.Dto;
using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Converter
{
    internal class PostulationConverter
    {

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
