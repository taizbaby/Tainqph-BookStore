using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NQT_BookStore.Models;

namespace NQT_BookStore.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>

    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Describe).HasColumnType("nvarchar(1000)").IsRequired(false);

            builder.HasOne(x => x.User).WithOne(y => y.Cart).HasForeignKey<Cart>(x => x.ID);
        }
    }
}
