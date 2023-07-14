using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NQT_BookStore.Models;

namespace NQT_BookStore.Configuration
{
    public class TypesConfiguration : IEntityTypeConfiguration<Types>

    {
        public void Configure(EntityTypeBuilder<Types> builder)
        {
            builder.ToTable("Type");
            builder.HasKey(x => x.ID);
            builder.Property(c => c.Name).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.Status).HasColumnType("int");
        }
    }
}
