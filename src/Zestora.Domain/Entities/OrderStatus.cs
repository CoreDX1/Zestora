namespace Zestora.Domain.Entities;

public partial class OrderStatus
{
    public Guid Id { get; set; }

    public string StatusName { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Privacy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual StaffAccount? CreatedByNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual StaffAccount? UpdatedByNavigation { get; set; }
}
