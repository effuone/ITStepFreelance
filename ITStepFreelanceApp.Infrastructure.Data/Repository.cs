using Ardalis.Specification;
using ITStepFreelanceApp.Domain.Core.Models;
using ITStepFreelanceApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification.EntityFrameworkCore;

namespace ITStepFreelanceApp.Infrastructure.Data {
  public class Repository<TEntity> : IAsyncRepository<TEntity> where TEntity : BaseEntity {
    private readonly ApplicationContext _context;

    public Repository(ApplicationContext context) {
      _context = context;
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default) {
      await _context.Set<TEntity>().AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task<int> CountAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default) {
      var specification = ApplySpecification(spec);
      return await specification.CountAsync();
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default) {
      _context.Set<TEntity>().Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task<TEntity> FirstAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default) {
      var specification = ApplySpecification(spec);
      return await specification.FirstOrDefaultAsync(cancellationToken);
    }
    public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) {
      var keyValues = new object[] { id };
      return await _context.Set<TEntity>().FindAsync(keyValues, cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> ListAllAsync(CancellationToken cancellationToken = default) {
      return await _context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default) {
      var specification = ApplySpecification(spec);
      return await specification.ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default) {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync(cancellationToken);
    }
    private IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : TEntity {
      var evaluator = new SpecificationEvaluator();
      return evaluator.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }
  }
}
