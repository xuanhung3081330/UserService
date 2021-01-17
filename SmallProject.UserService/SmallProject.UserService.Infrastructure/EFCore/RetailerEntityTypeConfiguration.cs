using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallProject.UserService.Infrastructure.DTOs.Retailer;

namespace SmallProject.UserService.Infrastructure.EFCore
{
    public class RetailerEntityTypeConfiguration : IEntityTypeConfiguration<Retailer>
    {
        public void Configure(EntityTypeBuilder<Retailer> builder)
        {
            builder.HasKey("Id");
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
