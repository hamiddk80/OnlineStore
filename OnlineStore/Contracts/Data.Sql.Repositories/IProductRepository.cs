using Domain.Products.Entities;

namespace Contracts.Data.Sql.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);

        Task<Product> Find(Guid id);
    }


}
