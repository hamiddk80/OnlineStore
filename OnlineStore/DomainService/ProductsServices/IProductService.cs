using Domain.Shared.ValueObjects;

namespace DomainService.ProductsServices
{
    public interface IProductService
    {
        Task<Guid> AddProduct(Title title, string slug, Price price, string img, int stock, Guid categortId);
        Task UpdateProduct(Guid id, Title title, string slug, Price price, string img, int stock, Guid categortId);
        Task IncreaseStock(Guid id, int increaseStock);
    }


}
