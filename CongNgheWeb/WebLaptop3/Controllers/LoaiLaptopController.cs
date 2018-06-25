using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.Data;

namespace WebLaptop3.Controllers
{
    public class LoaiLaptopController : Controller
    {
        // GET: LoaiLaptop
        QuanLyLaptopNewModel db = new QuanLyLaptopNewModel();

        public ActionResult LoaiLaptopPartial()
        {
            return PartialView(db.LoaiLaptops.ToList());
        }

    }
}