namespace WebLaptop3.Models.Data_minh
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Laptop")]
    public partial class Laptop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Laptop()
        {
            ChiTietHoaDon = new HashSet<ChiTietHoaDon>();
        }

        [Key]
      
        public int MaLaptop { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Laptop: ")]
        [Required(ErrorMessage = "{0}  không được trống")]

        public string TenLaptop { get; set; }



        [Display(Name = "Mã loại Laptop: ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        public int? MaLoaiLaptop { get; set; }

 
        [Display(Name = "Giá: ")]
        [Required(ErrorMessage = "{0}  không được trống")]

        public int? Gia { get; set; }

      
        [Display(Name = "Số lượng: ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        public int? SoLuong { get; set; }

        [StringLength(50)]
        [Display(Name = "Ảnh")]
        [Required(ErrorMessage = "{0}  không được trống")]
        public string Anh { get; set; }

        
        [Display(Name = "Mã nhà cung cấp: ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        public int? MaNhaCungCap { get; set; }


        [StringLength(50)]
        [Display(Name = "Mô tả: ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        public string Mota { get; set; }

       
        [Display(Name = "Trạng thái: ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        public int? TrangThai { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }

        public virtual LoaiLaptop LoaiLaptop { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
