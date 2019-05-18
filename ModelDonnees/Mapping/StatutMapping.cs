using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees.Mapping
{
    /// <summary>
    /// Mapping de l'entité <see cref="Statut"/>
    /// </summary>
    public class StatutMapping : EntityTypeConfiguration<Statut>
    {
        public StatutMapping()
        {
            ToTable("APP_STATUT");
            HasKey(k => k.Id);

            Property(p => p.Id)
                .HasColumnName("STA_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(p => p.Libelle)
                .HasColumnName("STA_LIBELLE")
                .IsOptional();

        }
    }
}
