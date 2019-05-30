using ModelDonnees.Entity;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels.Common;

namespace WPF.ViewModels
{
    public class AjoutOffreViewModel : BaseViewModel
    {
        #region Variables
        
        private IService service;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public AjoutOffreViewModel()
        {
            service = new Service();
            
        }

        #endregion


        #region Data Bindings

        
        #endregion
    }
}
