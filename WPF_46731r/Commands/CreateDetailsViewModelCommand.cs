using System;
using System.Collections.Generic;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Abstractions;
using WPF_46731r.Domain.Models.Computer;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.State.Navigators;
using WPF_46731r.ViewModels.ComputersView;
using WPF_46731r.ViewModels.ComputersView.UserControls;

namespace WPF_46731r.Commands;

public class CreateDetailsViewModelCommand : CommandBase
{
    private delegate void Action();
    private readonly Dictionary<Type, Action> _handlers = new ();
    private readonly ITreeItem _entity;

    public CreateDetailsViewModelCommand(ComputersViewModel computersViewModel,ITreeItem entity,WindowNavigator windowNavigator,IApiClient apiClient)
    {
        var computersViewModel1 = computersViewModel;
        _entity = entity;
        _handlers.Add(typeof(Computer), () =>
        {
            computersViewModel1.CurrentUserControlViewModel = new ComputerDetailsViewModel((_entity as Computer)!, windowNavigator,apiClient,computersViewModel.Buildings);
        });
        _handlers.Add(typeof(Room), () =>
        {
            computersViewModel1.CurrentUserControlViewModel = new RoomDetailsViewModel((_entity as Room)!, windowNavigator,apiClient,computersViewModel.Buildings);
        });
        _handlers.Add(typeof(Building), () =>
        {
            computersViewModel1.CurrentUserControlViewModel = new BuildingDetailsViewModel((_entity as Building)!, windowNavigator,apiClient,computersViewModel.Buildings);
        });
    }
    
    public override void Execute(object? parameter)
    {
        var itemType = _entity.GetType();
        _handlers[itemType]();
    }
    
    
}