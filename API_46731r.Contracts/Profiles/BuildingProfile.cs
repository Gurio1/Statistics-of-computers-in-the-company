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
            CreateMap<Building, BuildingDTO>()
                .ForMember(dest => dest.Name,
                           opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Rooms,
                           opt => opt.MapFrom(src => src.Rooms));

            CreateMap<Room, RoomDTO>()
                .ForMember(dest => dest.Name,
                           opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Computers,
                           opt => opt.MapFrom(src => src.Computers));

            CreateMap<Domain.Entities.Computer, ComputerDTO>()
                .ForMember(dest => dest.HostName,
                           opt => opt.MapFrom(src => src.HostName))
                .ForMember(dest => dest.MAC,
                           opt => opt.MapFrom(src => src.MAC))
                .ForMember(dest => dest.InventoryNumber,
                           opt => opt.MapFrom(src => src.InventoryNumber))
                .ForMember(dest => dest.State,
                           opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.Characteristics,
                           opt => opt.MapFrom(src => src.Characteristics))
                .ForMember(dest => dest.CheckedOn,
                           opt => opt.MapFrom(src => src.CheckedOn))
                .ForMember(dest => dest.ModifiedOn,
                           opt => opt.MapFrom(src => src.ModifiedOn))
                .ForMember(dest => dest.ComputerComments,
                           opt => opt.MapFrom(src => src.ComputerComments));

            CreateMap<ComputerCharacteristics, ComputerCharacterisiticsDTO>();

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
