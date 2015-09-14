using ls.common;
using ls.data.dtos;
using ls.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ls.service.Int
{
    public interface IBlogService
    {
        IQueryable<Blog> Blogs { get; set; }
        bool CheckExists(Expression<Func<Blog, bool>> predicate, int id = 0);
        OperationResult Add(BlogDto dto);
        OperationResult Update(BlogDto dto);
        OperationResult Delete(int id);
    }
}
