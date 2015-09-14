using System;
using System.Linq;
using System.Reflection;


namespace ls.core
{
    /// <summary>
    /// 当前应用程序域程序集查找器
    /// </summary>
    public class CurrentDomainAssemblyFinder : IAssemblyFinder
    {
        /// <summary>
        /// 查找当前应用程序域符合指定条件的程序集
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public Assembly[] Find(Func<Assembly, bool> predicate)
        {
            return FindAll().Where(predicate).ToArray();
        }

        /// <summary>
        /// 获取当前应用程序域所有已加载的程序集
        /// </summary>
        /// <returns></returns>
        public Assembly[] FindAll()
        {
            return AppDomain.CurrentDomain.GetAssemblies().Where(w => w.FullName.StartsWith("ls.")).ToArray();
        }
    }
}