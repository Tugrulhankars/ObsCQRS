using Application.Tools.Pagination;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories;

public interface IRepository<TEntity,TEntityId>
    where TEntity : Entity<TEntityId>
{
    TEntity? Get(Expression<Func<TEntity,bool>> predicate,
        bool withDeleted=false,
        bool enableTracking=true);

    Paginate<TEntity> GetList(
        Expression<Func<TEntity,bool>>? predicate=null,
        int index=0,
        int size=10,
        bool withDeleted=false,
        bool enableTracking=true);

    bool Any(Expression<Func<TEntity,bool>>? predicate=null,bool withDeleted=false,bool enableTracking=true);
    TEntity Add(TEntity entity);
    ICollection<TEntity> AddRange(ICollection<TEntity> entities);
    TEntity Update(TEntity entity);
    ICollection<TEntity> UpdateRange(ICollection<TEntity> entities);
    TEntity Delete(TEntity entity, bool permanent = false);
    ICollection<TEntity> DeleteRange(ICollection<TEntity> entity,bool permanent=false);
}
