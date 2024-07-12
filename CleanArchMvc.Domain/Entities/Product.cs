using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }


        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name value. The name can't be empty.");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name length. It must have at least 3 characters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required.");

            DomainExceptionValidation.When(description.Length < 5, "Invalid description length. It must have at least 5 characters.");

            DomainExceptionValidation.When(price < 0, "Invalid price. It can't be less than zero.");

            DomainExceptionValidation.When(stock < 0, "Invalid stock. It can't be less than zero.");

            DomainExceptionValidation.When(image?.Length > 250, "Invalid image value. It must be at maximum 250 characters.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
