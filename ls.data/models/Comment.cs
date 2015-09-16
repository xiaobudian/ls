using ls.context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls.data.models
{
    public class Comment : EntityBase<int>
    {
        [Required]
        public string content { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
