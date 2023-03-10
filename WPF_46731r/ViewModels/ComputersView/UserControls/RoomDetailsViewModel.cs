using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_46731r.Commands;
using WPF_46731r.Commands.CRUD;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.State.Navigators;

namespace WPF_46731r.ViewModels.ComputersView.UserControls
{
    public class RoomDetailsViewModel: ViewModelBase
    {
        private Room _room;
        public Room Item { get =>_room; set => _room = value; }

        public int ComputersCount
        {
            get => _room.Computers.Count;
        }
        public ICommand Update { get; }
        public ICommand Delete { get; }
        public RoomDetailsViewModel(Room room,WindowNavigator windowNav,IApiClient apiClient,ObservableCollection<Building> entities)
        {
            _room = room;
            Update = new OpenPopUpWindowCommand(apiClient,windowNav,entities,Operation.Update);
            Delete = new DeleteTreeItemCommand(apiClient,entities);
        }
    }
}
