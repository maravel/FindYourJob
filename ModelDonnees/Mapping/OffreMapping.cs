using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees.Mapping
{
    /// <summary>
    /// Mapping de l'entité <see cref="Offre"/>
    /// </summary>
    public class OffreMapping : EntityTypeConfiguration<Offre>
    {
        public OffreMapping ()
        {
            ToTable("APP_OFFRE");
            HasKey(k => k.Id);

            Property(p => p.Id)
                .HasColumnName("OFF_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(p => p.Intitule)
                .HasColumnName("OFF_INTITULE")
                .IsOptional();

            Property(p => p.Date)
                .HasColumnName("OFF_DATE")
                .IsOptional();

            Property(p => p.Salaire)
                .HasColumnName("OFF_SALAIRE")
                .IsOptional();

            Property(p => p.Description)
                .HasColumnName("OFF_DESCRIPTION")
                .IsOptional();

            Property(p => p.Responsable)
                .HasColumnName("OFF_RESPONSABLE")
                .IsOptional();

            Property(p => p.StatutId)
                .HasColumnName("STA_ID")
                .IsRequired();

            HasRequired(p => p.Statut).WithMany(m => m.Offres).HasForeignKey(f => f.StatutId);
        }
        
    }
}
