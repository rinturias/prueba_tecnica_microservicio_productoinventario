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
   public class CategoryReadConfig : IEntityTypeConfiguration<CategoryReadModel>
    {
        public void Configure(EntityTypeBuilder<CategoryReadModel> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.name)
            .HasColumnName("name")
            .HasMaxLength(200);

            builder.Property(x => x.active)
           .HasColumnName("active");

            builder.Ignore("_domainEvents");
        }

    }
}
