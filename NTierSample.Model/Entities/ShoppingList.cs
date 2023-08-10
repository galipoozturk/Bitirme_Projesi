using NTierSample.Core.Entity;
using NTierSample.Model.Enums;

namespace NTierSample.Model.Entities
{
    public class ShoppingList : BaseEntity
    {
        public ShoppingList()
        {
            IsActive = true;
            Status = ListStatus.InProgress;
        }
        public string Name { get; set; }
        public ListStatus Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<ListItem> Items { get; set; }
    }
}
