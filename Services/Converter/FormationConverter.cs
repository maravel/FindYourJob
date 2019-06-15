using Dto.Dto;
using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Converter
{
    internal class FormationConverter
    {

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
