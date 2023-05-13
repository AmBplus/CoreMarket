using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;

namespace ShopManagement.Persistence.Configuration;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategoryEntity>
{
    public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.Slug).IsUnique();
        builder.Property(x => x.Slug).IsRequired().HasMaxLength(300);
        builder.Property(x => x.MetaDescription).HasMaxLength(150);
        builder.Property(x => x.Keywords).HasMaxLength(80);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.ImageSrc).HasMaxLength(1000);
        builder.Property(x => x.ImageAlt).HasMaxLength(250);
        builder.Property(x => x.ImageTitle).HasMaxLength(500);
    }
}

