using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.Data;
using PagedList;
using PagedList.Mvc;

namespace WebLaptop3.Controllers
{
    public class TimKiemController : Controller
    {
        QuanLyLaptopNewModel db = new QuanLyLaptopNewModel();

        [HttpPost]
        // POST: TimKiem
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string tuKhoa = f["txtTimKiem"];
            string loaiTimKiem = f["cbLoaiTimKiem"];
            ViewBag.TuKhoa = tuKhoa;
            ViewBag.LoaiTK = loaiTimKiem;

            // từ khóa contains giống like trong sql
            List<Laptop> lstKetQua = db.Laptops.Where(n => n.TenLaptop.Contains(tuKhoa)).ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 10;
            if (lstKetQua.Count == 0)
            {
                ViewBag.ThongBaoTimKiem = "Không có sản phẩm nào!";
                return View(db.Laptops.ToPagedList(pageNumber,pageSize));
            }
            ViewBag.ThongBaoTimKiem = "Đã tìm thấy "+lstKetQua.Count;
            return View(lstKetQua.ToPagedList(pageNumber,pageSize));
        }

        [HttpGet]
        public ActionResult KetQuaTimKiem(string tuKhoa,string loaiTimKiem, int? page)
        {
            ViewBag.TuKhoa = tuKhoa;
            // từ khóa contains giống like trong sql
            List<Laptop> lstKetQua = db.Laptops.Where(n => n.TenLaptop.Contains(tuKhoa)).ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 10;
            if (lstKetQua.Count == 0)
            {
                ViewBag.ThongBaoTimKiem = "Không có sản phẩm nào!";
                return View(db.Laptops.ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBaoTimKiem = "Đã tìm thấy " + lstKetQua.Count;
            return View(lstKetQua.ToPagedList(pageNumber, pageSize));
        }
    }
}