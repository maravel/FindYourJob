using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb.Controllers.Common
{
    public abstract class BaseController : Controller
    {
        internal IService service = new Service();
        internal int idUser;

        public BaseController()
        {
            int.TryParse(ConfigurationManager.AppSettings["connectedUser"], out int idconnected);
            this.idUser = idconnected;
        }
    }
}