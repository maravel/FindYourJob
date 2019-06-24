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
            List<Statut> statuts = new List<Statut>();
            statuts.Add(new Statut() { Libelle = "Disponible" });

            base.Seed(context);
        }
    }
}
