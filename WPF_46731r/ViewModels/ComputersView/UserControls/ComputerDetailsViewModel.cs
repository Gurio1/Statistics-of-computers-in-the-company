using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_46731r.Commands;
using WPF_46731r.Commands.CRUD;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Computer;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.State.Navigators;

namespace WPF_46731r.ViewModels.ComputersView.UserControls
{
    public class ComputerDetailsViewModel: ViewModelBase
    {
        public Computer Computer { get =>_computer; set => _computer = value; }
        private Computer _computer;

        public ICommand Update { get; }
        public ICommand Delete { get; }
        public ComputerDetailsViewModel(Computer computer,WindowNavigator windowNav,IApiClient apiClient,ObservableCollection<Building> entities)
        {
            _computer = computer;
            Update = new OpenPopUpWindowCommand(apiClient,windowNav,entities,Operation.Update);
            Delete = new DeleteTreeItemCommand(apiClient,entities);
        }
        
    }
}
