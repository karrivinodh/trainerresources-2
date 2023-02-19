using EcommerceWebsite.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceWebsite.DataAccess.Concrete.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(@"Categories");
    
            builder.HasKey(x => x.Id);
        }
    }
}
