using EcommerceWebsite.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceWebsite.DataAccess.Concrete.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(@"Products");
            builder.HasKey(x => x.Id);
        }
    }
    public class ProductImageMap : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable(@"ProductImages");
            builder.HasKey(x => x.Id);
        }
    }
}
