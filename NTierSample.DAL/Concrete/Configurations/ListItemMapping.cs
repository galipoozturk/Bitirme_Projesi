using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierSample.Model.Entities;

namespace NTierSample.DAL.Concrete.Configurations
{
    internal class ListItemMapping : IEntityTypeConfiguration<ListItem>
    {
        public void Configure(EntityTypeBuilder<ListItem> builder)
        {
            builder.ToTable("ListItem");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.Description).IsRequired(false);

            builder.HasData(new ListItem
            {
                ID = 1,
                ProductId=1,
                ShoppingListId=1,
                IsActive = true
            });

            builder.HasData(new ListItem
            {
                ID = 2,
                ProductId = 2,
                ShoppingListId = 1,
                IsActive = true
            });
        }
    }
}
