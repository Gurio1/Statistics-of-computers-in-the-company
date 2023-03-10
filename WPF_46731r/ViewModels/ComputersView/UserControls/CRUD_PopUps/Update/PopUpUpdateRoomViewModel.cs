using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_46731r.Commands.CRUD;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Computer;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.Views;

namespace WPF_46731r.ViewModels.ComputersView.UserControls.CRUD_PopUps.Update;

public class PopUpUpdateRoomViewModel: ViewModelBase
{
    public string ButtonName { get; set; } = "Update";
    public Room Template { get; set; }
    public ICommand Command { get; }

    public PopUpUpdateRoomViewModel(Room room,IApiClient apiClient,PopUpView popUpUpdateView,ObservableCollection<Building> entities)
    {
        Template = new Room(room);
        Command = new UpdateTreeItemCommand(apiClient,popUpUpdateView,entities);
    }

}