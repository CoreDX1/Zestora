namespace Zestora.Domain.Entities;

public partial class OrderItem
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public string? OrderId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
