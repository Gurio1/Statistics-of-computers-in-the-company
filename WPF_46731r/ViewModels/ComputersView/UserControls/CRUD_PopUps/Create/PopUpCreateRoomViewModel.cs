using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_46731r.Commands.CRUD;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Computer;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.Views;

namespace WPF_46731r.ViewModels.ComputersView.UserControls.CRUD_PopUps.Create;

public class PopUpCreateRoomViewModel: ViewModelBase
{
    public string ButtonName { get; set; } = "Create";
    public ICommand Command { get; }
    public Room Template { get; set; }

    public PopUpCreateRoomViewModel(IApiClient apiClient,int buildingId,PopUpView popUpCreateBuildingView,ObservableCollection<Building> entities)
    {
        Template = new Room() {BuildingId = buildingId,Computers = new ObservableCollection<Computer>() };
        Command = new AddTreeItemCommand(apiClient,popUpCreateBuildingView,entities);
    }
}