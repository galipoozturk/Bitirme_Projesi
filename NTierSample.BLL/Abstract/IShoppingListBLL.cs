using NTierSample.Model.Entities;
using System.Collections.ObjectModel;

namespace NTierSample.BLL.Abstract
{
    public interface IShoppingListBLL : IBaseBLL<ShoppingList>
    {
        void DeleteByID(int entityID, int userId);
        ShoppingList Get(int entityID, int userId);
        void ChangeName(int entityID,string name);
        ICollection<ShoppingList> GetAllByUserId(int userId);

    }
}
