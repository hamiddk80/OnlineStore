using Domain.ProductCategories.Entities;

namespace Contracts.Data.Sql.Repositories
{
    public interface IProductCategoryRepository
    {
        Task AddAsync(ProductCategory product);

        Task<ProductCategory> Find(Guid id);
    }


}
