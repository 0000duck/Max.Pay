using System;
using System.Web.Mvc;
using Max.Framework;
using Max.Framework.DAL;
using System.Text;

namespace Max.Web.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
          
        }
        
        public ActionResult Index()
        {

            return View();
        }
    }
}