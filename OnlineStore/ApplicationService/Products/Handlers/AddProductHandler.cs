using ApplicationService.Products.Commands;
using Contracts;
using Contracts.Data.Sql.Repositories;
using Domain.Products.Entities;
using Domain.Shared.ValueObjects;
using MediatR;

namespace ApplicationService.Products.Handlers
{
    public class AddProductHandler(IUniOfWork db, IProductRepository _productRepository) : IRequestHandler<AddProduct, Unit>
    {



        public async Task<Unit> Handle(AddProduct request, CancellationToken cancellationToken)
        {

            var product = Product.AddProduct(Guid.NewGuid(), Title.FromString(request.Title), request.Slug, Price.FromDecimal(request.Price),
                                                request.Img, request.Stock, request.ProductCategoryId);


            await _productRepository.AddAsync(product);

            await db.Commit();

            return Unit.Value;
        }


    }


}
