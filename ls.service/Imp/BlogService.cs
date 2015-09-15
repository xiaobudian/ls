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
        public IQueryable<Blog> Blogs { get { return BlogRepository.Entities; } }
        public IRepository<Blog, int> BlogRepository { get; set; }

        public bool CheckExists(Expression<Func<Blog, bool>> predicate, int id = 0)
        {
            return false;// BlogRepository.CheckExists(predicate, id);
        }

        public OperationResult Add(data.dtos.BlogDto dto)
        {
            try
            {
                if (dto.title.IsNullOrEmpty() || dto.title.Trim().IsNullOrEmpty())
                {
                    return new OperationResult(OperationResultType.ValidError, "博客标题不能为空！");
                }

                Blog blog = dto.MapTo<Blog>();
                blog.createTime = DateTime.Now;
                BlogRepository.Insert(blog);
                return new OperationResult(OperationResultType.Success, "添加博客成功！");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                //log 记录异常信息
                //返回用户友好的提示
                return new OperationResult(OperationResultType.Error, "添加博客失败！");

            }

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
