using NTierSample.Core.DataAccess;
using NTierSample.DAL.Abstract;
using NTierSample.Model.Entities;

namespace NTierSample.DAL.Concrete.Repositories
{
    class ListItemRepository : EFRepositoryBase<ListItem, NTierSampleDbContext>, IListItemDAL
    {
    }
}
