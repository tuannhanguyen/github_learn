using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStore.Controllers
{
    public class Home_Controller : Controller
    {
        MobileStoreEntities _db = new MobileStoreEntities();

        // GET: Home_
        public ActionResult Index()
        {
            return View(_db.Products.ToList());
        }
    }
}