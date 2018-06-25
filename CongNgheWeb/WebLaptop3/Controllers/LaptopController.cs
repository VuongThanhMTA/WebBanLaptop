using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.Data_minh;
using PagedList;
using PagedList.Mvc;

namespace WebLaptop3.Controllers
{
    public class LaptopController : Controller
    {
        // GET: Laptop
        Quanlylaptop_minh db = new Quanlylaptop_minh();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult FirstLaptopPartial()
        {
            var listLaptop = db.Laptop.Take(3).ToList();
            return PartialView(listLaptop);
        }

        public PartialViewResult ListLaptopPartial(int maLoaiLaptop)
        {
            var listLaptop = db.Laptop.Where(n => n.MaLoaiLaptop == maLoaiLaptop).Take(5).ToList();

            return PartialView(listLaptop);

        }

        public PartialViewResult AllLaptopPartial(int? pageTemp)
        {
            int pageSize = 10;
            int pageNumber = pageTemp ?? 1;

            return PartialView(db.Laptop.ToList().OrderBy(a => a.TenLaptop).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DetailLaptop(int maLaptop)
        {
            Laptop laptop = db.Laptop.SingleOrDefault(n => n.MaLaptop == maLaptop);
            return View(laptop);
        }
    }
}
