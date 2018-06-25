using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.Data_minh;

namespace WebLaptop3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Quanlylaptop_minh db = new Quanlylaptop_minh();
        public ActionResult Index()
        {
        
            return View();
        }


    }
}