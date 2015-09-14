using ls.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls.data.models
{
    public class Blog : EntityBase<int>
    {
        public string title { get; set; }
    }
}
