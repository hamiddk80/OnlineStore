using MediatR;

namespace ApplicationService.Products.Commands
{

    public class AddProduct : IRequest<Unit>
    {
        public AddProduct(string title, string slug, decimal price, string img, int stock, Guid productCategoryId)
        {
            Title = title;
            Slug = slug;
            Price = price;
            Img = img;
            Stock = stock;
            ProductCategoryId = productCategoryId;
        }


        public string Title { get; private set; }

        public string Slug { get; private set; }

        public decimal Price { get; private set; }

        public string Img { get; private set; }

        public int Stock { get; private set; }

        public Guid ProductCategoryId { get; private set; }

    }



}
