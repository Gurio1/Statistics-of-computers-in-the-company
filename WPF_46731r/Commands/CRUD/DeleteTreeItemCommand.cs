using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Computer;
using WPF_46731r.Domain.Service.Abstractions;

namespace WPF_46731r.Commands.CRUD;

public class DeleteTreeItemCommand : CommandBase
{
    private readonly IApiClient _apiClient;
    private readonly ObservableCollection<Building> _items;

    public DeleteTreeItemCommand(IApiClient apiClient,ObservableCollection<Building> items)
    {
        _apiClient = apiClient;
        _items = items;
    }
    public override async void Execute(object? parameter)
    {
        var result = MessageBox.Show($"Do you want to delete this object?",
            "Delete tree item", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        
        if (result != MessageBoxResult.Yes) return;
        
        if (parameter is not BaseEntity treeItem) return;
        
        var deleteResult = await _apiClient.DeleteAsync(treeItem);
        if (!deleteResult) return;
        
        switch (treeItem)
        {
            case Computer computer:
            {
                var test = _items.SelectMany(r =>r.Rooms).First(c => c.Computers.Contains(computer)).Computers.Remove(computer);
                break;
            }
            case Room room:
                _items.First(c => c.Rooms.Contains(room)).Rooms.Remove(room);
                break;
            case Building building:
                _items.Remove(building);
                break;
        }
    }
}