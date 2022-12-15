using Everymind.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Everymind.Areas.Identity.Data;

public class EverymindContext : IdentityDbContext<EverymindUser>
{
    public EverymindContext(DbContextOptions<EverymindContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<EverymindUser>
{
    public void Configure(EntityTypeBuilder<EverymindUser> builder)
    {
        builder.Property(u => u.Name).HasMaxLength(255);
    }
}
