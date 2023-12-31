using CleanArchitecture.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;
public sealed class MainRoleAndUserRelationship : Entity
{
    public MainRoleAndUserRelationship() { }

    public MainRoleAndUserRelationship(string userId, string mainRoleId)
    {
        UserId = userId;
        MainRoleId = mainRoleId;
    }

    [ForeignKey("User")]
    public string UserId { get; set; }
    public User User { get; set; }

    [ForeignKey("MainRole")]
    public string MainRoleId { get; set; }
    public MainRole MainRole { get; set; }
}
