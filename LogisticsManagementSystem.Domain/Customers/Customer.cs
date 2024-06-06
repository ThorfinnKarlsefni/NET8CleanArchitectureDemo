
namespace LogisticsManagementSystem.Domain;

public class Customer : Entity
{
    public int Id { get; private set; }
    public Guid? UserId { get; private set; }
    public User? User { get; private set; }
    public Guid? CompanyId { get; set; }
    public Company? Company { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Remark { get; set; }
    public string? AppName { get; set; }
    public string? ModuleName { get; set; }
    public string? AdvName { get; set; }
    public string? ClueConvertStatus { get; set; }
    public int Channel { get; set; }
    public int Item { get; set; }
    public int AccessStatus { get; set; }
    public int AccessResult { get; set; }
    public string? Url { get; set; }
    public string? Content { get; set; }
    public DateTime? AllocatedAt { get; private set; }
}
