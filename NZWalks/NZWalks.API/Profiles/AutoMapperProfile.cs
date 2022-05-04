using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;

namespace NZWalks.API.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region, RegionDto>();
            CreateMap<AddRegionRequest, Region>();
            CreateMap<UpdateRegionRequest, Region>();
        }
    }
}
