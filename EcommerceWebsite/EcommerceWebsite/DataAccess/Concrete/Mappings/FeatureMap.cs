using EcommerceWebsite.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceWebsite.DataAccess.Concrete.Mappings
{
    public class FeatureMap : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.ToTable(@"Features");
            builder.HasKey(x => x.Id);
        }
    }
}
