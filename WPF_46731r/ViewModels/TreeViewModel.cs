using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Computer;
using WPF_46731r.Domain.Service;
using WPF_46731r.Views;

namespace WPF_46731r.ViewModels
{
    public class TreeViewModel
    {

        public List<Family> Families { get; private set; }
        public ObservableCollection<Building> Buildings { get; private set; }
        public TreeViewModel(ObservableCollection<Building> Buildings)
        {
            this.Buildings = Buildings;
        }

        

    }
    public class Family
    {
        public Family()
        {
            this.Members = new ObservableCollection<FamilyMember>();
        }

        public string Name { get; set; }

        public ObservableCollection<FamilyMember> Members { get; set; }
    }

    //public class FamilyMember
    //{
    //    public string Name { get; set; }

    //    public ObservableCollection<Computer> Members { get; set; }

    //    public FamilyMember(List<Computer> computers)
    //    {
    //        this.Members = new ObservableCollection<Computer>(computers);
    //    }
    //}

    public class FamilyMember
    {
        public string Name { get; set; }

        public ObservableCollection<Computer> Members { get; set; }

        public FamilyMember(List<Computer> comps)
        {
            this.Members = new ObservableCollection<Computer>(comps);
        }
    }

    //public class MemberOf
    //{
    //    public string Name { get; set; }
    //}
}
