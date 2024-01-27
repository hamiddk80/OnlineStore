using Domain.Abstracts.Events;
using MediatR;

namespace Domain.Products.Events
{
    public class ProductStockUpdated : IDomainEvent, INotification
    {
        public ProductStockUpdated(Guid id, int stock)
        {
            Id = id;
            Stock = stock;
        }

        public Guid Id { get; private set; }
        public int Stock { get; private set; }

    }

}
