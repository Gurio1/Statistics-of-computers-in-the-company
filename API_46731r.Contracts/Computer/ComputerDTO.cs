using API_46731r.Domain.Entities;

namespace API_46731r.Contracts.Computer
{
    public class ComputerDTO
    {
        public int InventoryNumber { get; set; }
        public string HostName { get; set; }
        public string MAC { get; set; }
        public string State { get; set; }

        public ComputerCharacterisiticsDTO Characteristics { get; set; }
        public  ICollection<CheckedOnDTO> CheckedOn { get; set; }
        public  ICollection<ModifiedOnDTO> ModifiedOn { get; set; }
        public  ICollection<ComputerCommentsDTO>? ComputerComments { get; set; }
    }
}
