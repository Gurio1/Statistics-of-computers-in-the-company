using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_46731r.Commands.CRUD;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.Views;

namespace WPF_46731r.ViewModels.ComputersView.UserControls.CRUD_PopUps.Create;

public class PopUpCreateBuildingViewModel: ViewModelBase
{
    public string ButtonName { get; set; } = "Create";
    public ICommand Command { get; }
    public Building Template { get; set; }

    public PopUpCreateBuildingViewModel(IApiClient apiClient,PopUpView popUpCreateBuildingView,ObservableCollection<Building> entities)
    {
        Template = new Building() { Rooms = new ObservableCollection<Room>() };
        Command = new AddTreeItemCommand(apiClient,popUpCreateBuildingView,entities);
    }
}