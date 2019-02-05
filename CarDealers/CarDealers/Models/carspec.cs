namespace CarDealers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("carspec")]
    public partial class carspec
    {
        [Key]
        public int vpnid { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(8000)]
        public string Description { get; set; }

        public decimal milage { get; set; }

        [StringLength(255)]
        public string model { get; set; }

        public int carno { get; set; }

        public virtual car car { get; set; }
    }
}
