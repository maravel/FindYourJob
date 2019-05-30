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
    public class ListPostulantViewModel : BaseViewModel
    {
        #region Variables
        
        private IService service;
        private ObservableCollection<Postulation> _postulation;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ListPostulantViewModel(int idOffre)
        {
            service = new Service();
            _postulation = new ObservableCollection<Postulation>();
            
            List<Postulation> postulations = new List<Postulation>();

            Task t = Task.Run(async () =>
            {
                postulations = await service.GetPostulations(offreId: idOffre);
            });
            
            t.Wait();

            // on trie les offres par date (la plus récente en premier)
            postulations = postulations.OrderByDescending(o => o.Date).ToList();

            foreach (Postulation p in postulations)
            {
                _postulation.Add(p);
            }
        }

        #endregion

        #region Data Bindings

        /// <summary>
        /// Obtient ou définit une collection de <see cref="Postulation"/>(Observable)
        /// </summary>
        public ObservableCollection<Postulation> Postulants
        {
            get { return _postulation; }
            set
            {
                _postulation = value;
                OnPropertyChanged("Postulants");
            }
        }

        #endregion
    }
}
