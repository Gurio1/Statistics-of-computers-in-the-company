using System.Collections.ObjectModel;

namespace WPF_46731r.Domain.Models
{
    public class Room
    {
        public string Name { get; set; }

        public ObservableCollection<Computer.Computer> Computers { get; set; }
    }
}
