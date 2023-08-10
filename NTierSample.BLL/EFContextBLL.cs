using Microsoft.Extensions.DependencyInjection;
using NTierSample.BLL.Abstract;
using NTierSample.BLL.Concrete;
using NTierSample.DAL;

namespace NTierSample.BLL
{
    public static class EFContextBLL
    {
        public static void AddScopeBLL(this IServiceCollection services)
        {
            services.AddScopeDAL();
            services.AddScoped<IUserBLL, UserService>();
            services.AddScoped<IShoppingListBLL, ShoppingListService>();
            services.AddScoped<IListItemBLL, ListItemService>();
            services.AddScoped<IProductBLL, ProductService>();
        }
    }
}
