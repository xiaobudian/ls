using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls.data.ModelConfigurations
{
    public partial class CommentConfiguration
    {
        partial void CommentConfigurationAppend()
        {
            HasRequired(w => w.Blog).WithMany(w => w.Comments);
        }
    }
}
