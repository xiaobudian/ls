using AutoMapper;
using ls.core;
using ls.web.service.dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls.web.service.models
{
    public class Blog : EntityBase<int>
    {
        [Required]
        public string title { get; set; }

        public DateTime createTime { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
       
    }
}
