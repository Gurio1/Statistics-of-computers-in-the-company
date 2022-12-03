using WPF_46731r.Domain.Models.Computer;

namespace WPF_46731r.ViewModels
{
    public class PopUpUpdateComputerViewModel : ViewModelBase
    {
        public Computer? Item { get =>_item; set { _item = value; OnPropretyChanged(nameof(Item)); } }
        private Computer? _item;

        public PopUpUpdateComputerViewModel(Computer computer)
        {
            _item = computer;
        }
    }
}
