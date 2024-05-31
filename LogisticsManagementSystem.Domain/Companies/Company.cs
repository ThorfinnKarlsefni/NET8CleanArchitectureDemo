namespace LogisticsManagementSystem.Domain;

public class Company : Entity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Address { get; private set; }
    public bool IsDisable { get; private set; } = false;

    public Company(string name, string? phoneNumber, string? address, bool isDisable)
    {
        Id = Guid.NewGuid();
        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
        IsDisable = isDisable;
    }

    public void Update(string name, string? phoneNumber, string? address, bool isDisable)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
        IsDisable = isDisable;
    }

    public void Disable(bool isDisable)
    {
        IsDisable = isDisable;
    }
}
