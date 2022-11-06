using API_46731r.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Contracts.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDTO>()
                .ForMember(dest => dest.Name,
                           opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Computers,
                           opt => opt.MapFrom(src => src.Computers));
        }
    }
}
