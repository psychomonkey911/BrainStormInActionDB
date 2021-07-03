using AutoMapper;
using BrainStormInActionDB.Domain.Models;
using BrainStormInActionDB.Domain.Models.Dto;

namespace BrainStormInActionDB.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.VideosId, source => source.MapFrom(source => source.UsersToVideos)) 
                ;

            CreateMap<UsersToVideo, UsersToVideoDto>();

        }
    }
}
