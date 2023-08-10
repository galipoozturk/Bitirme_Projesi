using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NTierSample.Core.DataAccess;
using NTierSample.DAL.Abstract;
using NTierSample.Model.Entities;
using System.Collections.ObjectModel;

namespace NTierSample.DAL.Concrete.Repositories
{

    class ShoppingListRepository : EFRepositoryBase<ShoppingList, NTierSampleDbContext>, IShoppingListDAL
    {
        private NTierSampleDbContext context;
        public ShoppingListRepository()
        {

            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<NTierSampleDbContext>();
            ServiceProvider provider = services.BuildServiceProvider();
            context = provider.GetService<NTierSampleDbContext>();
        }
        public ShoppingList GetByIdWithDetail(int id, int userId)
        {
            return context.ShoppingLists.Where(a=>a.UserId == userId && a.ID == id && a.IsActive == true).Include(a=>a.Items).ThenInclude(a=>a.Product).FirstOrDefault();
        }
    }
}
