using ls.common;
using ls.core;
using ls.data.dtos;
using ls.data.models;
using ls.data.query;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ls.web.Int
{
    public interface IBlogService : ILifetimeScopeDependency, IServiceBase<Blog, BlogDto>
    {
        IPagedList<BlogDto> QueryData(BlogQueryInfo bqi);
    }
}
