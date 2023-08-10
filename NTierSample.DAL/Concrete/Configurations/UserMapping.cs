using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierSample.Model.Entities;
using NTierSample.Model.Enums;

namespace NTierSample.DAL.Concrete.Configurations
{
    internal class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.Email).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(20).IsRequired();
            builder.Property(a => a.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(100).IsRequired();
            builder.HasIndex(a => a.Email).IsUnique();

            builder.HasData(new User
            {
                ID = 1,
                FirstName = "Marty",
                LastName = "McFly",
                Email = "akb@mail.com",
                Password = "123",
                Role = UserRole.Admin,
                IsActive = true
            });
        }
    }
}
