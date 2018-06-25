namespace WebLaptop3.Models.Data_minh
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
            HoaDon = new HashSet<HoaDon>();
        }

        [Key]
        [Display(Name = "Mã khách hàng ")]
        public int MaKhachHang { get; set; }

        [Display(Name = "Tên khách hàng ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        [StringLength(50)]
        public string TenKhachHang { get; set; }

        [Display(Name = "Tuổi ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        public int? Tuoi { get; set; }

        [Display(Name = "Giới tính ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        [StringLength(5)]
        public string GioiTinh { get; set; }

        [Display(Name = "Số điện thoại ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        [StringLength(20)]
        public string SDT { get; set; }

        [Display(Name = "Địa chỉ ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        [StringLength(50)]
        public string DiaChi { get; set; }

        [Display(Name = "Email ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        [StringLength(30)]
        public string Email { get; set; }

        [Display(Name = "Tài khoản ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        [StringLength(30)]
        public string TaiKhoan { get; set; }

        [Display(Name = "Mật khẩu ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        [StringLength(30)]
        public string MatKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
