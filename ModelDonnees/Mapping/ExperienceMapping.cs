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
    /// Mapping de l'entité <see cref="Experience"/>
    /// </summary>
    public class ExperienceMapping : EntityTypeConfiguration<Experience>
    {
        public ExperienceMapping()
        {
            ToTable("APP_EXPERIENCE");
            HasKey(k => k.Id);

            Property(p => p.Id)
                .HasColumnName("EXP_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(p => p.Intitule)
                .HasColumnName("EXP_INTITULE")
                .IsOptional();

            Property(p => p.Date)
                .HasColumnName("EXP_DATE")
                .IsOptional();

            Property(p => p.EmployeId)
                .HasColumnName("EMP_ID")
                .IsRequired();

            HasRequired(p => p.Employe).WithMany(e => e.Experiences).HasForeignKey(f => f.EmployeId);

        }
    }
}
