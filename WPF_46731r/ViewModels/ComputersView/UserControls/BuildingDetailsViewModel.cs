using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WPF_46731r.Commands;
using WPF_46731r.Commands.CRUD;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.State.Navigators;

namespace WPF_46731r.ViewModels.ComputersView.UserControls
{
    public class BuildingDetailsViewModel : ViewModelBase
    {
        private Building _building;
        public Building Item  { get=>_building; set => _building = value; }
        public int ComputersCount
        {
            get => _building.Rooms.Sum(c =>c.Computers.Count);
        }
        
        public ICommand Update { get; }
        public ICommand Delete { get; }
        public BuildingDetailsViewModel(Building building,WindowNavigator windowNav,IApiClient apiClient,ObservableCollection<Building> entities)
        {
            _building = building;
            Update = new OpenPopUpWindowCommand(apiClient,windowNav,entities,Operation.Update);
            Delete = new DeleteTreeItemCommand(apiClient,entities);
        }
    }
}
