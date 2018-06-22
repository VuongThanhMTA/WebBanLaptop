using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.NewData;

namespace WebLaptop3.Controllers
{
    public class LoaiLaptopController : Controller
    {
        // GET: LoaiLaptop
        QuanLyLaptopModel1 db = new QuanLyLaptopModel1();

        public ActionResult LoaiLaptopPartial()
        {
            return PartialView(db.LoaiLaptops.ToList());
        }

    }
}