using ls.common;
using ls.core;
using ls.web.service.dtos;
using ls.web.service.models;
using ls.web.service.query;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ls.web.service.Int
{
    public interface IBlogService : ILifetimeScopeDependency, IServiceBase<Blog, BlogDto>
    {
        IPagedList<BlogDto> QueryData(BlogQueryInfo bqi);

        void TestTransactionScope();
    }
}
