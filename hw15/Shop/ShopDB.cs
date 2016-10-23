namespace Shop
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopDB : DbContext
    {
        public ShopDB()
            : base("name=ConnectionStringShopDB")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
    }
}
