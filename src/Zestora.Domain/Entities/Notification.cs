namespace Zestora.Domain.Entities;

public partial class Notification
{
    public Guid Id { get; set; }

    public Guid? AccountId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public bool? Seen { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ReceiveTime { get; set; }

    public DateOnly? NotificationExpiryDate { get; set; }

    public virtual StaffAccount? Account { get; set; }
}
