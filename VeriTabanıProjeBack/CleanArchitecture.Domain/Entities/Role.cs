using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities;

public sealed class Role : IdentityRole<string>
{
    public Role() { }

    public Role(string title, string code, string name)
    {
        Id = Guid.NewGuid().ToString();
        Code = code;
        Title = title;  
        Name = name;
    }

    public string Code { get; set; }
    public string Title { get; set; }
}
