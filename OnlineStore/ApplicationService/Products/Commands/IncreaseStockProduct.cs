using MediatR;

namespace ApplicationService.Products.Commands
{
    public class IncreaseStockProduct : IRequest<Unit>
    {
        public IncreaseStockProduct(Guid id, int increaseStock)
        {
            Id = id;
            IncreaseStock = increaseStock;
        }

        public Guid Id { get; private set; }
        public int IncreaseStock { get; private set; }
    }



}
