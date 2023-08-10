using NTierSample.BLL.Abstract;
using NTierSample.DAL.Abstract;
using NTierSample.Model.Entities;
using NTierSample.Model.Enums;

namespace NTierSample.BLL.Concrete
{
    class ListItemService : IListItemBLL
    {
        IListItemDAL entityDAL;
        public ListItemService(IListItemDAL dal)
        {
            entityDAL = dal;
        }

        void Check(ListItem entity)
        {
          
        }

        #region Base Method
        public void Insert(ListItem entity)
        {
            Check(entity);
            entityDAL.Add(entity);
        }
        public void Update(ListItem entity)
        {
            Check(entity);
            entityDAL.Update(entity);
        }
        public void Delete(ListItem entity)
        {
            entity.IsActive = false;
            entityDAL.Update(entity);
        }
        public void DeleteByID(int entityID)
        {
            ListItem entity = Get(entityID);
            entity.IsActive = false;
            entityDAL.Update(entity);
        }
        public ListItem Get(int entityID)
        {
            return entityDAL.Get(a => a.ID == entityID && a.IsActive);
        }
        public ICollection<ListItem> GetAll()
        {
            return entityDAL.GetAll(a=> a.IsActive);
        }

        #endregion


      
    }
}
