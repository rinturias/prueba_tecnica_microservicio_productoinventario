using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Infrastructure.EF.ReadModel;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Infrastructure.EF.Config.ReadConfig
{
    class ProductReadConfig : IEntityTypeConfiguration<ProductReadModel>
    {
        public void Configure(EntityTypeBuilder<ProductReadModel> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.name)
            .HasColumnName("name")
            .HasMaxLength(200);

            builder.Property(x => x.active)
           .HasColumnName("active");

            builder.Property(x => x.price)
              .HasColumnName("price")
              .HasColumnType("decimal")
              .HasPrecision(12, 2);


            builder.Property(x => x.stock)
            .HasColumnName("stock");

            builder.Property(x => x.userId)
           .HasColumnName("userId");

            builder.Property(x => x.categoryId)
          .HasColumnName("categoryId");

            builder.Ignore("_domainEvents");
            //builder.HasMany(x => x.category);

        }

   
    }
}
