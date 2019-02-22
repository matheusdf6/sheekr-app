using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sheekr.Data
{
    public class SheekrIdentityDbContext : IdentityDbContext<SheekrUser>
    {
        public SheekrIdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SheekrUserConfiguration());
            base.OnModelCreating(builder);
        }
    }
}

