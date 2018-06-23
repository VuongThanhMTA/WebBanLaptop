namespace WebLaptop3.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string MaHoaDon { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string MaLaptop { get; set; }

        public int? SoLuong { get; set; }

        public int? DonGia { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual Laptop Laptop { get; set; }
    }
}
