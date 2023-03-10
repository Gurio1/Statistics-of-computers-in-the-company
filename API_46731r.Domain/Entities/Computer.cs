using API_46731r.Domain.Entities.ComputerState;

namespace API_46731r.Domain.Entities
{
    public class Computer : BaseEntity
    {
        public int InventoryNumber { get; set; }
        public string HostName { get; set; }
        public string Mac { get; set; }
        public State State { get; set; }

        public int RoomId { get;set; }
        public int ComputerCharacteristicsId { get; set; }

        public virtual ComputerCharacteristics Characteristics { get; set; }
        public virtual List<ComputerCheckedOn>? CheckedOn { get; set; }
        public virtual List<ComputerModifiedOn>? ModifiedOn { get; set; }
        public virtual List<ComputerComments>? ComputerComments { get; set; }
    }

    public enum State
    {
        Working,
        InService,
        DoesNotWork,
        NeedAnInspection
    }
}
