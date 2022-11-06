using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Product.Domain.ValueObjects;
using System.Product.Domain.Models.products;

namespace System.Product.Infrastructure.EF.Config.WriteConfig
{
    public class ProductWriteConfig : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {

            builder.ToTable("Product");
            builder.HasKey(x => x.Id);



         var objConverterName = new ValueConverter<StringEmptyValue, string>(
         objValue => objValue.Value,
         value => new StringEmptyValue(value)
        );
            builder.Property(x => x.name)
            .HasConversion(objConverterName)
            .HasColumnName("name")
            .HasMaxLength(200);

            builder.Property(x => x.active)
           .HasColumnName("active");



            var precioConverter = new ValueConverter<PrecioValue, decimal>(
           precioValue => precioValue.Value,
           precio => new PrecioValue(precio)
          );
            builder.Property(x => x.price)
               .HasConversion(precioConverter)
              .HasColumnName("price")
              .HasColumnType("decimal")
              .HasPrecision(12, 2);



       var stockConverter = new ValueConverter<CantidadValue, int>(
       cantidadValue => cantidadValue.Value,
       cantidad => new CantidadValue(cantidad)
      );
            builder.Property(x => x.stock)
            .HasConversion(stockConverter)
            .HasColumnName("stock");

            builder.Property(x => x.userId)
           .HasColumnName("userId");



            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            //builder.Ignore(x => x._DetalleProductStock);
        }
    }
}


