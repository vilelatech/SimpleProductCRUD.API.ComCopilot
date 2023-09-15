using SimpleProductCRUD.API.ComCopilot.Validations;

namespace SimpleProductCRUD.API.ComCopilot.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public Product(int id, string name, string description, decimal price, int stock)
    {
        ExceptionValidation.When(id < 0, "Invalid ID value");
        Id = id;
        Validate(name, description, price, stock);
    }

    public Product(string name, string description, decimal price, int stock)
    {
        Validate(name, description, price, stock);
    }

    public void Update(string name, string description, decimal price, int stock, int CategoryId)
    {
        Validate(name, description, price, stock);
        CategoryId = CategoryId;
    }

    private void Validate(string name, string description, decimal price, int stock)
    {
        ExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");
        ExceptionValidation.When(name.Length < 3, "Name must be at least 3 characters");

        ExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required");
        ExceptionValidation.When(description.Length < 5, "Description must be at least 5 characters");

        ExceptionValidation.When(price < 0, "Price must be greater than zero");

        ExceptionValidation.When(stock < 0, "Stock must be greater than zero");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }
}