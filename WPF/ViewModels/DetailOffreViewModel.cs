using Dto.Dto;
using ModelDonnees.Entity;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WPF.ViewModels.Common;

namespace WPF.ViewModels
{
    public class DetailOffreViewModel : BaseViewModel
    {
        #region Variables

        private IService service;
        private string _intitule;
        private DateTime _date;
        private double _salaire;
        private string _description;
        private string _responsable;
        private RelayCommand _addOperation;

        private ListPostulantViewModel _listePostulantViewModel = null;

        private int _statut;
        private CollectionView _statuts;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// <param name="p">Offre à transformer en DetailOffreViewModel</param>
        /// </summary>
        public DetailOffreViewModel(OffreDto offre)
        {
            service = new Service();
            _intitule = offre.Intitule;
            _date = offre.Date;
            _description = offre.Description;
            _salaire = offre.Salaire;
            _responsable = offre.Responsable;
            _listePostulantViewModel = new ListPostulantViewModel(offre.Id);
            _statut = offre.StatutId;

            Task t = Task.Run(async () =>
            {
                IList<Statut> listeStatuts = await service.GetStatuts();
                _statuts = new CollectionView(listeStatuts);
            });

            t.Wait();
        }

        #endregion

        #region Data Bindings

        /// <summary>
        /// Intitulé d'une offre
        /// </summary>
        public string Intitule
        {
            get { return _intitule; }
            set {
                _intitule = value;
                OnPropertyChanged("Intitule");
            }
        }

        /// <summary>
        /// Date d'une offre
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        /// <summary>
        /// Salaire de l'offre
        /// </summary>
        public double Salaire
        {
            get { return _salaire; }
            set { _salaire = value; }
        }

        /// <summary>
        /// Description de l'offre
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Statut de l'offre
        /// </summary>
        public int Statut
        {
            get { return _statut; }
            set {
                if (_statut == value) return;
                _statut = value;
                OnPropertyChanged("Statut");
            }
        }

        /// <summary>
        /// Statut de l'offre
        /// </summary>
        public CollectionView Statuts
        {
            get { return new CollectionView(_statuts); }
        }

        /// <summary>
        /// Responsable de l'offre
        /// </summary>
        public string Responsable
        {
            get { return _responsable; }
            set { _responsable = value; }
        }

        /// <summary>
        /// Obtient ou définit le <see cref="ListPostulantViewModel"/>
        /// </summary>
        public ListPostulantViewModel ListPostulantViewModel
        {
            get { return _listePostulantViewModel; }
            set { _listePostulantViewModel = value; }
        }

        #endregion

        #region Commandes

        /// <summary>
        /// Commande pour ouvrir la fenêtre pour ajouter une offre
        /// </summary>
        public ICommand AjouterOffre
        {
            get
            {
                if (_addOperation == null)
                    _addOperation = new RelayCommand(() => this.ShowWindowAddOffer());
                return _addOperation;
            }
        }

        /// <summary>
        /// Permet l'ouverture de la fenêtre
        /// </summary>
        private void ShowWindowAddOffer()
        {
            Views.AddOffre operationWindow = new Views.AddOffre();
            operationWindow.DataContext = this;
            operationWindow.ShowDialog();
        }

        #endregion
        
    }
}
