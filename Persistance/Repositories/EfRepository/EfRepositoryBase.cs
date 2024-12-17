using Application.Services.Repositories;
using Application.Tools.Pagination;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.EfRepository;

public class EfRepositoryBase<TEntity, TEntityId, TContext>
    : IRepository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TContext : DbContext
{
    protected readonly TContext Context;
    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }
    public  TEntity Add(TEntity entity)
    {
       entity.CreatedDate = DateTime.UtcNow;
        Context.Add(entity);
        Context.SaveChanges();
        return entity;

    }

    public ICollection<TEntity> AddRange(ICollection<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public bool Any(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true)
    {
        throw new NotImplementedException();
    }

    public TEntity Delete(TEntity entity, bool permanent = false)
    {
        throw new NotImplementedException();
    }

    public ICollection<TEntity> DeleteRange(ICollection<TEntity> entity, bool permanent = false)
    {
        throw new NotImplementedException();
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate, bool withDeleted = false, bool enableTracking = true)
    {
        IQueryable<TEntity> query = Query();
        if (!enableTracking)
        {
            query=query.AsNoTracking();
        }if (withDeleted)
            query=query.IgnoreQueryFilters();
        return query.FirstOrDefault(predicate);
    }

    public IQueryable<TEntity> Query() => Context.Set<TEntity>();

    public Paginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true)
    {
        throw new NotImplementedException();
    }

    public TEntity Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public ICollection<TEntity> UpdateRange(ICollection<TEntity> entities)
    {
        throw new NotImplementedException();
    }
}
