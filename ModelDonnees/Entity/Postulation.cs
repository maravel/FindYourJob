using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees.Entity
{
    public class Postulation
    {
        public int OffreId { get; set; }

        public int EmployeId { get; set; }

        public DateTime Date { get; set; }

        public int Statut { get; set; }
        
    }
}
