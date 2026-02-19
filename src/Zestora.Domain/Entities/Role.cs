namespace Zestora.Domain.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public List<string>? Privileges { get; set; }

    public virtual ICollection<StaffAccount> StaffAccounts { get; set; } = new List<StaffAccount>();
}
