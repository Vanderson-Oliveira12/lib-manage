using AutoMapper;
using LibManage.Models;

namespace LibManage.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, ResponseBookDTO>().ReverseMap();
            CreateMap<User, ResponseUserDTO>().ReverseMap();    
        }
    }
}
