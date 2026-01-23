using System;
using System.Collections.Generic;

namespace Zestora.Infrastructure.Models;

public partial class Card
{
    public Guid Id { get; set; }

    public Guid? CustomerId { get; set; }

    public virtual ICollection<CardItem> CardItems { get; set; } = new List<CardItem>();

    public virtual Customer? Customer { get; set; }
}
