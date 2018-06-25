namespace WebLaptop3.Models.Data_minh
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
            Laptop = new HashSet<Laptop>();
        }

        [Key]
        [Display(Name = "Mã Loại laptop ")]
        public int MaLoaiLaptop { get; set; }
        [Display(Name = "Tên Loại laptop ")]
        [Required(ErrorMessage = "{0}  không được trống")]
        [StringLength(50)]
        public string TenLoaiLaptop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Laptop> Laptop { get; set; }
    }
}
