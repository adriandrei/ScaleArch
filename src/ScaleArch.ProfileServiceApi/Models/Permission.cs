using Ardalis.Specification;
using ScaleArch.Core;

namespace ScaleArch.ProfileServiceApi.Models;

public class Permission : BaseEntity
{
    public Permission()
    {
    }
    public Permission(string name) : base()
    {
        Name = name;
    }

    public string Name { get; set; }

    private readonly List<User> _users = new List<User>();
    public IReadOnlyCollection<User> Users => _users.AsReadOnly();
}

public class PermissionById : Specification<Permission>
{
    public PermissionById(string id)
    {
        Query
            .Where(t => t.Id == id)
            .Include(t => t.Users)
            .AsSplitQuery();
    }
}

public class PermissionByName : Specification<Permission>
{
    public PermissionByName(string permissionName)
    {
        Query
            .AsNoTracking()
            .Where(t => t.Name == permissionName);
    }
}
