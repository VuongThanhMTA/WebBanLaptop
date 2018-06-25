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
        QuanLyLaptopNewModel db = new QuanLyLaptopNewModel();

        // GET: DangKyDangNhap
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DKDNPartial()
        {
            return PartialView();
        }

        [HttpGet] // load lại view
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]// lấy dữ liệu truyền vào KhachHang
        public ActionResult DangKy(KhachHang kh)
        {
            if (ModelState.IsValid) {
                db.KhachHangs.Add(kh);

                db.SaveChanges();
                ViewBag.ThongBao = "Đăng ký thành công";
            }
           
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
                if (kiemTraTaiKhoan(kh.TaiKhoan))
                {
                    ModelState.AddModelError("", "Tên tài khoản đã tồn tại!");
                }
                else
                {
                    db.KhachHangs.Add(kh);
                    db.SaveChanges();
                    ViewBag.ThongBao = "Đăng ký thành công";
                }
            }
            return View();
        }


        public bool kiemTraTaiKhoan(string taiKhoan)
        {
            return db.KhachHangs.Count(n => n.TaiKhoan == taiKhoan) > 0;
        }


        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}