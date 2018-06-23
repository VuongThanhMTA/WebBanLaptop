using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.NewData;

namespace WebLaptop3.Controllers
{
    public class DangKyDangNhapController : Controller
    {
        QuanLyLaptopModel1 db = new QuanLyLaptopModel1();

        // GET: DangKyDangNhap
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet] // load lại view
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]// lấy dữ liệu truyền vào KhachHang
        public ActionResult DangKy(KhachHang kh)
        {
            db.KhachHangs.Add(kh);

            db.SaveChanges(); 
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy1()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy1(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(kh);

                db.SaveChanges();
            }
            return View();
        }
    }
}