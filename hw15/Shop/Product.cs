namespace Shop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int ProductId { get; set; }
        
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
