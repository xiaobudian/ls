using ls.context;
using ls.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls.data.ModelConfigurations
{
    public partial class BlogConfiguration : EntityConfigurationBase<Blog, Int32>
    {
        /// <summary>
        /// 初始化一个<see cref="UserConfiguration"/>类型的新实例
        /// </summary>
        public BlogConfiguration()
        {
            BlogConfigurationAppend();
        }

        /// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void BlogConfigurationAppend();
    }
}
