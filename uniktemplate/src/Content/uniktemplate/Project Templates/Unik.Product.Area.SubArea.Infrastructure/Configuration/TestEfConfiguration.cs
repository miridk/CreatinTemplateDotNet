namespace $safeprojectname$.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using $safeprojectname$.Models;

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

