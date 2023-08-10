using Microsoft.Extensions.DependencyInjection;
using NTierSample.DAL.Abstract;
using NTierSample.DAL.Concrete.Repositories;

namespace NTierSample.DAL
{
    public static class EFContextDAL
    {
        public static void AddScopeDAL(this IServiceCollection services)
        {
            services.AddScoped<IShoppingListDAL, ShoppingListRepository>();
            services.AddScoped<IUserDAL, UserRepository>();
            services.AddScoped<IListItemDAL, ListItemRepository>();
            services.AddScoped<IProductDAL, ProductRepository>();
        }
    }
}
