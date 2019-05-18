using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDonnees.Entity
{
    public class Experience
    {
        public int Id { get; set; }

        public int EmployeId { get; set; }

        public string Intitule { get; set; }

        public DateTime Date { get; set; }

        public Employe Employe { get; set; }
    }
}
