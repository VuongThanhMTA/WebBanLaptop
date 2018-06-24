namespace WebLaptop3.Models.Data_minh
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietHoaDon = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        public int MaHoaDon { get; set; }

        public int? MaKhachHang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDatHang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGiaoHang { get; set; }

        [StringLength(50)]
        public string TinhTrang { get; set; }

        public int? DaThanhToan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
