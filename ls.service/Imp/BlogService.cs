using ls.common;
using ls.context;
using ls.data.models;
using ls.service.Int;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ls.service.Imp
{
    public class BlogService : IBlogService
    {
        public IQueryable<Blog> Blogs { get; set; }
        public IRepository<Blog, int> BlogRepository { get; set; }

        public bool CheckExists(Expression<Func<Blog, bool>> predicate, int id = 0)
        {
            return false;// BlogRepository.CheckExists(predicate, id);
        }

        public OperationResult Add(data.dtos.BlogDto dto)
        {
            Blog blog = dto.MapTo<Blog>();
            BlogRepository.Insert(blog);
            int count = BlogRepository.UnitOfWork.SaveChanges();
            return count > 0 ? new OperationResult(OperationResultType.Success, "添加博客成功") : OperationResult.NoChanged;
        }

        public OperationResult Update(data.dtos.BlogDto dto)
        {
            throw new NotImplementedException();
        }

        public OperationResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
