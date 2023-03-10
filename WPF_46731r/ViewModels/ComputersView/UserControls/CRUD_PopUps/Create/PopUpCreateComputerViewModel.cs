using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WPF_46731r.Commands.CRUD;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Computer;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.Views;

namespace WPF_46731r.ViewModels.ComputersView.UserControls.CRUD_PopUps.Create;

public class PopUpCreateComputerViewModel: ViewModelBase
{
    public string ButtonName { get; set; } = "Create";
    public Computer ComputerTemplate { get =>_computerTemplate; set { _computerTemplate = value; OnPropretyChanged(nameof(ComputerTemplate)); } }

    private Computer _computerTemplate;
    public ICommand Command { get; }
    public ObservableCollection<Domain.Models.Computer.State> EnumValues { get; set; }

    public PopUpCreateComputerViewModel(IApiClient apiClient,int roomId,PopUpComputerView popUpCreateComputerView,ObservableCollection<Building> entities)
    {
        _computerTemplate = new Computer(){RoomId = roomId,Characteristics = new Characteristics()};
        Command = new AddTreeItemCommand(apiClient,popUpCreateComputerView,entities);
        EnumValues = new ObservableCollection<Domain.Models.Computer.State>(Enum.GetValues(typeof(Domain.Models.Computer.State)).Cast<Domain.Models.Computer.State>());
    }
}