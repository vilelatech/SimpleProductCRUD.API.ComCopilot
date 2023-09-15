using SimpleProductCRUD.API.ComCopilot.Validations;

namespace SimpleProductCRUD.API.ComCopilot.Entities;

public sealed class Category : Entity
{
    public string Name { get; private set; }
    public ICollection<Product> Products { get; set; }

    public Category(string name)
    {
        Validate(name);
    }

    public void Update(string name)
    {
        Validate(name);
    }

    public Category(int id, string name)
    {
        ExceptionValidation.When(id < 0, "Invalid Id value");
        Id = id;
        Validate(name);
    }

    private void Validate(string name)
    {
        ExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");

        ExceptionValidation.When(name.Length < 3, "Name must have at least 3 characters");

        Name = name;
    }
}