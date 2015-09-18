using ls.core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;

namespace ls.web.core
{
    /// <summary>
    /// 数据库初始化器，从程序集中反射实体映射类并加载到相应上下文类中，进行上下文类型的初始化
    /// </summary>
    public class DatabaseInitializer : IDatabaseInitializer
    {
        /// <summary>
        /// 初始化一个<see cref="DatabaseInitializer"/>类型的新实例
        /// </summary>
        public DatabaseInitializer()
        {
            MapperAssemblyFinder = new EntityMapperAssemblyFinder();
        }

        /// <summary>
        /// 获取或设置 实体映射程序集查找器
        /// </summary>
        public IAssemblyFinder MapperAssemblyFinder { get; set; }

        /// <summary>
        /// 开始初始化数据库
        /// </summary>
        /// <param name="config">数据库配置信息</param>
        public virtual void Initialize()
        {
            //没有上下文，添加默认上下文
            //if (!config.ContextConfigs.Any())
            //{
            //    DbContextConfig contextConfig = GetDefaultDbContextConfig();
            //    config.ContextConfigs.Add(contextConfig);
            //}
            //如果业务上下文存在开启数据日志功能，并且日志上下文没有设置，则添加日志上下文
            //if (config.ContextConfigs.All(m => m.ContextType != typeof(LoggingDbContext)))
            //{
            //    DbContextConfig contextConfig = GetLoggingDbContextConfig();
            //    config.ContextConfigs.Add(contextConfig);
            //}
            //foreach (DbContextConfig contextConfig in config.ContextConfigs)
            //{
            DbContextInit();
            //}
        }

        /// <summary>
        /// 获取默认业务上下文配置信息
        /// </summary>
        /// <returns></returns>
        //protected virtual DbContextConfig GetDefaultDbContextConfig()
        //{
        //    return new DbContextConfig()
        //    {
        //        ConnectionStringName = "default",
        //        ContextType = typeof(DefaultDbContext),
        //        InitializerConfig = new DbContextInitializerConfig()
        //        {
        //            InitializerType = typeof(DefaultDbContextInitializer),
        //            EntityMapperAssemblies = MapperAssemblyFinder.FindAll()
        //        }
        //    };
        //}

        /// <summary>
        /// 获取默认日志上下文配置信息
        /// </summary>
        /// <returns></returns>
        //protected virtual DbContextConfig GetLoggingDbContextConfig()
        //{
        //    return new DbContextConfig()
        //    {
        //        ConnectionStringName = "default",
        //        ContextType = typeof(LoggingDbContext),
        //        InitializerConfig = new DbContextInitializerConfig()
        //        {
        //            InitializerType = typeof(LoggingDbContextInitializer),
        //            EntityMapperAssemblies = { typeof(LoggingDbContext).Assembly }
        //        }
        //    };
        //}

        /// <summary>
        /// 初始化数据上下文
        /// </summary>
        /// <param name="config">数据上下文配置信息</param>
        private static void DbContextInit()
        {
            DbContextInitializerBase initializer = CreateInitializer();
            DbContextManager.Instance.RegisterInitializer(typeof(DefaultDbContext), initializer);
        }

        private static DbContextInitializerBase CreateInitializer()
        {
            DbContextInitializerBase initializer = new DefaultDbContextInitializer() as DbContextInitializerBase;
            //if (initializer == null)
            //{
            //    throw new InvalidOperationException("类型“{0}”不是有效的上下文初始化类型");
            //}
            //ICollection<Assembly> EntityMapperAssemblies = null;
            //string[] mapperFiles = "ls.context".Split(',');
            //var a = mapperFiles.Select(fileName => fileName.EndsWith(".dll") ? fileName : fileName + ".dll");
            //var b = a.Select(fileName => Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath, fileName)).ToArray();
            //EntityMapperAssemblies = //b.Select(Assembly.LoadFrom).ToList();
            //var a = AppDomain.CurrentDomain.GetAssemblies();
            //var b = a.SelectMany(assembly => assembly.GetTypes().Where(type => typeof(IEntityMapper).IsAssignableFrom(type) && !type.IsAbstract));
            //EntityMapperAssemblies = b.Select(Assembly.LoadFrom).ToList();
            //foreach (Assembly mapperAssembly in EntityMapperAssemblies)
            //{
            //    if (initializer.MapperAssemblies.Contains(mapperAssembly))
            //    {
            //        continue;
            //    }
            //    initializer.MapperAssemblies.Add(mapperAssembly);
            //}

            return initializer;
        }
    }
}