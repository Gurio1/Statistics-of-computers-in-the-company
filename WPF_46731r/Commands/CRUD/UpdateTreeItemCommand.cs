using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Abstractions;
using WPF_46731r.Domain.Models.Computer;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.Views;

namespace WPF_46731r.Commands.CRUD;

public class UpdateTreeItemCommand : CommandBase
{
    private readonly IApiClient _apiClient;
    private readonly Window _view;
    private ObservableCollection<Building> _entities;

    public UpdateTreeItemCommand(IApiClient apiClient,Window view,ObservableCollection<Building> entities)
    {
        _apiClient = apiClient;
        _view = view;
        _entities = entities;
    }
    public override async void Execute(object? parameter)
    {
        if (parameter is Computer item) 
        {
            var result = await _apiClient.UpdateAsync(item);
            if (result)
            {
                var building = _entities.FirstOrDefault(x => x.Rooms.Any(y => y.Computers.Any(z => z.Id == item.Id)));   
                var room = building.Rooms.FirstOrDefault(x => x.Computers.Any(y => y.Id == item.Id));
                var computerOld = room.Computers.FirstOrDefault(x => x.Id == item.Id);
                room.Computers.Remove(computerOld);
                room.Computers.Add(item);
                _view.Close();
            }
        }
        else if (parameter is Room room)
        {
            var result = await _apiClient.UpdateAsync(room);
            if (result)
            {
                var building = _entities.FirstOrDefault(x => x.Rooms.Any(y => y.Id == room.Id)); 
                var roomOld = _entities.Select(b => b.Rooms.FirstOrDefault(r => r.Id == room.Id)).FirstOrDefault();
                roomOld.Name = room.Name;
                _view.Close();
            }
        }
        else if (parameter is Building building)
        {
            var result = await _apiClient.UpdateAsync(building);
            if (result)
            {
                var buildingOld = _entities.FirstOrDefault(b => b.Id == building.Id);
                buildingOld.Name = building.Name;
                _view.Close();
            }
        }
    }
}