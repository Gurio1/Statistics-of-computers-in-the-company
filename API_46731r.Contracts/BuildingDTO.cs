﻿using API_46731r.Domain.Entities;

namespace API_46731r.Contracts
{
    public class BuildingDTO
    {
        public string Name { get; set; }

        public virtual ICollection<RoomDTO> Rooms { get; set; }
    }
}
