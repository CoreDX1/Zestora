namespace Zestora.Domain.Entities;

public partial class Sell
{
    public int Id { get; set; }

    public Guid? ProductId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public virtual Product? Product { get; set; }
}
