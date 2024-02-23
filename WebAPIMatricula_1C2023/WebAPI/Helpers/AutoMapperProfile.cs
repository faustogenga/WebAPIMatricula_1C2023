using AutoMapper;
using WebAPI.Entities;
using WebAPI.Models;
namespace WebAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UserModel>();
            CreateMap<RegisterModel, Usuario>();
            CreateMap<UpdateModel, Usuario>();
        }
    }
}