using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ls.core
{
    /// <summary>
    /// 定义数据处理初始化器，反射程序集进行功能信息，实体信息的数据初始化
    /// </summary>
    public interface IDataHandlerInitializer
    {
        /// <summary>
        /// 执行数据处理初始化
        /// </summary>
        void Initialize();
    }
}