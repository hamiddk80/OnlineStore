using Domain.Abstracts.Entities;
using Domain.Abstracts.Events;
using Domain.ProductCategories.Events;
using Domain.Products.Entities;
using Domain.Shared.ValueObjects;

namespace Domain.ProductCategories.Entities
{
    public class ProductCategory : Entity<Guid>
    {
        public Title Title { get; private set; }

        public string Slug { get; private set; }

        public ICollection<Product> Products { get; set; }

        private ProductCategory()
        {

        }

        private ProductCategory(Guid id, Title title, string slug)
        {
            HandleEvent(new ProductCategoryAdded(id, title, slug));
        }

        public static ProductCategory AddCategory(Guid id, Title title, string slug)
        {
            return new ProductCategory(id, title, slug);
        }

        public void Update(Title title, string slug)
        {
            HandleEvent(new ProductCategoryUpdated(this.Id, title, slug));
        }

        protected override void SetStateByEvent(IDomainEvent @event)
        {
            switch (@event)
            {
                case ProductCategoryAdded e:
                    Id = e.Id;
                    Title = Title.FromString(e.Title);
                    Slug = e.Slug;
                    break;

                case ProductCategoryUpdated e:
                    Title = Title.FromString(e.Title);
                    Slug = e.Slug;
                    break;

            }
        }

        protected override void ValidateInvariants()
        {

            var isValid =
                        Id != default;

            if (!isValid)
            {
                throw new InvalidOperationException("Invalid Id");
            }


        }
    }
}
