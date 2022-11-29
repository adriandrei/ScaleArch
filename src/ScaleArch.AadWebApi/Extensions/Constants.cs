using Microsoft.AspNetCore.Authorization;

namespace ScaleArch.AadWebApi.Extensions;

public static class Extensions
{
    public static void AddRole(this AuthorizationOptions options, string policy)
    {
        options.AddPolicy(policy, p => p.RequireClaim("extension_Role", policy));
    }
}

public static class Policies
{
    public const string AFIR = "AFIR";
    public const string Producer = "Producer";
    public const string Retailer = "Retailer";
}
