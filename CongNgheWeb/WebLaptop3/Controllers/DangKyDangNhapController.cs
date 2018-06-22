using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.Data;

namespace WebLaptop3.Controllers
{
    public class DangKyDangNhapController : Controller
    {
        QuanLyBanLaptopModel db = new QuanLyBanLaptopModel();

        // GET: DangKyDangNhap
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KhachHang kh)
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }

        public ActionResult DangKy1()
        {
            return View();
        }
    }
}