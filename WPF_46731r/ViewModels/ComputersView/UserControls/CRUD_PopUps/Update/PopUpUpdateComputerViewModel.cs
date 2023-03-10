using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WPF_46731r.Commands.CRUD;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Computer;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.Views;

namespace WPF_46731r.ViewModels.ComputersView.UserControls.CRUD_PopUps.Update
{
    public class PopUpUpdateComputerViewModel : ViewModelBase
    {
        public string ButtonName { get; set; } = "Update";
        public Computer ComputerTemplate { get =>_computerTemplate; set { _computerTemplate = value; OnPropretyChanged(nameof(ComputerTemplate)); } }

        private Computer _computerTemplate;
        public ICommand Command { get; }
        public ObservableCollection<Domain.Models.Computer.State> EnumValues { get; set; }

        public PopUpUpdateComputerViewModel(IApiClient apiClient,Computer computer,PopUpComputerView popUpUpdateComputerView,ObservableCollection<Building> entities)
        {
            _computerTemplate = new Computer(computer);
            Command = new UpdateTreeItemCommand(apiClient,popUpUpdateComputerView,entities);
            EnumValues = new ObservableCollection<Domain.Models.Computer.State>(Enum.GetValues(typeof(Domain.Models.Computer.State)).Cast<Domain.Models.Computer.State>());
        }
        
    }
}
