using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.Data_minh;

namespace WebLaptop3.Controllers
{
    public class LoaiLaptopController : Controller
    {
        // GET: LoaiLaptop
        Quanlylaptop_minh db = new Quanlylaptop_minh();

        public ActionResult LoaiLaptopPartial()
        {
            return PartialView(db.LoaiLaptop.ToList());
        }

    }
}