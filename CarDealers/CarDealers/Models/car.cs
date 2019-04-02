namespace CarDealers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("car")]
    public partial class car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public car()
        {
            carspecs = new HashSet<carspec>();
        }

        [Key]
        public int carno { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? price { get; set; }

        [Required]
        [StringLength(100)]
        public string color { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<carspec> carspecs { get; set; }

        //public static IQueryable<car> AsQueryable()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
