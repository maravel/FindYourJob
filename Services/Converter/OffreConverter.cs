using Dto.Dto;
using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Converter
{
    public class OffreConverter
    {

        public static List<OffreDto> ConvertToDto(List<Offre> entities)
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

        public static OffreDto ConvertToDto(Offre entity)
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
    }
}
