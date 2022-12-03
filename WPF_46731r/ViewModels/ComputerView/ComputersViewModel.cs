using System.Windows.Input;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Computer;
using WPF_46731r.State.Navigators;
using WPF_46731r.ViewModels.ComputerView.UserControls;

namespace WPF_46731r.ViewModels.ComputerView
{
    public class ComputersViewModel : ViewModelBase
    {
        private NavigationViewModelBar NavigationBar { get; }
        private WindowNavigator _windowNavigator;
        private Computer? _computer;
        private Building? _building;
        private Room? _room;
        private TreeViewModel _tree;
        private ViewModelBase _currentUserControlViewModel;
        public ViewModelBase CurrentUserControlViewModel
        {
            get => _currentUserControlViewModel;
            set
            {
                _currentUserControlViewModel = value;
                OnPropretyChanged(nameof(CurrentUserControlViewModel)); 
                
            }
        }
        public Building? Building
        {
            get => _building;
            set
            {
                _building = value;
                OnPropretyChanged(nameof(Building));
                CurrentUserControlViewModel = new BuildingDetailsViewModel(value);

            } 
            
        }

        public Room? Room
        {
            get => _room;
            set
            {
                _room = value;
                OnPropretyChanged(nameof(Room)); 
                CurrentUserControlViewModel = new RoomDetailsViewModel(value);

            } 
            
        }

        public Computer? Computer
        {
            get => _computer;
            set
            {
                _computer = value;
                OnPropretyChanged(nameof(Computer));
                CurrentUserControlViewModel = new ComputerDetailsViewModel(value,_windowNavigator);

            }

        }
        public TreeViewModel Tree { get => _tree; set => _tree = value; }
        public ICommand Update { get; set; }
        public ComputersViewModel(NavigationViewModelBar navigationViewModelBar,
                                  TreeViewModel tree,
                                  WindowNavigator windowNav)
        {
            NavigationBar = navigationViewModelBar;
            Tree = tree;
            _windowNavigator = windowNav;
        }
    }
}
