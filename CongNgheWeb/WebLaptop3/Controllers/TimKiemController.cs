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
    public class TimKiemController : Controller
    {
        Quanlylaptop_minh db = new Quanlylaptop_minh();

        [HttpPost]
        // POST: TimKiem
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string tuKhoa = f["txtTimKiem"];
            string loaiTimKiem = f["cbLoaiTimKiem"];
            ViewBag.TuKhoa = tuKhoa;
            ViewBag.LoaiTK = loaiTimKiem;

            // từ khóa contains giống like trong sql
            List<Laptop> lstKetQua = db.Laptop.Where(n => n.TenLaptop.Contains(tuKhoa)).ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 10;
            if (lstKetQua.Count == 0)
            {
                ViewBag.ThongBaoTimKiem = "Không có sản phẩm nào!";
                return View(db.Laptop.OrderBy(n=>n.TenLaptop).ToPagedList(pageNumber,pageSize));
            }
            ViewBag.ThongBaoTimKiem = "Đã tìm thấy "+lstKetQua.Count;
            return View(lstKetQua.OrderBy(n => n.TenLaptop).ToPagedList(pageNumber,pageSize));
        }

        [HttpGet]
        public ActionResult KetQuaTimKiem( int? page, string tuKhoa)
        {
            ViewBag.TuKhoa = tuKhoa;
            // từ khóa contains giống like trong sql
            List<Laptop> lstKetQua = db.Laptop.Where(n => n.TenLaptop.Contains(tuKhoa)).ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 10;
            if (lstKetQua.Count == 0)
            {
                ViewBag.ThongBaoTimKiem = "Không có sản phẩm nào!";
                return View(db.Laptop.OrderBy(n => n.TenLaptop).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBaoTimKiem = "Đã tìm thấy " + lstKetQua.Count;
            return View(lstKetQua.OrderBy(n => n.TenLaptop).ToPagedList(pageNumber, pageSize));
        }
    }
}