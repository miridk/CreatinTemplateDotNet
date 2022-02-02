using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnikWebApiTemplate.Infrastructure.Models;

namespace UnikWebApiTemplate.Infrastructure.Configuration
{
    public class TestEfConfiguration : IEntityTypeConfiguration<TestEf>
    {
        public void Configure(EntityTypeBuilder<TestEf> builder)
        {
            builder.ToTable(nameof(TestEf))
              .HasKey(t => t.Id);
            builder.Property(t => t.Name)
                .HasMaxLength(100);
        }
    }
}

