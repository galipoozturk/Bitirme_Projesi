using NTierSample.Model.Entities;

namespace NTierSample.Model.Dto
{
    public class ShoppingListProductDTO
    {
        public ShoppingList shoppingList { get; set; }
        public List<ListItem> listItems { get; set; }
    }
}
