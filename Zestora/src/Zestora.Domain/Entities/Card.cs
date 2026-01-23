namespace Zestora.Domain.Entities;

public partial class Card
{
    public Guid Id { get; set; }

    public Guid? CustomerId { get; set; }

    public virtual ICollection<CardItem> CardItems { get; set; } = new List<CardItem>();

    public virtual Customer? Customer { get; set; }
}
