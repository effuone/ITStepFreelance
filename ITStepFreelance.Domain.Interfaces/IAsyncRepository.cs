using Ardalis.Specification;
using ITStepFreelanceApp.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITStepFreelanceApp.Domain.Interfaces {
  public interface IAsyncRepository<TEntity> where TEntity : BaseEntity {
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TEntity>> ListAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<int> CountAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);
    Task<TEntity> FirstAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);
  }
}
