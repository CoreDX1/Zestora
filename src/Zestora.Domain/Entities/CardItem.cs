namespace Zestora.Domain.Entities;

public partial class CardItem
{
    public Guid Id { get; set; }

    public Guid? CardId { get; set; }

    public Guid? ProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual Card? Card { get; set; }

    public virtual Product? Product { get; set; }
}
