using ModelDonnees.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels.Common;

namespace WPF.ViewModels
{
    public class DetailOffreViewModel : BaseViewModel
    {
        #region Variables

        private string _intitule;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// <param name="p">Produit à transformer en DetailProduitViewModel</param>
        /// </summary>
        public DetailOffreViewModel(Offre offre)
        {
            _intitule = offre.Intitule;
        }

        #endregion

        #region Data Bindings

        /// <summary>
        /// Intitulé d'une offre
        /// </summary>
        public string Intitule
        {
            get { return _intitule; }
            set { _intitule = value; }
        }
        

        #endregion
    }
}
