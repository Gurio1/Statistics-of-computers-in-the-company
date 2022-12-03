using WPF_46731r.Domain.Models;

namespace WPF_46731r.ViewModels.ComputerView.UserControls
{
    public class RoomDetailsViewModel: ViewModelBase
    {
        private Room _room;
        public Room Room { get =>_room; set => _room = value; }

        public RoomDetailsViewModel(Room room)
        {
            _room = room;
        }
    }
}
