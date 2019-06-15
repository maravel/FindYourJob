﻿using Dto.Dto;
using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Converter
{
    internal class OffreConverter
    {

        internal static List<OffreDto> ConvertToDto(List<Offre> entities)
        {
            if(entities == null)
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

        internal static OffreDto ConvertToDto(Offre entity)
        {
            if(entity == null)
            {
                return null;
            }

            OffreDto dto = new OffreDto();
            dto.Id = entity.Id;
            dto.Intitule = entity.Intitule;
            dto.Responsable = entity.Responsable;
            dto.Salaire = entity.Salaire;
            dto.StatutId = entity.StatutId;
            dto.Description = entity.Description;
            dto.Date = entity.Date;

            return dto;
        }

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
