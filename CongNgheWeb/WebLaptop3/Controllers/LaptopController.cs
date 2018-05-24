using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.Data;

namespace WebLaptop3.Controllers
{
    public class LaptopController : Controller
    {
        // GET: Laptop
        QuanLyBanLaptopModel db = new QuanLyBanLaptopModel();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult FirstLaptopPartial()
        {
            var listLaptop = db.Laptops.Take(3).ToList();
            return PartialView(listLaptop);
        }
    }
}