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
    public class QuanlykhachhangController : Controller
    {
        Quanlylaptop_minh db = new Quanlylaptop_minh();
        // GET: Quanlykhachhang
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.KhachHang.ToList().OrderBy(n => n.TenKhachHang).ToPagedList(pageNumber, pageSize));
            return View();
        }

        //Thêm Mới
        [HttpGet]
        public ActionResult ThemMoi()
        {

            return View();
        }

        [HttpPost]

        public ActionResult ThemMoi(KhachHang khachhang)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.SelectMany(m => m.Value.Errors).Select(e => e.ErrorMessage).ToList();

                // todo with errors

                return View(khachhang);
            }
            //thêm vào cơ sở dữ liệu
            db.KhachHang.Add(khachhang);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult ChinhSua(int MaKhachHang)
        {
            //lấy ra đối tượng để chỉnh sửa theo mã
            KhachHang khachhang = db.KhachHang.SingleOrDefault(n => n.MaKhachHang == MaKhachHang);
            if (MaKhachHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(khachhang);
        }

        [HttpPost]

        public ActionResult ChinhSua(KhachHang khachhang)
        {
            db.Entry(khachhang).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return View();
        }
        //xóa nhà cung cấp
        [HttpGet]
        public ActionResult Xoa(int MaKhachHang)
        {
            //lấy ra đối tượng để chỉnh sửa theo mã
            KhachHang khachhang = db.KhachHang.SingleOrDefault(n => n.MaKhachHang == MaKhachHang);
            if (MaKhachHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(khachhang);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult Xacnhanxoa(int MaKhachHang)
        {
            
            //lấy ra đối tượng để chỉnh sửa theo mã
            KhachHang khachhang = db.KhachHang.SingleOrDefault(n => n.MaKhachHang == MaKhachHang);
            if (MaKhachHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KhachHang.Remove(khachhang);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}