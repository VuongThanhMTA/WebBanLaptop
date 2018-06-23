namespace WebLaptop3.Models.Data
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
            Laptops = new HashSet<Laptop>();
        }

        [Key]
        [StringLength(15)]
        public string MaNhaCungCap { get; set; }

        [StringLength(50)]
        public string TenNhaCungCap { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Laptop> Laptops { get; set; }
    }
}
