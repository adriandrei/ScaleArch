using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScaleArch.ProfileService.Contracts;
using ScaleArch.ProfileServiceApi.Models;
using ScaleArch.Sql;
using System.ComponentModel.DataAnnotations;

namespace ScaleArch.ProfileServiceApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IRepository<User> userRepo;
    private readonly IRepository<Permission> permissionRepo;
    private readonly IMapper mapper;

    public class CreateUser
    {
        [Required]
        public string Name { get; set; }
    }

    public class AddUserPermission
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string PermissionId { get; set; }
    }

    public UserController(
        IRepository<User> repo,
        IRepository<Permission> permissionRepo,
        IMapper mapper)
    {
        this.userRepo = repo;
        this.permissionRepo = permissionRepo;
        this.mapper = mapper;
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListAsync()
    {
        var users = await this.userRepo.ListAsync(new UserSpec());

        return Ok(users.Select(t => this.mapper.Map<UserViewModel>(t)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return BadRequest($"Invalid {nameof(id)}");

        var user = await this.userRepo.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpPut("create")]
    public async Task<IActionResult> CreateAsync([FromBody]CreateUser model)
    {
        if (ModelState.IsValid)
        {
            await this.userRepo.AddAsync(new User(model.Name));

            return Accepted();
        }
        else
        {
            return BadRequest(ModelState.Values.SelectMany(t => t.Errors));
        }
    }

    [HttpPut("addpermission")]
    public async Task<IActionResult> AddUserPermissionAsync([FromBody]AddUserPermission model)
    {
        if (ModelState.IsValid)
        {
            var user = await this.userRepo.SingleAsync(new UserById(model.UserId));

            if (user == null)
                return NotFound($"No {nameof(User)} found for {model.UserId}");

            var permission = await this.permissionRepo.SingleAsync(new PermissionById(model.PermissionId));

            if (permission == null)
                return NotFound($"No {nameof(Permission)} found for {model.PermissionId}");

            user.AddPermission(permission);
            await this.userRepo.UpdateAsync(user);

            return Accepted();
        }
        else
        {
            return BadRequest(ModelState.Values.SelectMany(t => t.Errors));
        }
    }

    
}