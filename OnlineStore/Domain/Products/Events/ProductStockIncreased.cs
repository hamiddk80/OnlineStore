using Domain.Abstracts.Events;
using MediatR;

namespace Domain.Products.Events
{
    public class ProductStockIncreased : IDomainEvent, INotification
    {
        public ProductStockIncreased(Guid id, int increaseStock)
        {
            Id = id;
            IncreaseStock = increaseStock;
        }

        public Guid Id { get; private set; }
        public int IncreaseStock { get; private set; }


    }


}
