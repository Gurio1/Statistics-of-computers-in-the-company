using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities;
using API_46731r.Domain.Entities.ComputerState;
using AutoMapper;

namespace API_46731r.Contracts.Profiles
{
    public class ComputerProfile : Profile
    {
        public ComputerProfile()
        {
            CreateMap<Domain.Entities.Computer, ComputerDTO>();


            CreateMap<ComputerCheckedOn, CheckedOnDTO>()
                .ForMember(dest => dest.CheckedOn,
                           opt => opt.MapFrom(src => src.CheckedOn))
                .ForMember(dest => dest.CheckedBy,
                           opt => opt.MapFrom(src => src.CheckedBy.Email));

            CreateMap<ComputerModifiedOn, ModifiedOnDTO>()
                .ForMember(dest => dest.CheckedOn,
                           opt => opt.MapFrom(src => src.CheckedOn))
                .ForMember(dest => dest.CheckedBy,
                           opt => opt.MapFrom(src => src.CheckedBy.Email))
                .ForMember(dest => dest.Log,
                           opt => opt.MapFrom(src => src.Log));

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
