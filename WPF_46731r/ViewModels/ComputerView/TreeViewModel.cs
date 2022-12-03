using System.Collections.ObjectModel;
using WPF_46731r.Domain.Models;

namespace WPF_46731r.ViewModels
{
    public class TreeViewModel
    {

        public ObservableCollection<Building> Buildings { get; private set; }
        public TreeViewModel(ObservableCollection<Building> Buildings)
        {
            this.Buildings = Buildings;
        }
    }
}
