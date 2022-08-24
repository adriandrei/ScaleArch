using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ScaleArch.ApiTemplate.Models;
using ScaleArch.ApiTemplate.Requests;
using ScaleArch.ApiTemplate.ViewModels;

namespace ScaleArch.ApiTemplate.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;
    private readonly ILogger<SampleController> _logger;

    public SampleController(
        IMediator mediator,
        IMapper mapper,
        ILogger<SampleController> logger)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        _logger = logger;
    }

    [HttpGet("list")]
    public async Task<IEnumerable<string>> ListAsync()
    {
        var samples = await this.mediator.Send(new ListSample());
        return samples.Select(t => t.Id);
    }

    [HttpGet("get/{id}")]
    public async Task<GetSampleViewModel> GetAsync(string id, int number)
    {
        var entity = await this.mediator.Send(new GetSample(id, number));
        var result = this.mapper.Map<GetSampleViewModel>(entity);

        return result;
    }

    [HttpPost("upsert")]
    public async Task<IStatusCodeActionResult> UpsertAsync([FromBody]CreateSample model)
    {
        return await this.mediator.Send(model);
    }
}