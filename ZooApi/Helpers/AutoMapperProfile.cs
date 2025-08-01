using AutoMapper;
using ZooApi.DTOs;
using ZooApi.Entities;

namespace ZooApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FishDto, Fish>().ReverseMap();
            CreateMap<BirdDto, Bird>().ReverseMap();
        }
    }
}
