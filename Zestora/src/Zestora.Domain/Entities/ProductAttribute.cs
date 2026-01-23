namespace Zestora.Domain.Entities;

public partial class ProductAttribute
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public Guid AttributeId { get; set; }

    public virtual Attribute Attribute { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } =
        new List<ProductAttributeValue>();
}
