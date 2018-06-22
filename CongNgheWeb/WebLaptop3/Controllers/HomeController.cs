using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.NewData;

namespace WebLaptop3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        QuanLyLaptopModel1 db = new QuanLyLaptopModel1();
        public ActionResult Index()
        {
            return View();
        }

       
    }
}