using Contracts.Data.Sql.Repositories;
using Domain.Products.Entities;

namespace Data.Sql.Repositories
{


    public class ProductRepository(OnlineStoreDbContext db) : IProductRepository
    {
        public Task AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Find(Guid id)
        {
            throw new NotImplementedException();
        }
    }


}
