using API_46731r.Domain.Entities.ComputerState;

namespace API_46731r.Contracts.Computer
{
    public class ComputerDTO
    {
        public int InventoryNumber { get; set; }
        public string HostName { get; set; }
        public string MAC { get; set; }
        public string State { get; set; }

        public ComputerCharacterisiticsDTO Characteristics { get; set; }
        public CheckedOnDTO LastChecked => CheckedOn.FirstOrDefault();
        public  ModifiedOnDTO LastModified => ModifiedOn.FirstOrDefault();
        public  ICollection<ComputerCommentsDTO>? ComputerComments { get; set; }

        public virtual ICollection<CheckedOnDTO> CheckedOn { get; set; }
        public virtual ICollection<ModifiedOnDTO> ModifiedOn { get; set; }
    }
}
