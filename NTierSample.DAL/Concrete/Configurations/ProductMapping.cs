using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierSample.Model.Entities;

namespace NTierSample.DAL.Concrete.Configurations
{
    internal class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.Image).IsRequired();
            builder.Property(a => a.Name).IsRequired();

            builder.HasData(new Product
            {
                ID = 1,
                Name = "Apple",
                Image = "https://static.vecteezy.com/system/resources/previews/008/848/360/original/fresh-apple-fruit-free-png.png",
                IsActive = true
            });

            builder.HasData(new Product
            {
                ID = 2,
                Name = "Samsung",
                Image = "https://static.vecteezy.com/system/resources/previews/008/848/360/original/fresh-apple-fruit-free-png.png",
                IsActive = true
            });
        }
    }
}
