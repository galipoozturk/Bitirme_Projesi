using NTierSample.BLL.Abstract;
using NTierSample.DAL.Abstract;
using NTierSample.Model.Entities;

namespace NTierSample.BLL.Concrete
{
    class ProductService : IProductBLL
    {
        IProductDAL entityDAL;
        public ProductService(IProductDAL dal)
        {
            entityDAL = dal;
        }

        void Check(Product entity)
        {
          
        }

        #region Base Method
        public void Insert(Product entity)
        {
            Check(entity);
            entityDAL.Add(entity);
        }
        public void Update(Product entity)
        {
            Check(entity);
            entityDAL.Update(entity);
        }
        public void Delete(Product entity)
        {
            entity.IsActive = false;
            entityDAL.Update(entity);
        }
        public void DeleteByID(int entityID)
        {
            Product entity = Get(entityID);
            entity.IsActive = false;
            entityDAL.Update(entity);
        }
        public Product Get(int entityID)
        {
            return entityDAL.Get(a => a.ID == entityID && a.IsActive);
        }
        public ICollection<Product> GetAll()
        {
            return entityDAL.GetAll(a=> a.IsActive);
        }

        #endregion


      
    }
}
