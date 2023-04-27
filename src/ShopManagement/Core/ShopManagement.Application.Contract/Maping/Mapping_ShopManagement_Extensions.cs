using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Application.Contract.ProductApplication;
using ShopManagement.Application.Contract.ProductCategoryApplication;
using ShopManagement.Domain.ProductAggregate.ProductModel;
using Base.Shared;

namespace ShopManagement.Application.Contract.Maping
{
    public static class Mapping_ShopManagement_Extensions
    {
        public static ProductCategoryEntity MapToProductCategory(this CreateProductCategory entity)
        {
            return new ProductCategoryEntity(entity.Name, entity.Description,
                entity.ImageSrc,
                entity.ImageAlt, entity.ImageTitle, entity.Keywords,
                entity.MetaDescription, entity.Slug.Slugify());
        }
        public static ProductCategoryEntity MapToProductCategory(this UpdateProductCategory entity , ProductCategoryEntity productCategoryEntity)
        {
            productCategoryEntity.Edit(entity.Name, entity.Description,
                entity.ImageSrc,
                entity.ImageAlt, entity.ImageTitle, entity.Keywords,
                entity.MetaDescription, entity.Slug.Slugify());
            return productCategoryEntity;
        }
        public static ProductEntity MapToProductCategory(this CreateProductCmd entity)
        {
            return new ProductEntity(entity.Name, entity.Slug.Slugify(), entity.Keywords, entity.ImageSrc, entity.ImageAlt, entity.ImageTitle
                , entity.Description, entity.MetaDescription, entity.ShortDescription, entity.CategoryId, entity.UnitPrice);
        }
        public static ProductEntity MapToProduct(this ProductEntity entity, ProductEntity productCategoryEntity)
        {
            productCategoryEntity.Edit(entity.Name,entity.Slug.Slugify(),entity.Keywords,entity.ImageSrc,entity.ImageAlt,entity.ImageTitle
            ,entity.Description ,entity.MetaDescription ,entity.ShortDescription,entity.CategoryId,entity.UnitPrice);
            return productCategoryEntity;
        }
    }
}
