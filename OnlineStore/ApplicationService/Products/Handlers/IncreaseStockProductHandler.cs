using ApplicationService.Products.Commands;
using Contracts;
using Contracts.Data.Sql.Repositories;
using MediatR;

namespace ApplicationService.Products.Handlers
{
    public class IncreaseStockProductHandler(IUniOfWork db, IProductRepository _productRepository) : IRequestHandler<IncreaseStockProduct, Unit>
    {
        public async Task<Unit> Handle(IncreaseStockProduct request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Find(request.Id);

            if (product is null)
                throw new ArgumentNullException($"Product With Id={request.Id} Not Found");

            product.IncreaseStock(request.IncreaseStock);

            await db.Commit();

            return Unit.Value;

        }
    }


}
