using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScaleArch.ProfileServiceApi.Models;

namespace ScaleArch.ProfileServiceApi.Data.Config;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.RowVersion)
            .IsConcurrencyToken();

        builder.HasMany(t => t.Permissions)
            .WithMany(p => p.Users)
            .UsingEntity("UserPermissions");
    }
}
