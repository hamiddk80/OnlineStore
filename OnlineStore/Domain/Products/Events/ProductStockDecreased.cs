using Domain.Abstracts.Events;
using MediatR;

namespace Domain.Products.Events
{
    public class ProductStockDecreased : IDomainEvent, INotification
    {
        public ProductStockDecreased(Guid id, int decreasedStock)
        {
            Id = id;
            DecreasedStock = decreasedStock;
        }

        public Guid Id { get; private set; }
        public int DecreasedStock { get; private set; }


    }


}
