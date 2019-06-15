using Dto.Dto;
using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Converter
{
    internal class EmployeConverter
    {

        internal static List<EmployeDto> ConvertToDto(List<Employe> entities)
        {
            if(entities == null)
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

        internal static EmployeDto ConvertToDto(Employe entity)
        {
            if(entity == null)
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

            return dto;
        }

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
