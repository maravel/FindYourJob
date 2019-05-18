using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees.Entity
{
    public class Offre
    {
        public int Id { get; set; }

        public string Intitule { get; set; }

        public DateTime Date { get; set; }

        public double Salaire { get; set; }

        public string Description { get; set; }

        public int StatutId { get; set; }

        public Statut Statut { get; set; }

        public string Responsable { get; set; }

    }
}
