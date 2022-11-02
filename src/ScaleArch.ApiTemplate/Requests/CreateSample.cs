using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ScaleArch.ApiTemplate.Models;
using Toolbelt.Mongo.Interfaces;

namespace ScaleArch.ApiTemplate.Requests;

public class CreateSample : IRequest<IStatusCodeActionResult>
{
	public CreateSample(string name)
	{
		Name = name;
	}
    public string Name { get; set; }
}

public sealed class CreateSampleValidator : AbstractValidator<CreateSample>
{
	public CreateSampleValidator()
	{
		RuleFor(t => t.Name).NotNull().NotEmpty();
	}
}

public class CreateSampleHandler : IRequestHandler<CreateSample, IStatusCodeActionResult>
{
	private readonly IMongoRepository<SampleEntity> repo;

	public CreateSampleHandler(
		IMongoRepository<SampleEntity> repo)
	{
		this.repo = repo;
	}

	public async Task<IStatusCodeActionResult> Handle(CreateSample request, CancellationToken cancellationToken)
	{
		var entity = new SampleEntity(request.Name);
		await this.repo.CreateAsync(entity);

		return new AcceptedResult();
	}
}
