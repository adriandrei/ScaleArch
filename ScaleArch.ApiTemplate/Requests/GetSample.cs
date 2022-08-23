﻿using FluentValidation;
using MediatR;
using ScaleArch.ApiTemplate.Models;


using Toolbelt.Mongo.Interfaces;
using Toolbelt.Mongo.Models;

namespace ScaleArch.ApiTemplate.Requests;

public class GetSample : IRequest<SampleEntity>
{
	public GetSample(string id)
	{
		Id = id;
	}

    public string Id { get; set; }
}

public sealed class GetSampleValidator : AbstractValidator<GetSample>
{
    public GetSampleValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
    }
}
public class GetSampleHandler : IRequestHandler<GetSample, SampleEntity>
{
    private readonly IMongoRepository<SampleEntity> repo;

    public GetSampleHandler(
        IMongoRepository<SampleEntity> repo)
    {
        this.repo = repo;
    }

    public async Task<SampleEntity> Handle(GetSample request, CancellationToken cancellationToken)
    {
        var entity = await this.repo.GetAsync(new MongoRequest<SampleEntity>(request.Id, nameof(SampleEntity)));

        return entity;
    }
}
