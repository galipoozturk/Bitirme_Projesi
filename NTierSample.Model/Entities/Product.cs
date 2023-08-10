using NTierSample.Core.Entity;
using NTierSample.Model.Enums;

namespace NTierSample.Model.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            IsActive = false;
        }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
