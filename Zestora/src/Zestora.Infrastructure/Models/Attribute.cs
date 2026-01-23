namespace Zestora.Infrastructure.Models;

public partial class Attribute
{
    public Guid Id { get; set; }

    public string AttributeName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();

    public virtual StaffAccount? CreatedByNavigation { get; set; }

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();

    public virtual StaffAccount? UpdatedByNavigation { get; set; }
}
