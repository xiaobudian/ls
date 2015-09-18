using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls.web.service.query
{
    public class QueryInfoBase
    {
        public QueryInfoBase()
        {
            PageIndex = 1;
            PageSize = 20;
            var pageSize = ConfigurationManager.AppSettings["pageSize"];
            if (pageSize != null)
            {
                PageSize = int.Parse(pageSize.ToString());
            }

        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
