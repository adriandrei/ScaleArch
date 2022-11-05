using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ScaleArch.ApiTemplate.Helpers;
using ScaleArch.ApiTemplate.Requests;
using ScaleArch.ApiTemplate.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace ScaleArch.ApiTemplate.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
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

    [HttpGet]
    [Route("list")]
    [SwaggerOperation(Summary = $"Lists all available ids of SampleEntity")]
    [ProducesResponseType(typeof(IEnumerable<string>), 200)]
    [ProducesResponseType(typeof(ExceptionResponse), 500)]
    public async Task<IEnumerable<string>> ListAsync()
    {
        var samples = await this.mediator.Send(new ListSample());
        return samples.Select(t => t.Id);
    }

    [HttpGet]
    [Route("get/{id}")]
    [SwaggerOperation(Summary = $"Retrieves a single entity")]
    [ProducesResponseType(typeof(GetSampleViewModel), 200)]
    [ProducesResponseType(typeof(ExceptionResponse), 400)]
    [ProducesResponseType(typeof(ExceptionResponse), 500)]
    public async Task<GetSampleViewModel> GetAsync(string id, int number)
    {
        var entity = await this.mediator.Send(new GetSample(id, number));
        var result = this.mapper.Map<GetSampleViewModel>(entity);

        return result;
    }

    [HttpPost]
    [Route("upsert")]
    [SwaggerOperation(Summary = $"Creates an Entity")]
    [ProducesResponseType(202)]
    [ProducesResponseType(typeof(ExceptionResponse), 400)]
    [ProducesResponseType(typeof(ExceptionResponse), 500)]
    public async Task<IStatusCodeActionResult> UpsertAsync([FromBody]CreateSample model)
    {
        return await this.mediator.Send(model);
    }
}