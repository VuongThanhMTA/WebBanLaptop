using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.NewData;

namespace WebLaptop3.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyLaptopModel1 db = new QuanLyLaptopModel1();

        //Lấy giỏ hàng
        public List<GioHang> LayGioHang() {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            // nếu giở hang chưa tồn tại thì tạo list giỏ hàng và sessionGioHang
            if (lstGioHang == null) {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(string maLaptop, String strUrl)
        {
            Laptop laptop = db.Laptops.SingleOrDefault(n => n.MaLaptop == maLaptop);
            if (laptop==null) {
                Response.StatusCode = 404;
                return null;
            }

            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanPham = lstGioHang.Find(n=>n.iMaLaptop==maLaptop); //kiểm tra laptop  đã tồn tại trong session[gio hang] chua 
            if (sanPham == null) {
                sanPham = new GioHang(maLaptop);
                return Redirect(strUrl);
            }
            else
            {
                sanPham.iSoLuong++;
                return Redirect(strUrl);
            }
        }
        //Cap nhật giỏ hàng

        public ActionResult CapNhatGioHang(String maSP, FormCollection f) {

            //kiểm tra máp
            Laptop lapTop = db.Laptops.SingleOrDefault(n => n.MaLaptop == maSP);
            if (lapTop == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy giỏ hang từ sesion
            List<GioHang> lstGH = LayGioHang();
            GioHang sanPham = lstGH.SingleOrDefault(n => n.iMaLaptop == maSP);

            if (sanPham!=null) {
                sanPham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return View("GioHang");
        }


    }
}