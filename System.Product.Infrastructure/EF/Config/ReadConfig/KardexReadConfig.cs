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
    class KardexReadConfig : IEntityTypeConfiguration<KardexReadModel>
    {
        public void Configure(EntityTypeBuilder<KardexReadModel> builder)
        {
            builder.ToTable("Kardex");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.description)
            .HasColumnName("description")
            .HasMaxLength(200);

            builder.Property(x => x.active)
           .HasColumnName("active");

         builder.Property(x => x.codeOperation)
        .HasColumnName("codeOperation")
        .HasMaxLength(50);


            builder.Property(x => x.quantityInput)
         .HasColumnName("quantityInput");

            builder.Property(x => x.quantityOut)
         .HasColumnName("quantityOut");

            builder.Property(x => x.priceUnit)
              .HasColumnName("priceUnit")
              .HasColumnType("decimal")
              .HasPrecision(12, 2);

               builder.Property(x => x.date)
                      .HasColumnName("date")
                      .HasColumnType("DateTime");

            builder.Property(x => x.userId)
           .HasColumnName("userId");

            builder.Ignore("_domainEvents");
            //builder.HasMany(x => x.product);

        }


    }
}