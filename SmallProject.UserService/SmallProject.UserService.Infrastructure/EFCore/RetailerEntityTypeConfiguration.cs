using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallProject.UserService.Domain.Aggregates.Retailer;

namespace SmallProject.UserService.Infrastructure.EFCore
{
    public class RetailerEntityTypeConfiguration : IEntityTypeConfiguration<Retailer>
    {
        public void Configure(EntityTypeBuilder<Retailer> builder)
        {
            builder.HasKey("Id");
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder.OwnsOne<Address>(x => x.Address, a =>
            {
                a.Property(item => item.HouseNum).HasColumnName("HouseNum");
                a.Property(item => item.Ward).HasColumnName("Ward");
                a.Property(item => item.Street).HasColumnName("Street");
                a.Property(item => item.District).HasColumnName("District");
            });
            builder.OwnsOne<Name>(x => x.Name, a =>
            {
                a.Property(item => item.FirstName).HasColumnName("FirstName");
                a.Property(item => item.LastName).HasColumnName("LastName");
            });
        }
    }
}
