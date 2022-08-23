using Microsoft.AspNetCore.Mvc;
using ScaleArch.ProfileServiceApi.Models;
using ScaleArch.Sql;
using System.ComponentModel.DataAnnotations;

namespace ScaleArch.ProfileServiceApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PermissionController : ControllerBase
{
    private readonly IRepository<Permission> permissionsRepo;

    public class AddPermissionModel
    {
        [Required]
        public string Name { get; set; }
    }

    public PermissionController(IRepository<Permission> permissionsRepo)
    {
        this.permissionsRepo = permissionsRepo;
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListAsync()
    {
        var permissions = await this.permissionsRepo.ListAsync();

        return Ok(permissions.Select(t => new { id = t.Id, name = t.Name }));
    }

    [HttpPut("add")]
    public async Task<IActionResult> AddPermissionAsync([FromBody] AddPermissionModel model)
    {
        if (ModelState.IsValid)
        {
            var permission = await this.permissionsRepo.ListAsync(new PermissionByName(model.Name));

            if (permission.Any())
                return BadRequest($"Permission with name {model.Name} already exists");


            await this.permissionsRepo.AddAsync(new Permission(model.Name));

            return Accepted();
        }
        else
        {
            return BadRequest(ModelState.Values.SelectMany(t => t.Errors));
        }
    }
}
