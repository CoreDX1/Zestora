namespace Zestora.Domain.Entities;

public partial class Variant
{
    public Guid Id { get; set; }

    public string VariantOption { get; set; } = null!;

    public Guid ProductId { get; set; }

    public Guid VariantOptionId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual VariantOption VariantOptionNavigation { get; set; } = null!;

    public virtual ICollection<VariantValue> VariantValues { get; set; } = new List<VariantValue>();
}
