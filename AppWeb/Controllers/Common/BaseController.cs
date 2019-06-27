using Services;
using System.Configuration;
using System.Web.Mvc;

namespace AppWeb.Controllers.Common
{
    /// <summary>
    /// Contrôleur de base dont herite tous les contrôleur de l'application
    /// </summary>
    public abstract class BaseController : Controller
    {
        internal IService service = new Service();
        internal int idUser;

        /// <summary>
        /// Constructeur par defaut initialisant l'id de l'utilisateur
        /// </summary>
        public BaseController()
        {
            int.TryParse(ConfigurationManager.AppSettings["connectedUser"], out int idconnected);
            this.idUser = idconnected;
        }
    }
}