using MediatR;
using ScaleArch.ApiTemplate.Models;
using Toolbelt.Mongo.Interfaces;

namespace ScaleArch.ApiTemplate.Requests;

public class ListSample : IRequest<IEnumerable<SampleEntity>>
{
}

public class ListSamplehandler : IRequestHandler<ListSample, IEnumerable<SampleEntity>>
{
    private readonly IMongoRepository<SampleEntity> repo;

    public ListSamplehandler(IMongoRepository<SampleEntity> repo)
    {
        this.repo = repo;
    }

    public async Task<IEnumerable<SampleEntity>> Handle(ListSample request, CancellationToken cancellationToken)
    {
        return await this.repo.ListAsync(nameof(SampleEntity), null);
    }
}
