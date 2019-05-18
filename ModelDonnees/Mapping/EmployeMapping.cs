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
    /// Mapping de l'entité <see cref="Employe"/>
    /// </summary>
    public class EmployeMapping : EntityTypeConfiguration<Employe>
    {
        public EmployeMapping ()
        {
            ToTable("APP_EMPLOYE");
            HasKey(k => k.Id);

            Property(p => p.Id)
                .HasColumnName("EMP_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(p => p.Nom)
                .HasColumnName("EMP_NOM")
                .IsOptional();

            Property(p => p.Prenom)
                .HasColumnName("EMP_PRENOM")
                .IsOptional();

            Property(p => p.DateNaissance)
                .HasColumnName("EMP_DATENAISSANCE")
                .IsOptional();

            Property(p => p.Anciennete)
                .HasColumnName("EMP_ANCIENNETE")
                .IsOptional();

            Property(p => p.Biographie)
                .HasColumnName("EMP_BIOGRAPHIE")
                .IsOptional();
            
        }
    }
}
