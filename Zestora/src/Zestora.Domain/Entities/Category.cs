namespace Zestora.Domain.Entities;

public partial class Category
{
    public Guid Id { get; set; }

    public Guid? ParentId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryDescription { get; set; }

    public string? Icon { get; set; }

    public string? Image { get; set; }

    public string? Placeholder { get; set; }

    public bool? Active { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual StaffAccount? CreatedByNavigation { get; set; }

    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    public virtual Category? Parent { get; set; }

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } =
        new List<ProductCategory>();

    public virtual StaffAccount? UpdatedByNavigation { get; set; }
}
