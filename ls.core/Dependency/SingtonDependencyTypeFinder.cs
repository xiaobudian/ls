using System;
using System.Linq;
using System.Reflection;

namespace ls.core
{
    /// <summary>
    /// <see cref="ISingletonDependency"/>接口实现类查找器
    /// </summary>
    public class SingletonDependencyTypeFinder : ITypeFinder
    {
        /// <summary>
        /// 初始化一个<see cref="SingletonDependencyTypeFinder"/>类型的新实例
        /// </summary>
        public SingletonDependencyTypeFinder()
        {
            AssemblyFinder = new CurrentDomainAssemblyFinder();
        }

        /// <summary>
        /// 获取或设置 程序集查找器
        /// </summary>
        public IAssemblyFinder AssemblyFinder { get; set; }

        /// <summary>
        /// 查找指定条件的项
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public Type[] Find(Func<Type, bool> predicate)
        {
            return FindAll().Where(predicate).ToArray();
        }

        /// <summary>
        /// 查找所有项
        /// </summary>
        /// <returns></returns>
        public Type[] FindAll()
        {
            Assembly[] assemblies = AssemblyFinder.FindAll();
            return assemblies.SelectMany(assembly =>
                assembly.GetTypes().Where(type =>
                    typeof(ISingletonDependency).IsAssignableFrom(type) && !type.IsAbstract))
                .Distinct().ToArray();
        }

    }
}