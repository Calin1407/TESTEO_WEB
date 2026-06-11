using NovaTech.TerraTech.Platform.CommercialManagement.Domain.Model.Commands;
using NovaTech.TerraTech.Platform.CommercialManagement.Domain.Model.ValueObjects;

namespace NovaTech.TerraTech.Platform.CommercialManagement.Domain.Model.Aggregates;

public partial class Product
{
    protected Product() { }

    public Product(CreateProductCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        Name = command.Name;
        Description = command.Description;
        Price = new Money(command.Price);
        Type = command.Type;
        ImageUrl = command.ImageUrl;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Money Price { get; private set; }
    public string Type { get; private set; }
    public string ImageUrl { get; private set; }
}