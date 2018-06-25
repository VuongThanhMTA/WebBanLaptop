using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLaptop3.Models.Data
{
    public class GioHang
    {
        QuanLyLaptopNewModel db = new QuanLyLaptopNewModel(); 
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
            Laptop laptop = db.Laptops.Single(n => n.MaLaptop == iMaLaptop);
            sTenLaptop = laptop.TenLaptop;
            sAnhBia = laptop.Anh;
            dDonGia = double.Parse(laptop.Gia.ToString());
            iSoLuong = 1;
        }

       
    }
}