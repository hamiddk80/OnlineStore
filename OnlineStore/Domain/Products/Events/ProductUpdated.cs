using Domain.Abstracts.Events;
using MediatR;

namespace Domain.Products.Events
{
    public class ProductUpdated : IDomainEvent, INotification
    {
        public ProductUpdated(Guid id, string title, string slug, decimal price, string img, int stock, Guid productCategoryId)
        {
            Id = id;
            Title = title;
            Slug = slug;
            Price = price;
            Img = img;
            Stock = stock;
            ProductCategoryId = productCategoryId;
        }

        public Guid Id { get; private set; }

        public string Title { get; private set; }

        public string Slug { get; private set; }

        public decimal Price { get; private set; }

        public string Img { get; private set; }

        public int Stock { get; private set; }

        public Guid ProductCategoryId { get; private set; }


    }

}
