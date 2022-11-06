using Microsoft.EntityFrameworkCore;
using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Domain.Event;
using System.Product.Domain.Models.category;
using System.Product.Domain.Models.kardex;
using System.Product.Domain.Models.products;
using System.Product.Infrastructure.EF.Config.WriteConfig;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Infrastructure.EF.Context
{
    public class WriteDbContext : DbContext
    {

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Kardex> Kardex { get; set; }
        public virtual DbSet<Products> Product { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var categoryWriteConfig = new CategoryWriteConfig();
            var kardexWriteConfig = new KardexWriteConfig();
            var productWriteConfig = new ProductWriteConfig();


            modelBuilder.ApplyConfiguration<Category>(categoryWriteConfig);
            modelBuilder.ApplyConfiguration<Kardex>(kardexWriteConfig);
            modelBuilder.ApplyConfiguration<Products>(productWriteConfig);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<StockProductUpdated>();


        }
    }
}