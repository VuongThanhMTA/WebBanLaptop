using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLaptop3.Models.Data_minh
{
    public class GioHang
    {
        Quanlylaptop_minh db = new Quanlylaptop_minh(); 
        public int iMaLaptop { get; set; }
        public string sTenLaptop { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //Hàm tạo cho giỏ hàng
        public GioHang(int MaLaptop)
        {
            iMaLaptop = MaLaptop;
            Laptop laptop = db.Laptop.Single(n => n.MaLaptop == iMaLaptop);
            sTenLaptop = laptop.TenLaptop;
            sAnhBia = laptop.Anh;
            dDonGia = double.Parse(laptop.Gia.ToString());
            iSoLuong = 1;
        }

       
    }
}