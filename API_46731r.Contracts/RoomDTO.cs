using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities;

namespace API_46731r.Contracts
{
    public class RoomDTO
    {
        public string Name { get; set; }


        public virtual ICollection<ComputerDTO> Computers { get; set; }
    }
}
