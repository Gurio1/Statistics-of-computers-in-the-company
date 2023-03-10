using System.Collections.ObjectModel;
using System.IO;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Computer;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.State.Navigators;
using WPF_46731r.ViewModels.ComputersView.UserControls.CRUD_PopUps.Create;
using WPF_46731r.ViewModels.ComputersView.UserControls.CRUD_PopUps.Update;
using WPF_46731r.Views;

namespace WPF_46731r.Commands
{
    public class OpenPopUpWindowCommand : CommandBase
    {
        private readonly IApiClient _apiClient;
        private readonly WindowNavigator _nav;
        private ObservableCollection<Building> _entities;
        private readonly Operation _operation;

        public OpenPopUpWindowCommand(IApiClient apiClient,WindowNavigator nav,ObservableCollection<Building> entities,Operation operation)
        {
            _apiClient = apiClient;
            _nav = nav;
            _entities = entities;
            _operation = operation;
        }

        public override void Execute(object? parameter)
        {
            switch (_operation)
            {
                case Operation.Add:
                {
                    if (parameter is Room roomToAddComp)
                    {
                        var popUpWindowView = new PopUpComputerView()
                        {
                            Title = "Add computer window",
                            Owner = _nav.CurrentView
                        };
                        popUpWindowView.DataContext = new PopUpCreateComputerViewModel(_apiClient,roomToAddComp.Id,popUpWindowView,_entities);
                        popUpWindowView.ShowDialog();
                    }
                    else if (parameter is Building buildingToAddRoom)
                    {
                        var popUpWindowView = new PopUpView()
                        {
                            Title = "Add room window",
                            Owner = _nav.CurrentView
                        };
                        popUpWindowView.DataContext = new PopUpCreateRoomViewModel(_apiClient,buildingToAddRoom.Id,popUpWindowView,_entities);
                        popUpWindowView.ShowDialog();
                    }
                    break;
                }
                case Operation.Update:
                    if (parameter is Computer updateComp)
                    {
                        var updateWindowView = new PopUpComputerView()
                        {
                            Title = "Update computer window",
                            Owner = _nav.CurrentView
                        };
                        updateWindowView.DataContext = new PopUpUpdateComputerViewModel(_apiClient,updateComp,updateWindowView,_entities);
                        updateWindowView.ShowDialog();
                    }
                    else if (parameter is Room updateRoom)
                    {
                        var updateWindowView = new PopUpView()
                        {
                            Title = "Update room window",
                            Owner = _nav.CurrentView
                        };
                        updateWindowView.DataContext = new PopUpUpdateRoomViewModel(updateRoom,_apiClient,updateWindowView,_entities);
                        updateWindowView.ShowDialog();
                    }
                    else if (parameter is Building updateBuilding)
                    {
                        var updateWindowView = new PopUpView()
                        {
                            Title = "Update building window",
                            Owner = _nav.CurrentView
                        };
                        updateWindowView.DataContext = new PopUpUpdateBuildingViewModel(updateBuilding,_apiClient,updateWindowView,_entities);
                        updateWindowView.ShowDialog();
                    }
                    
                    break;
                case Operation.AddBuilding:
                {
                    if (parameter is Building building)
                    {
                        var popUpWindowView = new PopUpView()
                        {
                            Title = "Add building window",
                            Owner = _nav.CurrentView
                        };
                        popUpWindowView.DataContext = new PopUpCreateBuildingViewModel(_apiClient,popUpWindowView,_entities);
                        popUpWindowView.ShowDialog();
                    }
                    break;
                }
            }
        }
    }

    public enum Operation
    {
        Add,
        Update,
        AddBuilding
    }
}
