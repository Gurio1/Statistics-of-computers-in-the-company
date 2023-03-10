using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities;
using API_46731r.Domain.Entities.ComputerState;
using AutoMapper;

namespace API_46731r.Contracts.Profiles
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<Building, BuildingDTO>();
   

            CreateMap<Room, RoomDTO>();
   

            CreateMap<Domain.Entities.Computer, ComputerDTO>();

            CreateMap<List<ComputerCheckedOn>, CheckedOnDTO>()
                .ForMember(dest => dest.CheckedOn,
                           opt => opt.MapFrom(src => src.First().CheckedOn))
                .ForMember(dest => dest.CheckedBy,
                           opt => opt.MapFrom(src => src.First().CheckedBy.Email));

            CreateMap<List<ComputerModifiedOn>, ModifiedOnDTO>()
                .ForMember(dest => dest.CheckedOn,
                           opt => opt.MapFrom(src => src.First().CheckedOn))
                .ForMember(dest => dest.CheckedBy,
                           opt => opt.MapFrom(src => src.First().CheckedBy.Email));

            CreateMap<ComputerComments, ComputerCommentsDTO>()
                .ForMember(dest => dest.PostedOn,
                           opt => opt.MapFrom(src => src.PostedOn))
                .ForMember(dest => dest.UserName,
                           opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Content,
                           opt => opt.MapFrom(src => src.Content));
        }
    }
}
