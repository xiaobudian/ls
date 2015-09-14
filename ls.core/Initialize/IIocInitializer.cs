using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls.core
{
    /// <summary>
    /// 定义依赖注入初始化器，从程序集中反射进行依赖注入接口与实现的注册
    /// </summary>
    public interface IIocInitializer
    {
        /// <summary>
        /// 初始化依赖注入
        /// </summary>
        /// <param name="config">框架配置信息</param>
        void Initialize();
    }
}