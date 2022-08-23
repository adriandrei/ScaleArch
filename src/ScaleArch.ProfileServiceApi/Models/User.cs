using Ardalis.Specification;
using ScaleArch.Core;

namespace ScaleArch.ProfileServiceApi.Models;

public class User : BaseEntity
{
    private readonly List<Permission> _permissions = new List<Permission>();
    public IReadOnlyCollection<Permission> Permissions => _permissions.AsReadOnly();

    public User()
    {

    }
    public User(string name) : base()
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public void AddPermission(Permission permission)
    {
        if (!this._permissions.Contains(permission))
            this._permissions.Add(permission);
    }

    public void RemovePermission(Permission permission)
    {
        if (this._permissions.Contains(permission))
            this._permissions.Remove(permission);
    }
}

public class UserById : Specification<User>
{
    public UserById(string id)
    {
        Query
            .Where(t => t.Id == id)
            .Include(t => t.Permissions)
            .AsSplitQuery();
    }
}

public class UserSpec : Specification<User>
{
    public UserSpec()
    {
        Query
            .AsNoTracking()
            .OrderBy(t => t.CreatedAt)
            .Include(t => t.Permissions);
    }
}