using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.NewData;
using PagedList;
using PagedList.Mvc;

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

        public PartialViewResult ListLaptopPartial(String maLoaiLaptop)
        {
            var listLaptop = db.Laptops.Where(n => n.MaLoaiLaptop == maLoaiLaptop).Take(5).ToList();
            
            return PartialView(listLaptop);

        }

        public PartialViewResult AllLaptopPartial(int? pageTemp) {
            int pageSize = 8;
            int pageNumber = pageTemp ?? 1;
            
            return PartialView(db.Laptops.ToList().OrderBy(a => a.TenLaptop).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DetailLaptop(String maLaptop) {
            Laptop laptop = db.Laptops.SingleOrDefault(n => n.MaLaptop == maLaptop);
            return View(laptop);
        }
    }
}
