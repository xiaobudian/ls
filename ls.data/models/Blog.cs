using ls.context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls.data.models
{
    public class Blog : EntityBase<int>
    {
        [Required]
        public string title { get; set; }

        public DateTime createTime { get; set; }
    }
}
