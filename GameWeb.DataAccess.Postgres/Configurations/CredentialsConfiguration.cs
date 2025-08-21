using GameWeb.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameWeb.Persistence.Configurations;

public class CredentialsConfiguration : IEntityTypeConfiguration<CredentialsEntity>
{
    public void Configure(EntityTypeBuilder<CredentialsEntity> builder)
    {
        builder.HasKey(c => c.UserId);
        builder.HasOne(c => c.User) 
            .WithOne(u => u.Credentials);
    }
}