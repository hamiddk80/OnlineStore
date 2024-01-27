using ApplicationService.Products.Commands;
using Contracts;
using Contracts.Data.Sql.Repositories;
using Domain.Shared.ValueObjects;
using MediatR;

namespace ApplicationService.Products.Handlers
{
    public class UpdateProductHandler(IUniOfWork db, IProductRepository _productRepository) : IRequestHandler<UpdateProduct, Unit>
    {
        public async Task<Unit> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {

            var product = await _productRepository.Find(request.Id);

            if (product is null)
                throw new ArgumentNullException($"Product With Id={request.Id} Not Found");


            product.Update(Title.FromString(request.Title), request.Slug, Price.FromDecimal(request.Price), request.Img, request.Stock, request.ProductCategoryId);

            await db.Commit();

            return Unit.Value;
        }
    }


}
