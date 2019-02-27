using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sheekr.Domain.Entities.Enum;
using Sheekr.Domain.Entities;

namespace Sheekr.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("UsuarioId");

            builder.Property(u => u.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.UserName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(u => u.Role)
                .HasConversion(new EnumToNumberConverter<Role, int>())
                .IsRequired();

            builder.Property(u => u.HashedPassword)
                .IsRequired();

            builder.Property(u => u.Salt)
                .IsRequired();
        }
    }
}
