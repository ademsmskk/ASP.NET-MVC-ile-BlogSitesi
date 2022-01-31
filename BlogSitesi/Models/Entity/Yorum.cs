namespace BlogSitesi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yorum")]
    public partial class Yorum
    {
        public int YorumId { get; set; }

        [Column("Yorum")]
        [Required]
        [StringLength(2000)]
        public string Yorum1 { get; set; }

        public int MakaleID { get; set; }

        public DateTime EklenmeTarihi { get; set; }

        [Required]
        [StringLength(150)]
        public string AdSoyad { get; set; }

        public int? Begeni { get; set; }

        public virtual Makale Makale { get; set; }
    }
}
