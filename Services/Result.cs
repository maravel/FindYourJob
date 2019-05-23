using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Definie le résultat d'une méthode de service ne retournant aucune donnée (ajout, modification, suppression, ...)
    /// </summary>
    public class Result
    {
        private TypeRetour error;

        public Result(TypeRetour error)
        {
            this.error = error;
        }

        public Result(TypeRetour error, string message)
        {
            this.error = error;
        }

        /// <summary>
        /// Type de retour de la méthode
        /// </summary>
        public TypeRetour Type { get; set; }

        /// <summary>
        /// Message décrivant l'erreur
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Affirme si le resultat possède une erreur
        /// </summary>
        /// <returns></returns>
        public bool HasError()
        {
            return this.Type == TypeRetour.Error;
        }
    }
}
