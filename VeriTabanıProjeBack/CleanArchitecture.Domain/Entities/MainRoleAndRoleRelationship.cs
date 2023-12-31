using CleanArchitecture.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public sealed class MainRoleAndRoleRelationship : Entity
{
    public MainRoleAndRoleRelationship()
    {
    }

    public MainRoleAndRoleRelationship(string roleId, string mainRoleId)
    {
        RoleId = roleId;
        MainRoleId = mainRoleId;
    }

    [ForeignKey("Role")]
    public string RoleId { get; set; }
    public Role Role { get; set; }

    [ForeignKey("MainRole")]
    public string MainRoleId { get; set; }
    public MainRole MainRole { get; set; }
}
