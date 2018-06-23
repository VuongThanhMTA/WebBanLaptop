﻿namespace WebLaptop3.Models.NewData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int MaKhachHang { get; set; }


        
        [StringLength(50)]
        [Display(Name = "Họ Tên")]
        [Required(ErrorMessage ="{0} Không không được trống")]

        public string TenKhachHang { get; set; }

        [Display(Name = "Tuổi")]
        [Required(ErrorMessage = "{0} Không được trống")]
        public int? Tuoi { get; set; }

        [StringLength(5)]
        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "{0} Không được trống")]
        public string GioiTinh { get; set; }

        [StringLength(20)]
        [Display(Name = "SDT")]
        [Required(ErrorMessage = "{0}  không được trống")]
        public string SDT { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "{0}   không được trống")]
        public string DiaChi { get; set; }

        [StringLength(30)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0}  không được trống")]
        public string Email { get; set; }

        [StringLength(30)]
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "{0}  không được trống")]
        public string TaiKhoan { get; set; }

        [StringLength(30)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0}  không được trống")]
        public string MatKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
