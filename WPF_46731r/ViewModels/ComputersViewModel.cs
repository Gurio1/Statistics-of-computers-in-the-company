using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_46731r.Domain.Models.Computer;

namespace WPF_46731r.ViewModels
{
    public class ComputersViewModel : ViewModelBase
    {
        private NavigationViewModelBar _navigationBar { get; }
        public TreeViewModel Tree { get => _tree; set => _tree = value; }
        public TreeViewModelDetails ItemTreeDetails { get => _itemTreeDetails; set => _itemTreeDetails = value; }

        private Computer _item;

        public Computer Item { get => _item; set { _item = value; OnPropretyChanged(nameof(Item)); } }

        private TreeViewModel _tree;

        private TreeViewModelDetails _itemTreeDetails;
        public ComputersViewModel(NavigationViewModelBar navigationViewModelBar,
                                  TreeViewModel tree,
                                  TreeViewModelDetails itemTreeDetails)
        {
            _navigationBar = navigationViewModelBar;
            Tree = tree;
            ItemTreeDetails = itemTreeDetails;
        }
    }
}
