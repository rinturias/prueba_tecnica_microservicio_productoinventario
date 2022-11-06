using Microsoft.EntityFrameworkCore;
using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Infrastructure.EF.Config.ReadConfig;
using System.Product.Infrastructure.EF.ReadModel;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Infrastructure.EF.Context
{
   public class ReadDbContext : DbContext
    {
        public virtual DbSet<CategoryReadModel> Category { get; set; }
        public virtual DbSet<KardexReadModel> Kardex { get; set; }
        public virtual DbSet<ProductReadModel> Product { get; set; }
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var categoryConfig = new CategoryReadConfig();
            var kardexConfig = new KardexReadConfig();
            var productConfig = new ProductReadConfig();

            modelBuilder.ApplyConfiguration<CategoryReadModel>(categoryConfig);
            modelBuilder.ApplyConfiguration<KardexReadModel>(kardexConfig);
            modelBuilder.ApplyConfiguration<ProductReadModel>(productConfig);


            modelBuilder.Ignore<DomainEvent>();
            //modelBuilder.Ignore<SaleMade>();
            //modelBuilder.Ignore<SaleDelivered>();
        }
    }
}