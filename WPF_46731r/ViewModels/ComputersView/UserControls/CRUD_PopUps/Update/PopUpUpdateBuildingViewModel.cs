using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_46731r.Commands.CRUD;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.Views;

namespace WPF_46731r.ViewModels.ComputersView.UserControls.CRUD_PopUps.Update;

public class PopUpUpdateBuildingViewModel: ViewModelBase
{
    public string ButtonName { get; set; } = "Update";
    public Building Template { get; set; }
    public ICommand Command { get; set; }

    public PopUpUpdateBuildingViewModel(Building building,IApiClient apiClient,PopUpView popUpUpdateView,ObservableCollection<Building> entities)
    {
        Template = new Building(building);
        Command = new UpdateTreeItemCommand(apiClient,popUpUpdateView,entities);
    }
}