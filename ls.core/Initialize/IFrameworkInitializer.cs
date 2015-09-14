using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ls.core
{
    /// <summary>
    /// 框架初始化接口
    /// </summary>
    public interface IFrameworkInitializer
    {
        /// <summary>
        /// 开始初始化
        /// </summary>
        void Initialize();
    }
}