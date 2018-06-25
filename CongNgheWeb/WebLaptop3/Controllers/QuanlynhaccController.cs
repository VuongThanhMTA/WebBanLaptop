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
    public class QuanlynhaccController : Controller
    {
        Quanlylaptop_minh db = new Quanlylaptop_minh();
        // GET: Quanlynhacc
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.NhaCungCap.ToList().OrderBy(n => n.TenNhaCungCap).ToPagedList(pageNumber, pageSize));
            return View();
        }

        //Thêm Mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            
            return View();
        }

        [HttpPost]

        public ActionResult ThemMoi(NhaCungCap nhacungcap)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.SelectMany(m => m.Value.Errors).Select(e => e.ErrorMessage).ToList();

                // todo with errors

                return View(nhacungcap);
            }
                //thêm vào cơ sở dữ liệu
                db.NhaCungCap.Add(nhacungcap);
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult ChinhSua(int MaNhaCungCap)
        {
            //lấy ra đối tượng để chỉnh sửa theo mã
            NhaCungCap nhacungcap = db.NhaCungCap.SingleOrDefault(n => n.MaNhaCungCap == MaNhaCungCap);
            if (MaNhaCungCap == null)
            {
                Response.StatusCode = 404;
                return null;
            }
           
            return View(nhacungcap);
        }

        [HttpPost]

        public ActionResult ChinhSua(NhaCungCap nhacungcap)
        {
            db.Entry(nhacungcap).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return View();
        }

        //xóa nhà cung cấp
        [HttpGet]
        public ActionResult Xoa(int MaNhaCungCap)
        {
            //lấy ra đối tượng để chỉnh sửa theo mã
            NhaCungCap nhacungcap = db.NhaCungCap.SingleOrDefault(n => n.MaNhaCungCap == MaNhaCungCap);
            if (MaNhaCungCap == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(nhacungcap);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult Xacnhanxoa(int MaNhaCungCap)
        {
            //lấy ra đối tượng để chỉnh sửa theo mã
            NhaCungCap nhacungcap = db.NhaCungCap.SingleOrDefault(n => n.MaNhaCungCap == MaNhaCungCap);
            if (MaNhaCungCap == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NhaCungCap.Remove(nhacungcap);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}