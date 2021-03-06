﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ls.core;
using ls.web.core;

namespace ls.web.core
{
    /// <summary>
    /// 数据上下文类型获取器
    /// </summary>
    public class DbContextTypeResolver : IDbContextTypeResolver
    {
        /// <summary>
        /// 获取或设置 依赖注入实例获取器
        /// </summary>
        public IIocResolver IocResolver { get; set; }

        /// <summary>
        /// 由实体类型获取关联的上下文类型
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">实体主键类型</typeparam>
        /// <returns></returns>
        public IUnitOfWork Resolve<TEntity, TKey>() where TEntity : IEntity<TKey>
        {
            return Resolve(typeof(TEntity));
        }

        /// <summary>
        /// 由实体类型获取关联的上下文类型
        /// </summary>
        /// <param name="entityType">实体类型</param>
        /// <returns></returns>
        public IUnitOfWork Resolve(Type entityType)
        {
            entityType.CheckNotNull("entityType" );
            Type contextType = DbContextManager.Instance.GetDbContexType(entityType);
            IUnitOfWork unitOfWork = (IUnitOfWork)IocResolver.Resolve(contextType);
            if (unitOfWork == null)
            {
                throw new InvalidOperationException("实体类“{0}”所属的上下文“{1}”获取失败".FormatWith(entityType, contextType));
            }
            return unitOfWork;
        }
    }
}