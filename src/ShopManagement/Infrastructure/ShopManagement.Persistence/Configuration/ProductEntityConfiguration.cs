using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;
using ShopManagement.Domain.ProductAggregate.ProductModel;

namespace ShopManagement.Persistence.Configuration;

public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsUnicode().HasMaxLength(255).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.Slug).IsUnique();
        builder.Property(x => x.Code).IsUnicode().HasComputedColumnSql("'p'+[Id]+[slug]");
        builder.Property(x => x.ShortDescription).HasMaxLength(500).IsRequired();
        builder.Property(x => x.ImageSrc).HasMaxLength(1000).IsUnicode();
        builder.Property(x => x.ImageAlt).HasMaxLength(255);
        builder.Property(x => x.ImageTitle).HasMaxLength(500);

        builder.Property(x => x.Keywords).HasMaxLength(100);
        builder.Property(x => x.MetaDescription).HasMaxLength(150);
        builder.Property(x => x.Slug).HasMaxLength(500).IsRequired();

        builder.HasOne(x => x.Category)
            .WithMany(x => x.ProductEntities)
            .HasForeignKey(x => x.CategoryId);

      
    }
}