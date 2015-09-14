using AutoMapper;
using ls.data.dtos;
using ls.data.models;

namespace ls.data
{
    /// <summary>
    /// 
    /// </summary>
    public class DtoMappers
    {
        /// <summary>
        /// 
        /// </summary>
        public static void MapperRegister()
        {
            Mapper.CreateMap<BlogDto, Blog>();
        }
    }
}