using System.Windows.Input;
using WPF_46731r.Commands;
using WPF_46731r.Domain.Models.Computer;
using WPF_46731r.State.Navigators;

namespace WPF_46731r.ViewModels.ComputerView.UserControls
{
    public class ComputerDetailsViewModel: ViewModelBase
    {
        public Computer Computer { get =>_computer; set => _computer = value; }
        private Computer _computer;

        public ICommand Update { get; set; }
        public ComputerDetailsViewModel(Computer computer,WindowNavigator windowNav)
        {
            _computer = computer;
            Update = new OpenPopUpWindowCommand(windowNav, new PopUpUpdateComputerViewModel(computer));
        }
        
    }
}
