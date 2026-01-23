using System;
using System.Collections.Generic;

namespace Zestora.Infrastructure.Models;

public partial class AttributeValue
{
    public Guid Id { get; set; }

    public Guid AttributeId { get; set; }

    public string AttributeValue1 { get; set; } = null!;

    public string? Color { get; set; }

    public virtual Attribute Attribute { get; set; } = null!;

    public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; } = new List<ProductAttributeValue>();
}
