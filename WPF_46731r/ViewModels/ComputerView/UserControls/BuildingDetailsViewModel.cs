using WPF_46731r.Domain.Models;

namespace WPF_46731r.ViewModels.ComputerView.UserControls
{
    public class BuildingDetailsViewModel : ViewModelBase
    {
        private Building _building;
        public Building Building  { get=>_building; set => _building = value; }
        public BuildingDetailsViewModel(Building building)
        {
            _building = building;
        }
    }
}
