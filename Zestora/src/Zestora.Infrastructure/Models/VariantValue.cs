using System;
using System.Collections.Generic;

namespace Zestora.Infrastructure.Models;

public partial class VariantValue
{
    public Guid Id { get; set; }

    public Guid VariantId { get; set; }

    public Guid ProductAttributeValueId { get; set; }

    public virtual ProductAttributeValue ProductAttributeValue { get; set; } = null!;

    public virtual Variant Variant { get; set; } = null!;
}
