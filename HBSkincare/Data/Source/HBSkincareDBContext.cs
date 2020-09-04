using System;
using HBSkincare.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HBSkincare.Data.Source
{
    public partial class HBSkincareDBContext : DbContext
    {
        public DbSet<Currency> Currency { get; set; }
        public DbSet<RawMaterialItem> RawMaterialItem { get; set; }
        public DbSet<RawMaterialPurchase> RawMaterialPurchase { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0EU3GVK;Initial Catalog=HBSkincareData;Trusted_Connection=True;");
        }


    }
}
