using Max.Web.Management.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Max.Framework;
using Max.Framework.MongoDb;
using Max.Framework.NoSql;
using Max.Web.Management.Models.Home;

namespace Max.Web.Management.Controllers
{
    public class HomeController : BaseController
    {
        private IMongoProxy proxy;
        public HomeController(IMongoProxy proxy)
        {
            this.proxy = proxy;
        }

        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Do(CustomerValidation model)
        {
            return Json("成功");
        }
    }
}