using ModelDonnees.Entity;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.ViewModels.Common;

namespace WPF.ViewModels
{
    public class AjoutOffreViewModel : BaseViewModel
    {
        #region Variables
        
        private IService service;
        private RelayCommand _createOperation;
        public Action CloseAction { get; set; }
        private string _intitule;

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

        /// <summary>
        /// Intitulé d'une offre
        /// </summary>
        public string IntituleCreate
        {
            get { return _intitule; }
            set
            {
                _intitule = value;
                OnPropertyChanged("IntituleCreate");
            }
        }

        #endregion

        #region Commandes

        /// <summary>
        /// Commande pour créer une offre
        /// </summary>
        public ICommand CreateOffre
        {
            get
            {
                if (_createOperation == null)
                    _createOperation = new RelayCommand(() => this.CloseWindowAddOffer());
                return _createOperation;
            }
        }

        /// <summary>
        /// Permet l'ouverture de la fenêtre
        /// </summary>
        private void CloseWindowAddOffer()
        {
            Console.WriteLine("create");
        }

        #endregion
    }
}
