using API_46731r.Domain.Entities;
using API_46731r.Domain.Entities.ComputerState;

namespace API_46731r.Contracts.Computer
{
    public class ComputerDTO
    {
        public int Id { get; set; }
        public int InventoryNumber { get; set; }
        public string HostName { get; set; }
        public string MAC { get; set; }
        public State State { get; set; }

        public int RoomId { get;set; }
        public int ComputerCharacteristicsId { get; set; }
        
        public ComputerCharacteristics Characteristics { get; set; }
        public CheckedOnDTO? LastChecked => CheckedOn.FirstOrDefault();
        public  ModifiedOnDTO? LastModified => ModifiedOn.FirstOrDefault();
        public  ICollection<ComputerCommentsDTO>? ComputerComments { get; set; }

        public  ICollection<CheckedOnDTO> CheckedOn { get; set; }
        public  ICollection<ModifiedOnDTO> ModifiedOn { get; set; }
    }
}
