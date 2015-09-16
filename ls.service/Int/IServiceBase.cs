using ls.common;
using ls.data.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ls.service.Int
{
    public interface IServiceBase<TEntity, TDto>
        where TEntity : new()
        where TDto : new()
    {
        IQueryable<TEntity> Entities { get; }
        TDto GetByKey(int id);
        bool CheckExists(Expression<Func<TEntity, bool>> predicate, int id = 0);
        OperationResult Add(TDto dto);
        OperationResult Update(TDto dto);
        OperationResult Delete(int id);
       
    }
}
