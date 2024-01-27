using Contracts.Data.Sql.Repositories;
using Domain.ProductCategories.Entities;

namespace Data.Sql.Repositories
{
    public class ProductCategoryRepository(OnlineStoreDbContext db) : IProductCategoryRepository
    {
        public Task AddAsync(ProductCategory product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory> Find(Guid id)
        {
            throw new NotImplementedException();
        }
    }


}
