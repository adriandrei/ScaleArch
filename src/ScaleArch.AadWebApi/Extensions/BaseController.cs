using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ScaleArch.AadWebApi.Extensions;

public class BaseController : ControllerBase
{
    [Authorize]
    protected string GetUserId() => HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
}

