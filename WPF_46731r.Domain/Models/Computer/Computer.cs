using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WPF_46731r.Domain.Models.Abstractions;

namespace WPF_46731r.Domain.Models.Computer
{
    public class Computer : BaseEntity,ITreeItem
    {
        public Computer()
        {
            
        }

        public Computer(Computer computer)
        {
            Id = computer.Id;
            InventoryNumber = computer.InventoryNumber;
            HostName = computer.HostName;
            Mac = computer.Mac;
            State = computer.State;
            Characteristics = new Characteristics(computer.Characteristics);
            LastChecked = new CheckedOn(computer.LastChecked);
            LastModified = new ModifiedOn(computer.LastModified);
            RoomId = computer.RoomId;
            ComputerCharacteristicsId = computer.ComputerCharacteristicsId;
        }
        public int InventoryNumber { get; set; }
        public string HostName { get; set; }
        public string Mac { get; set; }
        public State State { get; set; }
        
        public int RoomId { get;set; }
        public int ComputerCharacteristicsId { get; set; }
        
        public Characteristics Characteristics { get; set; }
        public CheckedOn LastChecked { get; set; }
        public ModifiedOn LastModified { get; set; }
        public List<string> ComputerComments { get; set; }
        
        public virtual ICollection<CheckedOn>? CheckedOn { get; set; }
        public virtual ICollection<ModifiedOn>? ModifiedOn { get; set; }
        
        public bool IsExpanded { get; set; }
        public bool IsSelected { get; set; }
    }
    
    public enum State
    {
        Working,
        InService,
        DoesNotWork,
        NeedAnInspection
    }


}
