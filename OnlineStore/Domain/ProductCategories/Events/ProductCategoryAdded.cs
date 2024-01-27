using Domain.Abstracts.Events;
using MediatR;

namespace Domain.ProductCategories.Events
{
    public class ProductCategoryAdded : IDomainEvent, INotification
    {
        public ProductCategoryAdded(Guid id, string title, string slug)
        {
            Id = id;
            Title = title;
            Slug = slug;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Slug { get; private set; }

    }





}
