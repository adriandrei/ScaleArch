using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ScaleArch.ApiTemplate.Helpers;

public class BaseController : ControllerBase
{
    [Authorize]
    protected string GetUserId () => HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub")!.Value;
}
