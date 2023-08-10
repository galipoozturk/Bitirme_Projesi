using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierSample.Model.Entities;
using NTierSample.Model.Enums;

namespace NTierSample.DAL.Concrete.Configurations
{
    internal class ShoppingListMapping : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.ToTable("ShoppingList");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.UserId).IsRequired();

            builder.HasData(new ShoppingList
            {
                ID = 1,
                Name = "Martys List",
                UserId = 1,
                Status = ListStatus.InProgress,
                IsActive = true
            });
        }
    }
}
