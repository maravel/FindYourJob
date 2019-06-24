using ModelDonnees;
using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ContextDA context = new ContextDA();
            try
            {
                List<Offre> offres = context.Offres.Include("Statut").ToList();
            }
            catch (Exception )
            {

                throw;
            }
            
            
        }
    }
}
