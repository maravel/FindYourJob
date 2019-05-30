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
    /// Mapping de l'entité <see cref="Postulation"/>
    /// </summary>
    public class PostulationMappping : EntityTypeConfiguration<Postulation>
    {
        public PostulationMappping()
        {
            ToTable("APP_POSTULATION");
            HasKey(k => new { k.OffreId, k.EmployeId });

            Property(p => p.OffreId)
                .HasColumnName("OFF_ID")
                .IsRequired();

            Property(p => p.EmployeId)
                .HasColumnName("EMP_ID")
                .IsRequired();

            Property(p => p.Date)
                .HasColumnName("POS_DATE")
                .HasColumnType("datetime2")
                .IsOptional();

            Property(p => p.StatutId)
                .HasColumnName("POS_STATUT_ID")
                .IsOptional();

            HasRequired(p => p.Employe).WithMany(e => e.Postulations).HasForeignKey(f => f.EmployeId);

            HasRequired(p => p.Statut).WithMany(e => e.Postulations).HasForeignKey(f => f.StatutId);
        }
    }
}
