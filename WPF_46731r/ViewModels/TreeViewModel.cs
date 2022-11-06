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
        public List<Computer> Computers { get; private set; }
        public TreeViewModel(List<Computer> Computers)
        {
            this.Computers = Computers;
            FillList();
        }

        public async void FillList()
        {
            Families = new List<Family>();
            Family family1 = new Family() { Name = "Унибит-1" };

            var a = new FamilyMember(Computers) { Name = "101" };
            var b = new FamilyMember(Computers) { Name = "102" };
            var c = new FamilyMember(Computers) { Name = "202" };

            //a.Members.Add(new MemberOf() { Name = "U1-101-1" });
            //b.Members.Add(new MemberOf() { Name = "U1-102-1" });
            //c.Members.Add(new MemberOf() { Name = "U1-202-1" });

            family1.Members.Add(a);
            family1.Members.Add(b);
            family1.Members.Add(c);
            Families.Add(family1);

            Family family2 = new Family() { Name = "Унибит-2" };
            family2.Members.Add(b);
            family2.Members.Add(c);
            Families.Add(family2);
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
