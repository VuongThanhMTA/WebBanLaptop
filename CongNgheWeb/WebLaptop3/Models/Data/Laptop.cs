namespace WebLaptop3.Models.Data
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
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        [StringLength(15)]
        public string MaLaptop { get; set; }

        [StringLength(50)]
        public string TenLaptop { get; set; }

        [StringLength(15)]
        public string MaLoaiLaptop { get; set; }

        public int? Gia { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(50)]
        public string Anh { get; set; }

        [StringLength(15)]
        public string MaNhaCungCap { get; set; }

        [StringLength(50)]
        public string Mota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual LoaiLaptop LoaiLaptop { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}