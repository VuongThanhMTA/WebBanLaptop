using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.NewData;

namespace WebLaptop3.Controllers
{
    public class LaptopController : Controller
    {
        // GET: Laptop
        QuanLyLaptopModel1 db = new QuanLyLaptopModel1();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult FirstLaptopPartial()
        {
            var listLaptop = db.Laptops.Take(3).ToList();
            return PartialView(listLaptop);
        }

        public PartialViewResult ListLaptopPartial()
        {
            var listLaptop = db.Laptops.Take(5).ToList();
            return PartialView(listLaptop);
        }

        public PartialViewResult AllLaptopPartial() {
            var listLaptop = db.Laptops.ToList();
            return PartialView(listLaptop);
        }

        public ActionResult DetailLaptop(String maLaptop) {
            Laptop laptop = db.Laptops.SingleOrDefault(n => n.MaLaptop == maLaptop);
            return View(laptop);
        }
    }
}