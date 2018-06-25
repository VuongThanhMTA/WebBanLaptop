namespace WebLaptop3.Models.Data_minh
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            Laptop = new HashSet<Laptop>();
        }

        [Key]
        [Display(Name = "Mã nhà cung cấp ")]
        public int MaNhaCungCap { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên nhà cung cấp ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        public string TenNhaCungCap { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ ")]
        [Required(ErrorMessage = "{0}  không được trống")]     
        public string DiaChi { get; set; }

        [StringLength(20)]
        [Display(Name = "Số điện thoại ")]
        [Required(ErrorMessage = "{0}  không được trống")]
    
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Laptop> Laptop { get; set; }
    }
}
