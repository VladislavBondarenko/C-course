namespace Shop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sale
    {
        [Key]
        public int SaleId { get; set; }

        public string BuyerName { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal Sum { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
