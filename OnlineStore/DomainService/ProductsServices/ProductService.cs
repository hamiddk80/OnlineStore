using Contracts.Data.Sql.Repositories;
using Domain.Products.Entities;
using Domain.Shared.ValueObjects;

namespace DomainService.ProductsServices
{
    public class ProductService(IProductRepository _productRepository) : IProductService
    {
        public async Task<Guid> AddProduct(Title title, string slug, Price price, string img, int stock, Guid categortId)
        {
            var id = Guid.NewGuid();

            var product = Product.AddProduct(id, title, slug, price, img, stock, categortId);

            await _productRepository.AddAsync(product);

            return id;


        }

        public async Task UpdateProduct(Guid id, Title title, string slug, Price price, string img, int stock, Guid categortId)
        {
            var product = await _productRepository.Find(id);

            if (product is null)
                throw new ArgumentNullException($"Product With Id = {id} Not Found");


            product.Update(title, slug, price, img, stock, categortId);

        }

        public async Task IncreaseStock(Guid id, int increaseStock)
        {
            var product = await _productRepository.Find(id);

            if (product is null)
                throw new ArgumentNullException($"Product With Id = {id} Not Found");

            product.IncreaseStock(increaseStock);

        }


    }


}
