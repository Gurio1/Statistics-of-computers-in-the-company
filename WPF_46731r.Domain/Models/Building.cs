using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_46731r.Domain.Models.Abstractions;

namespace WPF_46731r.Domain.Models
{
    public class Building : BaseEntity, ITreeItem
    {
        public string Name { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }
        public bool IsExpanded { get; set; }
        public bool IsSelected { get; set; }

        public Building()
        {
            
        }

        public Building(Building building)
        {
            Id = building.Id;
            Name = building.Name;
        }
    }
}
