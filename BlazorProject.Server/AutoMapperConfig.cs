using AutoMapper;

using Models = BlazorProject.Server.Models;
using DTO = BlazorProject.Shared.DTO;

namespace BlazorProject.Server
{
    public class AutoMapperConfig
    {
        public static IMapper CreateMapping<T,U>()
        {
            return new MapperConfiguration(cfg => {
                cfg.CreateMap<T, U>();
                cfg.CreateMap<U, T>();
            }).CreateMapper();
        }
    }
}
