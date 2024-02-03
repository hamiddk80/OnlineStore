using Domain.Abstracts.Entities;
using Domain.Abstracts.Events;
using Domain.ProductCategories.Entities;
using Domain.Products.Events;
using Domain.Shared.ValueObjects;

namespace Domain.Products.Entities
{
    public class Product : Entity<Guid>
    {
        public Title Title { get; private set; }

        public string Slug { get; private set; }

        public Price Price { get; private set; }

        public string Img { get; private set; }

        public int Stock { get; private set; }

        public Guid ProductCategoryId { get; private set; }

        public ProductCategory ProductCategory { get; private set; }

        private Product()
        {

        }

        private Product(Guid id, Title title, string slug, Price price, string img, int stock, Guid categortId)
        {
            HandleEvent(new ProductAdded(id, title, slug, price, img, stock, categortId));
        }

        public static Product AddProduct(Guid id, Title title, string slug, Price price, string img, int stock, Guid categortId)
        {
            return new Product(id, title, slug, price, img, stock, categortId);
        }

        public void IncreaseStock(int stock)
        {
            HandleEvent(new ProductStockIncreased(this.Id, stock));
        }

        public void DecreaseStock(int stock)
        {
            if (stock < 0)
                throw new ArgumentOutOfRangeException("");

            if ((this.Stock - stock) < 0)
                throw new ArgumentOutOfRangeException("");

            HandleEvent(new ProductStockDecreased(this.Id, stock));
        }

        public void UpdateStock(int stock)
        {
            if (stock < 0)
                throw new ArgumentOutOfRangeException("");

            if ((this.Stock - stock) < 0)
                throw new ArgumentOutOfRangeException("");

            HandleEvent(new ProductStockUpdated(this.Id, stock));
        }

        public void Update(Title title, string slug, Price price, string img, int stock, Guid categortId)
        {
            HandleEvent(new ProductUpdated(this.Id, title, slug, price, img, stock, categortId));
        }

        protected override void SetStateByEvent(IDomainEvent @event)
        {
            switch (@event)
            {
                case ProductAdded e:
                    Id = e.Id;
                    Title = Title.FromString(e.Title);
                    Slug = e.Slug;
                    Img = e.Img;
                    Stock = e.Stock;
                    ProductCategoryId = e.ProductCategoryId;
                    break;

                case ProductUpdated e:
                    Title = Title.FromString(e.Title);
                    Slug = e.Slug;
                    Img = e.Img;
                    Stock = e.Stock;
                    ProductCategoryId = e.ProductCategoryId;
                    break;

                case ProductStockDecreased e:
                    Stock -= e.DecreasedStock;
                    break;

                case ProductStockIncreased e:
                    Stock += e.IncreaseStock;
                    break;

                case ProductStockUpdated e:
                    Stock = e.Stock;
                    break;

                default:
                    throw new InvalidOperationException("INVALID_EVENT_RISED");


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
