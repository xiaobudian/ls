using ls.common;
using ls.core;
using ls.web.service.dtos;
using ls.web.service.Int;
using ls.web.service.models;
using ls.web.service.query;
using PagedList;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace ls.web.service.Imp
{
    public class BlogService : IBlogService
    {
        public IQueryable<Blog> Entities { get { return BlogRepository.Entities; } }
        public IRepository<Blog, int> BlogRepository { get; set; }

        public bool CheckExists(Expression<Func<Blog, bool>> predicate, int id = 0)
        {
            return false;// BlogRepository.CheckExists(predicate, id);
        }

        public OperationResult Add(BlogDto dto)
        {
            try
            {
                var validate = Validate(dto);
                if (validate != null)
                    return validate;

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


        public OperationResult Update(BlogDto dto)
        {
            try
            {
                var validate = Validate(dto);
                if (validate != null)
                    return validate;


                Blog blog = BlogRepository.GetById(dto.id);
                if (blog == null)
                {
                    return new OperationResult(OperationResultType.QueryNull);
                }
                blog = dto.MapTo(blog);
                BlogRepository.Update(blog);
                return new OperationResult(OperationResultType.Success, "更新博客成功！");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                //log 记录异常信息
                //返回用户友好的提示
                return new OperationResult(OperationResultType.Error, "更新博客失败！");

            }
        }

        private OperationResult Validate(BlogDto dto)
        {
            if (dto.title.IsNullOrEmpty() || dto.title.Trim().IsNullOrEmpty())
            {
                return new OperationResult(OperationResultType.ValidError, "博客标题不能为空！");
            }
            return null;
        }

        public OperationResult Delete(int id)
        {
            try
            {
                Blog blog = BlogRepository.GetById(id);
                if (blog == null)
                {
                    return new OperationResult(OperationResultType.QueryNull);
                }
                BlogRepository.Delete(blog);
                return new OperationResult(OperationResultType.Success, "删除博客成功！");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                //log 记录异常信息
                //返回用户友好的提示
                return new OperationResult(OperationResultType.Error, "删除博客失败！");

            }
        }


        public BlogDto GetByKey(int id)
        {
            var blog = this.Entities.FirstOrDefault(w => w.Id == id);
            if (blog != null)
            {
                var dto = new BlogDto()
                {
                    id = blog.Id,
                    title = blog.title
                };
                return dto;
            }
            return null;
        }

        public IPagedList<BlogDto> QueryData(BlogQueryInfo bqi)
        {
            var query = this.Entities;
            if (bqi.title != null && !bqi.title.Trim().IsNullOrEmpty())
            {
                query = query.Where(w => w.title.Contains(bqi.title));
            }

            var dtoQuery = query.OrderBy(w => w.Id)
                  .Select(w => new BlogDto
                  {
                      id = w.Id,
                      title = w.title
                  });
            return dtoQuery.ToPagedList(bqi.PageIndex, bqi.PageSize);
        }

        public void TestTransactionScope()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                for (int i = 0; i < 3; i++)
                {
                    Add(new BlogDto { title = new Random().Next() * 100 + i.ToString() });
                    if (i == 2)
                    {
                        //throw new Exception();
                    }
                }
                //ts.Complete();
            }
        }
    }
}
