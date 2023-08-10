using NTierSample.Core.Entity;

namespace NTierSample.Model.Entities
{
    public class ListItem : BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public int ShoppingListId { get; set; }
        public string Description { get; set; }

    }
}
