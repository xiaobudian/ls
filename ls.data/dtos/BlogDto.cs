using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls.data.dtos
{
    public class BlogDto
    {
        //[Required(ErrorMessage = "*标题不能为空！")]
        [Description("标题")]
        [Display(Name = "标题")]
        public string title { get; set; }
    }
}
