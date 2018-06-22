namespace WebLaptop3.Models.NewData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiLaptop")]
    public partial class LoaiLaptop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiLaptop()
        {
            Laptops = new HashSet<Laptop>();
        }

        [Key]
        [StringLength(15)]
        public string MaLoaiLaptop { get; set; }

        [StringLength(50)]
        public string TenLoaiLaptop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Laptop> Laptops { get; set; }
    }
}
