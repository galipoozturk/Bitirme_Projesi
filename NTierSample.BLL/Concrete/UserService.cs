using NTierSample.BLL.Abstract;
using NTierSample.DAL.Abstract;
using NTierSample.Model.Entities;
using NTierSample.Model.Enums;

namespace NTierSample.BLL.Concrete
{
    class UserService : IUserBLL
    {
        IUserDAL userDAL;
        public UserService(IUserDAL dal)
        {
            userDAL = dal;
        }

        void Check(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.Password))
            {
                throw new Exception("Deger boş geçilemez");
            }
        }

        #region Base Method
        public void Insert(User entity)
        {
            Check(entity);
            entity.IsActive = true;
            entity.Role = UserRole.Standard;
            userDAL.Add(entity);
        }
        public void Update(User entity)
        {
            Check(entity);
            userDAL.Update(entity);
        }
        public void Delete(User entity)
        {
            entity.IsActive = false;
            userDAL.Update(entity);
        }
        public void DeleteByID(int entityID)
        {
            User user = Get(entityID);
            user.IsActive = false;
            userDAL.Update(user);
        }
        public User Get(int entityID)
        {
            return userDAL.Get(a => a.ID == entityID);
        }
        public ICollection<User> GetAll()
        {
            return userDAL.GetAll();
        }

        #endregion

        public User GetUserByLoginData(string mail, string password)
        {
            User loginUser = userDAL.Get(a => a.IsActive && a.Email == mail && a.Password == password);
            return loginUser;
        }

      
    }
}
