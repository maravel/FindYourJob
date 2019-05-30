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
    public class ListeOffreViewModel : BaseViewModel
    {
        #region Variables

        private ObservableCollection<DetailOffreViewModel> _offres = null;
        private DetailOffreViewModel _selectedOffre;
        private IService service;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ListeOffreViewModel()
        {
            service = new Service();

            _offres = new ObservableCollection<DetailOffreViewModel>();

            List<Offre> offres = new List<Offre>();

            Task t = Task.Run(async () =>
            {
                offres = await service.GetOffres();
            });
            
            t.Wait();

            // on trie les offres par date (la plus récente en premier)
            offres = offres.OrderByDescending(o => o.Date).ToList();

            foreach (Offre o in offres)
            {
                _offres.Add(new DetailOffreViewModel(o));
            }

            if (_offres != null && _offres.Count > 0)
                _selectedOffre = _offres.ElementAt(0);
        }

        #endregion


        #region Data Bindings

        /// <summary>
        /// Obtient ou définit une collection de DetailProduitViewModel (Observable)
        /// </summary>
        public ObservableCollection<DetailOffreViewModel> Offres
        {
            get { return _offres; }
            set
            {
                _offres = value;
                OnPropertyChanged("Offres");
            }
        }

        /// <summary>
        /// Obtient ou défini le produit en cours de sélection dans la liste de DetailProduitViewModel
        /// </summary>
        public DetailOffreViewModel SelectedOffre
        {
            get { return _selectedOffre; }
            set
            {
                _selectedOffre = value;
                OnPropertyChanged("SelectedOffre");
            }
        }


        #endregion
    }
}
