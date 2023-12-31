namespace CleanArchitecture.Domain.Abstractions;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public bool IsActive { get; set; } = true;
}
