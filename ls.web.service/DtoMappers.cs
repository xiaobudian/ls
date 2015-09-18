using AutoMapper;
using ls.web.service.dtos;
using ls.web.service.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls.web.service
{
   public class DtoMappers
    {
       public static void RegisterDtoMapper()
       {
           Mapper.CreateMap<BlogDto, Blog>();
       }
    }
}
