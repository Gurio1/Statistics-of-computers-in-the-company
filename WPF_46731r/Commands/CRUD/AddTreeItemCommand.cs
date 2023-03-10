using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Computer;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.Views;

namespace WPF_46731r.Commands.CRUD;

public class AddTreeItemCommand: CommandBase
{
    private readonly IApiClient _apiClient;
    private readonly Window _view;
    private  ObservableCollection<Building> _entities;

    public AddTreeItemCommand(IApiClient apiClient,Window view,ObservableCollection<Building> entities)
    {
        _apiClient = apiClient;
        _view = view;
        _entities = entities;
    }
    public override async void Execute(object? parameter)
    {
        if (parameter is Computer computer) 
        {
            var result = await _apiClient.CreateAsync(computer);
            if (result is null) return;
            var building = _entities.FirstOrDefault(x => x.Rooms.Any(z => z.Id == computer.RoomId));   
            var room = building.Rooms.FirstOrDefault(y => y.Id == computer.RoomId);
            room.Computers.Add((Computer)result);
            _view.Close();
        }
        else if (parameter is Room room)
        {
            var result = await _apiClient.CreateAsync(room);
            if (result is null) return;
            var building = _entities.FirstOrDefault(r =>r.Id == room.BuildingId);
            building.Rooms.Add((Room)result);
            _view.Close();
        }
        else
        {
            if (parameter is Building building)
            {
                var result = await _apiClient.CreateAsync(building);
                if (result is null) return;
                _entities.Add((Building)result);
                _view.Close();
            }
        }
    }
}