using NTierSample.BLL.Abstract;
using NTierSample.DAL.Abstract;
using NTierSample.Model.Entities;
using NTierSample.Model.Enums;
using System.Collections.ObjectModel;

namespace NTierSample.BLL.Concrete
{
    class ShoppingListService : IShoppingListBLL
    {
        IShoppingListDAL entityDAL;
        public ShoppingListService(IShoppingListDAL dal)
        {
            entityDAL = dal;
        }

        void Check(ShoppingList entity)
        {
          
        }

        #region Base Method
        public void Insert(ShoppingList entity)
        {
            Check(entity);
            entity.Status = ListStatus.InProgress;
            entityDAL.Add(entity);
        }
        public void Update(ShoppingList entity)
        {
            Check(entity);
            entityDAL.Update(entity);
        }
        public void Delete(ShoppingList entity)
        {
            entity.IsActive = false;
            entityDAL.Update(entity);
        }
        public void DeleteByID(int entityID, int userId)
        {
            ShoppingList entity = Get(entityID,userId);
            entity.IsActive = false;
            entityDAL.Update(entity);
        }
        public ShoppingList Get(int entityID, int userId)
        {
            return entityDAL.GetByIdWithDetail(entityID, userId);

        }
        public ICollection<ShoppingList> GetAll()
        {
            return entityDAL.GetAll(a=> a.IsActive);
        }

        public void ChangeName(int entityID,string name)
        {
            ShoppingList shoppingList = entityDAL.Get(a => a.ID == entityID && a.IsActive);
            if(shoppingList == null)
            {
                throw new Exception("Liste bulunamadı!");
            }

            shoppingList.Name = name;
            Update(shoppingList);
        }

        public ICollection<ShoppingList> GetAllByUserId(int userId)
        {
            return entityDAL.GetAll(a => a.UserId == userId && a.IsActive);
        }

        public void DeleteByID(int entityID)
        {
            ShoppingList entity = Get(entityID);
            entity.IsActive = false;
            entityDAL.Update(entity);
        }

        public ShoppingList Get(int entityID)
        {
            return entityDAL.Get(a => a.ID == entityID && a.IsActive);
        }

        #endregion



    }
}
