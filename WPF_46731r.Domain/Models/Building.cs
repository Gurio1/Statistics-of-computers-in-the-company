using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_46731r.Domain.Models
{
    public class Building
    {
        public string Name { get; set; }

        public ObservableCollection<Room> Rooms { get; set; }
    }
}
