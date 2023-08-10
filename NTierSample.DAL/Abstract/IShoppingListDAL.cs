using NTierSample.Core.DataAccess;
using NTierSample.Model.Entities;
using System.Collections.ObjectModel;

namespace NTierSample.DAL.Abstract
{
    public interface IShoppingListDAL : IRepository<ShoppingList>
    {
        ShoppingList GetByIdWithDetail(int id, int userId);
    }
}
