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
            ViewBag.ThongBao = "Đăng ký thành công";
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f) 
        {
            String sTaiKhoan = f["txtTaiKhoan"].ToString();
            String sMatKhau = f["txtPassword"].ToString();

            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công";
                Session["TaiKhoan"] = kh;
                //return View("Index","DangKyDangNhap");
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";
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
                ViewBag.ThongBao = "Đăng ký thành công";
            }
            return View();
        }
    }
}