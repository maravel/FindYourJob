using ModelDonnees.Entity;
using ModelDonnees.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees
{
    public class ContextDA : DbContext
    {
        public ContextDA() : base("name=ConnexionString")
        {
            //Database.SetInitializer<ContextDA>(new DropCreateDatabaseAlways<ContextDA>());
            Database.SetInitializer<ContextDA>(new Initializer());
        }

        public DbSet<Offre> Offres { get; set; }

        public DbSet<Employe> Employes { get; set; }

        public DbSet<Formation> Formations { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Postulation> Postulations { get; set; }

        public DbSet<Statut> Statuts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Configurations.Add(new OffreMapping());
            modelBuilder.Configurations.Add(new EmployeMapping());
            modelBuilder.Configurations.Add(new FormationMapping());
            modelBuilder.Configurations.Add(new ExperienceMapping());
            modelBuilder.Configurations.Add(new PostulationMappping());
            modelBuilder.Configurations.Add(new StatutMapping());
        }

    }
}
