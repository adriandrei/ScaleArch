using FluentValidation;
using MediatR;
using ScaleArch.ApiTemplate.Models;
using Toolbelt.Mongo.Interfaces;

namespace ScaleArch.ApiTemplate.Requests;

public class CreateSample : IRequest<string>
{
	public CreateSample(string name)
	{
		Name = name;
	}
    public string Name { get; set; }
}

public sealed class CreateSampleValidator : AbstractValidator<CreateSample>
{
	public CreateSampleValidator(IMongoRepository<SampleEntity> repo)
	{
		RuleFor(t => t.Name).NotNull().NotEmpty();
		RuleFor(t => t.Name).MinimumLength(3);
		RuleFor(t => t.Name).MustAsync(async (name, cancellationToken) =>
		{
			var existingWithSameName = await repo.ListAsync(nameof(SampleEntity), prop => prop.Name == name);
			return !existingWithSameName.Any();
		}).WithMessage(t => $"A {nameof(SampleEntity)} already exists for {t.Name}");
	}
}

public class CreateSampleHandler : IRequestHandler<CreateSample, string>
{
	private readonly IMongoRepository<SampleEntity> repo;

	public CreateSampleHandler(
		IMongoRepository<SampleEntity> repo)
	{
		this.repo = repo;
	}

	public async Task<string> Handle(CreateSample request, CancellationToken cancellationToken)
	{
		var entity = new SampleEntity(request.Name);
		await this.repo.CreateAsync(entity);

		return entity.Id;
	}
}
