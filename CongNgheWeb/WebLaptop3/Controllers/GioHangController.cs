using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop3.Models.Data_minh;
//using WebLaptop3.Models.NewData;

namespace WebLaptop3.Controllers
{
    public class GioHangController : Controller
    {
        Quanlylaptop_minh db = new Quanlylaptop_minh();

        //Lấy giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            // nếu session GioHang chưa tồn tại thì tạo list giỏ hàng và sessionGioHang
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        // Xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {

            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<GioHang> lstGioHang = LayGioHang();
            // ViewBag
            return View(lstGioHang);
        }
        #region Thêm sửa xóa giỏ hàng
        //Thêm giỏ hàng
        // strUrl. đường dẫn 
        public ActionResult ThemGioHang(int maLaptop, String strUrl)
        {
            // kiểm tra xem trong csdl có tồn tại sản phẩm muốn thêm hay k
            Laptop laptop = db.Laptop.SingleOrDefault(n => n.MaLaptop == maLaptop);
            if (laptop == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<GioHang> lstGioHang = LayGioHang();
            //kiểm tra laptop  đã tồn tại trong session[gio hang] chua 
            GioHang sanPham = lstGioHang.Find(n => n.iMaLaptop == maLaptop);
            if (sanPham == null)
            {
                // nếu chưa thì tạo và thêm vào giỏ
                sanPham = new GioHang(maLaptop);
                //add san pham mới thêm vào list
                lstGioHang.Add(sanPham);
                return Redirect(strUrl);
            }
            else
            {
                // đã có thì tăng số lượng
                sanPham.iSoLuong++;
                return Redirect(strUrl); // F5 lại trang
            }
        }
        //Cap nhật giỏ hàng

        public ActionResult CapNhatGioHang(int maSP, FormCollection f)
        {

            //kiểm tra malaptop
            Laptop lapTop = db.Laptop.SingleOrDefault(n => n.MaLaptop == maSP);
            if (lapTop == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy giỏ hang từ sesion
            List<GioHang> lstGH = LayGioHang();
            // kiểm tra sp có tồn tại k
            GioHang sanPham = lstGH.SingleOrDefault(n => n.iMaLaptop == maSP);

            if (sanPham != null)
            {
                // nếu có sản phầm thì cập nhật số lượng
                sanPham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");
        }

        //xóa giỏ hàng
        public ActionResult XoaGioHang(int maSP)
        {
            //kiểm tra malaptop
            Laptop lapTop = db.Laptop.SingleOrDefault(n => n.MaLaptop == maSP);
            if (lapTop == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy giỏ hang từ sesion
            List<GioHang> lstGH = LayGioHang();
            // kiểm tra sp có tồn tại k
            GioHang sanPham = lstGH.SingleOrDefault(n => n.iMaLaptop == maSP);

            if (sanPham != null)
            {
                lstGH.RemoveAll(n => n.iMaLaptop == maSP);

            }
            //nếu xóa hết thì quay về trang chủ
            if (lstGH.Count == 0)
            {
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("GioHang");

        }


        // tính tổng số lượng và tổng tiền
        // tính tổng sô lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        // tính tổng thành tiền
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }

            return dTongTien;
        }
        // partial gio hang
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();

            return PartialView();
        }

        // xây dựng vew cho phép người dùng sửa giỏ hàng
        public ActionResult NguoiDungSuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<GioHang> lstGioHang = LayGioHang();
            // ViewBag
            return View(lstGioHang);
        }
        #endregion

        #region Đặt hàng
        // Đặt hàng

        public ActionResult DatHang()
        {
            //Kiểm tra đăng đăng nhập
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "DangKyDangNhap");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            //Thêm đơn hàng
            HoaDon ddh = new HoaDon();
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();

            ddh.MaKhachHang = kh.MaKhachHang;
            ddh.NgayDatHang = DateTime.Now;
            ddh.NgayGiaoHang = DateTime.Now;
            ddh.TinhTrang = "Tốt";
            ddh.DaThanhToan = 0;
            db.HoaDon.Add(ddh);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in gh)
            {
                ChiTietHoaDon ctDH = new ChiTietHoaDon();
                ctDH.MaHoaDon = ddh.MaHoaDon;
                ctDH.MaLaptop = item.iMaLaptop;
                ctDH.SoLuong = item.iSoLuong;
                ctDH.DonGia = (int)item.dDonGia;
                db.ChiTietHoaDon.Add(ctDH);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}