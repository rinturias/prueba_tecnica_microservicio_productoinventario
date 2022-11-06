using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Product.Domain.Models.kardex;
using System.Product.Domain.ValueObjects;

namespace System.Product.Infrastructure.EF.Config.WriteConfig
{
    public class KardexWriteConfig : IEntityTypeConfiguration<Kardex>
    {
        public void Configure(EntityTypeBuilder<Kardex> builder)
        {
            builder.ToTable("Kardex");
            builder.HasKey(x => x.Id);

            var objConverterDescription = new ValueConverter<StringEmptyValue, string>(
              objValue => objValue.Value,
              value => new StringEmptyValue(value)
             );
            builder.Property(x => x.description)
            .HasConversion(objConverterDescription)
            .HasColumnName("description")
            .HasMaxLength(200);

            builder.Property(x => x.active)
           .HasColumnName("active");

            builder.Property(x => x.codeOperation)
           .HasColumnName("codeOperation")
           .HasMaxLength(50);

            var quantityInputConverter = new ValueConverter<CantidadValueConCero, int>(
             cantidadValue => cantidadValue.Value,
             cantidad => new CantidadValueConCero(cantidad)
            );

            builder.Property(x => x.quantityInput)
           .HasConversion(quantityInputConverter)
         .HasColumnName("quantityInput");

            var quantityOutputConverter = new ValueConverter<CantidadValueConCero, int>(
             cantidadValue => cantidadValue.Value,
             cantidad => new CantidadValueConCero(cantidad)
            );
            builder.Property(x => x.quantityOut)
          .HasConversion(quantityOutputConverter)
         .HasColumnName("quantityOut");

            var precioConverter = new ValueConverter<PrecioValue, decimal>(
             precioValue => precioValue.Value,
             precio => new PrecioValue(precio)
            );
            builder.Property(x => x.priceUnit)
              .HasColumnName("priceUnit")
              .HasConversion(precioConverter)
              .HasColumnType("decimal")
              .HasPrecision(12, 2);

            builder.Property(x => x.date)
                   .HasColumnName("date")
                   .HasColumnType("DateTime");

            builder.Property(x => x.userId)
           .HasColumnName("userId");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.KardeDetatail);
        }
    }
}