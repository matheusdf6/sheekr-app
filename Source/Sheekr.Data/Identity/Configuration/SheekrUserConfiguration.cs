using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sheekr.Data
{
    public class SheekrUserConfiguration : IEntityTypeConfiguration<SheekrUser>
    {
        public void Configure(EntityTypeBuilder<SheekrUser> builder)
        {
            builder.Property(u => u.PrimeiroNome)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.UltimoNome)
                .HasMaxLength(30)
                .IsRequired();

            builder.Ignore(u => u.NomeCompleto);
        }
    }
}

