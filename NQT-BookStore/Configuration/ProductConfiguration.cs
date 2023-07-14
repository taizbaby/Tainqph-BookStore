using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NQT_BookStore.Models;

namespace NQT_BookStore.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>

    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ProductCode).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Describe).HasColumnType("nvarchar(1000)").IsRequired(false);
            builder.Property(x => x.Name).HasColumnType("nvarchar(1000)");
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired();
            builder.Property(x => x.Price).HasColumnType("Decimal").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int");




            builder.HasOne(x => x.Types).WithMany(y => y.Product).
            HasForeignKey(c => c.TypeID);


            builder.HasOne(x => x.Producer).WithMany(y => y.Product).
            HasForeignKey(c => c.ProducerID);

            builder.HasOne(x => x.Supplier).WithMany(y => y.Product).
            HasForeignKey(c => c.SupplierID);

            builder.HasOne(x => x.Category).WithMany(y => y.Product).
            HasForeignKey(c => c.CategoryID);

        }
    }
}
