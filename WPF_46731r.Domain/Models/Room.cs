using System.Collections.ObjectModel;
using WPF_46731r.Domain.Models.Abstractions;

namespace WPF_46731r.Domain.Models
{
    public class Room : BaseEntity,ITreeItem
    {
        public int BuildingId { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Computer.Computer> Computers { get; set; }
        public bool IsExpanded { get; set; }
        public bool IsSelected { get; set; }

        public Room()
        {
            
        }

        public Room(Room room)
        {
            Id = room.Id;
            BuildingId = room.BuildingId;
            Name = room.Name;
        }
    }
}
