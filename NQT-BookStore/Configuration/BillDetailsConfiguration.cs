using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NQT_BookStore.Models;

namespace NQT_BookStore.Configuration
{
    public class BillDetailsConfiguration : IEntityTypeConfiguration<BillDetails>
    {
        public void Configure(EntityTypeBuilder<BillDetails> builder)
        {
            builder.ToTable("BillDetails");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired(true);
            builder.Property(x => x.Price).HasColumnType("Decimal").IsRequired(true);
            builder.Property(x => x.Status).HasColumnType("int");


            builder.HasOne(x => x.Bill).WithMany(y => y.BillDetails).
            HasForeignKey(c => c.BillID);

            builder.HasOne(x => x.Product).WithMany(y => y.BillDetails).
            HasForeignKey(c => c.ProductId);
        }
    }
}
