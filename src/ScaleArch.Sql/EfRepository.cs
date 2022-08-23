using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScaleArch.Core;

namespace ScaleArch.Sql;

public interface IRepository<T> : IRepositoryBase<T> where T : BaseEntity
{
    Task<T> SingleAsync(ISpecification<T> specification, CancellationToken cancellationToken = default(CancellationToken));
}

public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : BaseEntity
{
    public EfRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = entity.CreatedAt;
        return await base.AddAsync(entity, cancellationToken);
    }

    public async Task<T> SingleAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        var entities = await this.ListAsync(specification, cancellationToken);
        if (entities != null && entities.Any())
            return entities.SingleOrDefault();
        return null;
    }

    public override async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        await base.UpdateAsync(entity, cancellationToken);
    }
}