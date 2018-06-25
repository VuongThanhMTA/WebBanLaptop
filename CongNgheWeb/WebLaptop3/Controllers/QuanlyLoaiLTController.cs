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
    public class QuanlyLoaiLTController : Controller
    {
        Quanlylaptop_minh db = new Quanlylaptop_minh();
        // GET: QuanlyLoaiLT
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.LoaiLaptop.ToList().OrderBy(n => n.TenLoaiLaptop).ToPagedList(pageNumber, pageSize));
            return View();
        }
        //Thêm Mới
        [HttpGet]
        public ActionResult ThemMoi()
        {

            return View();
        }

        [HttpPost]

        public ActionResult ThemMoi(LoaiLaptop loaiLaptop)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.SelectMany(m => m.Value.Errors).Select(e => e.ErrorMessage).ToList();

                // todo with errors

                return View(loaiLaptop);
            }
            //thêm vào cơ sở dữ liệu
            db.LoaiLaptop.Add(loaiLaptop);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult ChinhSua(int MaLoaiLaptop)
        {
            //lấy ra đối tượng để chỉnh sửa theo mã
            LoaiLaptop loailaptop = db.LoaiLaptop.SingleOrDefault(n => n.MaLoaiLaptop == MaLoaiLaptop);
            if (MaLoaiLaptop == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(loailaptop);
        }

        [HttpPost]

        public ActionResult ChinhSua(LoaiLaptop loailaptop)
        {
            db.Entry(loailaptop).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return View();
        }
        //xóa nhà cung cấp
        [HttpGet]
        public ActionResult Xoa(int MaLoaiLaptop)
        {
            //lấy ra đối tượng để chỉnh sửa theo mã
            LoaiLaptop loailaptop = db.LoaiLaptop.SingleOrDefault(n => n.MaLoaiLaptop == MaLoaiLaptop);
            if (MaLoaiLaptop == null)
            {
                Response.StatusCode = 404;
                return null;
            }


            return View(loailaptop);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult Xacnhanxoa(int MaLoaiLaptop)
        {

            //lấy ra đối tượng để chỉnh sửa theo mã
            LoaiLaptop loailaptop = db.LoaiLaptop.SingleOrDefault(n => n.MaLoaiLaptop == MaLoaiLaptop);
            if (MaLoaiLaptop == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.LoaiLaptop.Remove(loailaptop);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}