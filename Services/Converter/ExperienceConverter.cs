using Dto.Dto;
using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Converter
{
    internal class ExperienceConverter
    {

        internal static List<ExperienceDto> ConvertToDto(List<Experience> entities)
        {
            if(entities == null)
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

        internal static ExperienceDto ConvertToDto(Experience entity)
        {
            if(entity == null)
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
