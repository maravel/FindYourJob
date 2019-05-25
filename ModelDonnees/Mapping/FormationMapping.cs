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
    /// Mapping de l'entité <see cref="Formation"/>
    /// </summary>
    public class FormationMapping : EntityTypeConfiguration<Formation>
    {
        public FormationMapping()
        {
            ToTable("APP_FORMATION");
            HasKey(k => k.Id);

            Property(p => p.Id)
                .HasColumnName("FOR_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(p => p.Intitule)
                .HasColumnName("FOR_INTITULE")
                .IsOptional();

            Property(p => p.Date)
                .HasColumnName("FOR_DATE")
                .HasColumnType("datetime2")
                .IsOptional();

            Property(p => p.EmployeId)
                .HasColumnName("EMP_ID")
                .IsRequired();

            HasRequired(p => p.Employe).WithMany(e => e.Formations).HasForeignKey(f => f.EmployeId);
        }
    }
}
