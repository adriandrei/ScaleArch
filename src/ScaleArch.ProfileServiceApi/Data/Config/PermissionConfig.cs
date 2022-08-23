using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScaleArch.ProfileServiceApi.Models;

namespace ScaleArch.ProfileServiceApi.Data.Config;

public class PermissionConfig : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.RowVersion)
            .IsConcurrencyToken();
    }
}
