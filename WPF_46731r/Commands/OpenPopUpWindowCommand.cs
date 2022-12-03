using WPF_46731r.State.Navigators;
using WPF_46731r.ViewModels;
using WPF_46731r.Views;

namespace WPF_46731r.Commands
{
    public class OpenPopUpWindowCommand : CommandBase
    {
        private readonly WindowNavigator _nav;
        private readonly PopUpUpdateComputerViewModel _vm;

        public OpenPopUpWindowCommand(WindowNavigator nav, PopUpUpdateComputerViewModel vm)
        {
            _nav = nav;
            _vm = vm;
        }

        public override void Execute(object? parameter)
        {
            var popUpWindowView = new PopUpUpdateComputerView()
            {
                DataContext = _vm,
                Owner = _nav.CurrentView
            };
            popUpWindowView.ShowDialog();
        }
    }
}
