using ls.context;
using ls.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls.data.ModelConfigurations
{
    public partial class CommentConfiguration: EntityConfigurationBase<Comment, Int32>
    {
        public CommentConfiguration()
        {
            CommentConfigurationAppend();
        }

        /// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void CommentConfigurationAppend();
    }
}
