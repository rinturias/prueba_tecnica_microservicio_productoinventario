using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Product.Domain.Models.category;
using System.Text;
using System.Threading.Tasks;

namespace System.Product.Infrastructure.EF.Config.WriteConfig
{
  public  class CategoryWriteConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.Id);


         builder.Property(x => x.name)
        .HasColumnName("name")
         .HasMaxLength(200);

          builder.Property(x => x.active)
          .HasColumnName("activo");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
      

        }
    }
}