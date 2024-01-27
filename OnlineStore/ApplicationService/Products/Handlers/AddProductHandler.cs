using ApplicationService.Products.Commands;
using Contracts;
using Domain.Shared.ValueObjects;
using DomainService.ProductsServices;
using MediatR;

namespace ApplicationService.Products.Handlers
{
    public class AddProductHandler(IUniOfWork db, IProductService productService) : IRequestHandler<AddProduct, Unit>
    {



        public async Task<Unit> Handle(AddProduct request, CancellationToken cancellationToken)
        {

            var id = productService.AddProduct(Title.FromString(request.Title), request.Slug, Price.FromDecimal(request.Price),
                                                request.Img, request.Stock, request.ProductCategoryId);


            await db.Commit();

            return Unit.Value;
        }


    }


}
