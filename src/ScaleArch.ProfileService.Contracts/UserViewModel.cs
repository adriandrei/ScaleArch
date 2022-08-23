namespace ScaleArch.ProfileService.Contracts;

public class UserViewModel
{
    public string Name { get; set; }
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<PermissionViewModel> Permissions { get; set; }
}