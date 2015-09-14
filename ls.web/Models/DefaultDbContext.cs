﻿using ls.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ls.web.Models
{
    /// <summary>
    /// 默认 EntityFramework 数据上下文
    /// </summary>
    public class DefaultDbContext : DbContextBase<DefaultDbContext>
    {
        /// <summary>
        /// 初始化一个<see cref="DefaultDbContext"/>类型的新实例
        /// </summary>
        public DefaultDbContext()
        { }

        /// <summary>
        /// 初始化一个<see cref="DefaultDbContext"/>类型的新实例
        /// </summary>
        //public DefaultDbContext(string nameOrConnectionString)
        //    : base(nameOrConnectionString)
        //{ }

    }
}