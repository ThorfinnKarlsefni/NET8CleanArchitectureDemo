namespace LogisticsManagementSystem.Domain;

public class Company : Entity<Guid>
{
    public string Name { get; private set; } = string.Empty;

    // public User? CreateUser { get; private set; }
    // public Guid? CreateUserId { get; private set; }
    // public User? UpdateUser { get; private set; }
    // public Guid? UpdateUserId { get; private set; }
    // public User? User { get; private set; }

    public Company(string name)
    {
        Name = name;
    }

}
