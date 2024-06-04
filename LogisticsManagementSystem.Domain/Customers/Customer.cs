
namespace LogisticsManagementSystem.Domain;

public class Customer : Entity
{
    public int Id { get; private set; }
    public Guid? UserId { get; private set; }
    public User? User { get; private set; }
    public Guid CompanyId { get; private set; }
    public Company Company { get; private set; } = null!;
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Remark { get; set; } = string.Empty;
    public string AppName { get; set; } = string.Empty;
    public string ModuleName { get; set; } = string.Empty;
    public string AdvName { get; set; } = string.Empty;
    public string ClueConvertStatus { get; set; } = string.Empty;
    public int Channel { get; set; }
    public int Item { get; set; }
    public int AccessStatus { get; set; }
    public int AccessResult { get; set; }
    public int Url { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime? AllocatedAt { get; private set; }
}
