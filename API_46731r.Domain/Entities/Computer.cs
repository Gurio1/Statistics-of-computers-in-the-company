using API_46731r.Domain.Entities.ComputerState;

namespace API_46731r.Domain.Entities
{
    public class Computer : BaseEntity
    {
        public int ComputerCharacteristicsId { get; set; }

        public int InventoryNumber { get; set; }
        public string HostName { get; set; }
        public string MAC { get; set; }
        public State State { get; set; }

        public virtual ComputerCharacteristics Characteristics { get; set; }
        public virtual ICollection<ComputerCheckedOn> CheckedOn { get; set; }
        public virtual ICollection<ComputerModifiedOn> ModifiedOn { get; set; }
        public virtual ICollection<ComputerComments>? ComputerComments { get; set; }
    }

    public enum State
    {
        Working,
        InService,
        DoesNotWork,
        NeedAnInspection
    }
}
