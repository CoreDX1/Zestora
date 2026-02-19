namespace Zestora.Domain.Entities;

public partial class ProductAttributeValue
{
    public Guid Id { get; set; }

    public Guid ProductAttributeId { get; set; }

    public Guid AttributeValueId { get; set; }

    public virtual AttributeValue AttributeValue { get; set; } = null!;

    public virtual ProductAttribute ProductAttribute { get; set; } = null!;

    public virtual ICollection<VariantValue> VariantValues { get; set; } = new List<VariantValue>();
}
