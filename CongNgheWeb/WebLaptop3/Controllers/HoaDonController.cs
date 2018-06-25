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
    public class HoaDonController : Controller
    {
        Quanlylaptop_minh db = new Quanlylaptop_minh();
        // GET: HoaDon
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.HoaDon.ToList().OrderBy(n => n.MaHoaDon).ToPagedList(pageNumber, pageSize));
         
        }
        [HttpGet]
        public ActionResult ChinhSua(int MaHoaDon)
        {
            //lấy ra đối tượng để chỉnh sửa theo mã
            HoaDon hoadon = db.HoaDon.SingleOrDefault(n => n.MaHoaDon == MaHoaDon);
            if (MaHoaDon == null)
            {
                Response.StatusCode = 404;
                return null;
            }
           

            return View(hoadon);
        }

        [HttpPost]

        public ActionResult ChinhSua(HoaDon hoadon)
        {
            db.Entry(hoadon).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            Response.Write("<script language='JavaScript'> alert('Đã chỉnh sửa thành công !!'); </script>");

            return View();
        }

        //xóa sản phẩm
        [HttpGet]
        public ActionResult Xoa(int MaHoaDon)
        {
            //lấy ra đối tượng để chỉnh sửa theo mã
            HoaDon hoadon = db.HoaDon.SingleOrDefault(n => n.MaHoaDon == MaHoaDon);
            if (MaHoaDon == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(hoadon);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult Xacnhanxoa(int MaHoaDon)
        {  //lấy ra đối tượng để chỉnh sửa theo mã
            HoaDon hoadon = db.HoaDon.SingleOrDefault(n => n.MaHoaDon == MaHoaDon);
            if (MaHoaDon == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.HoaDon.Remove(hoadon);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}