using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees
{
    public class Initializer : DropCreateDatabaseIfModelChanges<ContextDA>
    {
        protected override void Seed(ContextDA context)
        {
            context.Statuts.Add(new Statut() { Libelle = "Disponible" });
            context.Offres.Add(new Offre() { Intitule = "Offre" });


            base.Seed(context);
        }
    }
}
