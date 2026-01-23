using System;
using System.Collections.Generic;

namespace Zestora.Infrastructure.Models;

public partial class Tag
{
    public Guid Id { get; set; }

    public string TagName { get; set; } = null!;

    public string? Icon { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual StaffAccount? CreatedByNavigation { get; set; }

    public virtual StaffAccount? UpdatedByNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
