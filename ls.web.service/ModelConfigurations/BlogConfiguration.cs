using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls.web.service.ModelConfigurations
{
    public partial class BlogConfiguration
    {
        partial void BlogConfigurationAppend()
        {
            HasMany(w => w.Comments);
        }
    }
}
