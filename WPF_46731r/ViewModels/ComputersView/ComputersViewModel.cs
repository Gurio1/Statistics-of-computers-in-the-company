using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_46731r.Commands;
using WPF_46731r.Commands.CRUD;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Abstractions;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.State.Navigators;

namespace WPF_46731r.ViewModels.ComputersView
{
    public class ComputersViewModel : ViewModelBase
    {
        private readonly WindowNavigator _windowNavigator;
        private readonly IApiClient _apiClient;
        private  ITreeItem _selectedItem;
        private ViewModelBase? _currentUserControlViewModel;
        private ICommand _openDetailsViewCommand;
        public ViewModelBase? CurrentUserControlViewModel
        {
            get => _currentUserControlViewModel;
            set
            {
                _currentUserControlViewModel = value;
                OnPropretyChanged(nameof(CurrentUserControlViewModel));
            }
        }

        public ITreeItem? SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value == null) return;
                _selectedItem = value;
                OnPropretyChanged(nameof(SelectedItem));

                _openDetailsViewCommand = new CreateDetailsViewModelCommand(this, value, _windowNavigator,_apiClient);
                _openDetailsViewCommand.Execute(null);
            }
        }

        private ObservableCollection<Building> _buildings;

        public ObservableCollection<Building> Buildings
        {
            get => _buildings;
            set
            {
                _buildings = value;
                OnPropretyChanged(nameof(Buildings));
            }
        }
        
        public ICommand DeleteTreeItem { get; set; }
        public ICommand Update { get; set; }
        public ICommand Add { get; set; }
        public ICommand AddNewBuilding { get; set; }

        public ComputersViewModel(WindowNavigator windowNav, IApiClient apiClient)
        {
            _windowNavigator = windowNav;
            _apiClient = apiClient;
        }

        public void BindDataToTheTree(ObservableCollection<Building> buildings)
        {
            _buildings = buildings;
            DeleteTreeItem = new DeleteTreeItemCommand(_apiClient,_buildings);
            Update = new OpenPopUpWindowCommand(_apiClient,_windowNavigator,_buildings,Operation.Update);
            Add = new OpenPopUpWindowCommand(_apiClient,_windowNavigator,_buildings,Operation.Add);
            AddNewBuilding = new OpenPopUpWindowCommand(_apiClient,_windowNavigator,_buildings,Operation.AddBuilding);
        }
    }
}
