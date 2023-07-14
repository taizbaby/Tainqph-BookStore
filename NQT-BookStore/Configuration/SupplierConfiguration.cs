using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NQT_BookStore.Models;

namespace NQT_BookStore.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>

    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier");
            builder.HasKey(x => x.ID);
            builder.Property(c => c.Name).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.Status).HasColumnType("int");
        }
    }
}
