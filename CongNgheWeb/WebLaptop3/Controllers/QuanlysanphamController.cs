using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.Data_minh;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace WebLaptop3.Controllers
{
    public class QuanlysanphamController : Controller
    {
        Quanlylaptop_minh db = new Quanlylaptop_minh();
        // GET: Quanlysanpham
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.Laptop.ToList().OrderBy(n=>n.MaLaptop).ToPagedList(pageNumber,pageSize));
        }
        //Thêm Mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            //Thêm dữ liệu vào dropdownlist
            ViewBag.MaLoaiLaptop = new SelectList(db.LoaiLaptop.ToList().OrderBy(n => n.TenLoaiLaptop), "MaLoaiLapTop", "TenLoaiLapTop");
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCap.ToList().OrderBy(n => n.TenNhaCungCap), "MaNhaCungCap", "TenNhaCungCap");
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(Laptop laptop, HttpPostedFileBase fileUpload)
        {
            
            //Thêm dữ liệu vào dropdownlist
            ViewBag.MaLoaiLaptop = new SelectList(db.LoaiLaptop.ToList().OrderBy(n => n.TenLoaiLaptop), "MaLoaiLapTop", "TenLoaiLapTop");
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCap.ToList().OrderBy(n => n.TenNhaCungCap), "MaNhaCungCap", "TenNhaCungCap");
            //kiểm tra đường dẫn ảnh laptop
            if(fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View();
            }
            //thêm vào cơ sở dữ liệu
           
                //lưu tên file
                var fileName = Path.GetFileName(fileUpload.FileName);
                //lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/Content/Admin/img/"), fileName);
                //Kiểm tra hình ảnh đã tồn tại chưa
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                laptop.Anh = fileUpload.FileName;
                db.Laptop.Add(laptop);
                db.SaveChanges();
           

            return View();
        }

        [HttpGet]
        public ActionResult ChinhSua(int MaLaptop)
        {
            //lấy ra đối tượng để chỉnh sửa theo mã
            Laptop laptop = db.Laptop.SingleOrDefault(n => n.MaLaptop == MaLaptop);
            if(MaLaptop == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Thêm dữ liệu vào dropdownlist
            ViewBag.MaLoaiLaptop = new SelectList(db.LoaiLaptop.ToList().OrderBy(n => n.TenLoaiLaptop), "MaLoaiLapTop", "TenLoaiLapTop");
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCap.ToList().OrderBy(n => n.TenNhaCungCap), "MaNhaCungCap", "TenNhaCungCap");

            return View(laptop);
        }
        [HttpPost]
        public ActionResult ChinhSua(Laptop laptop)
        {
            //kiểm tra đường dẫn ảnh laptop
            //if (fileUpload == null)
            //{
            //    ViewBag.ThongBao = "Chọn hình ảnh";
            //    return View();
            //}
            //thêm vào cơ sở dữ liệu

            //lưu tên file
            //var fileName = Path.GetFileName(fileUpload.FileName);
            //lưu đường dẫn của file
            //var path = Path.Combine(Server.MapPath("/HinhanhSP"), fileName);
            //Kiểm tra hình ảnh đã tồn tại chưa
            //if (System.IO.File.Exists(path))
            //{
            //    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
            //}
            //else
            //{
            //    fileUpload.SaveAs(path);
            //}
            //laptop.Anh = fileUpload.FileName;

            //thực hiện cập nhật trong model
            db.Entry(laptop).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            //Thêm dữ liệu vào dropdownlist
            ViewBag.MaLoaiLaptop = new SelectList(db.LoaiLaptop.ToList().OrderBy(n => n.TenLoaiLaptop), "MaLoaiLapTop", "TenLoaiLapTop");
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCap.ToList().OrderBy(n => n.TenNhaCungCap), "MaNhaCungCap", "TenNhaCungCap");


            return View();
        }

        //xóa sản phẩm
        [HttpGet]
        public ActionResult Xoa(int MaLaptop)
        {
            //lấy ra đối tượng để chỉnh sửa theo mã
            Laptop laptop = db.Laptop.SingleOrDefault(n => n.MaLaptop == MaLaptop);
            if (MaLaptop == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(laptop);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult Xacnhanxoa(int MaLaptop)
        {
            Laptop laptop = db.Laptop.SingleOrDefault(n => n.MaLaptop == MaLaptop);
            if (MaLaptop == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Laptop.Remove(laptop);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    } 
}