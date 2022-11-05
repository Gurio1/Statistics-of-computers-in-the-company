using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_46731r.Views
{
    /// <summary>
    /// Interaction logic for ComputersView.xaml
    /// </summary>
    public partial class ComputersView : UserControl
    {
        public ComputersView()
        {
            InitializeComponent();

            List<Family> families = new List<Family>();

            Family family1 = new Family() { Name = "Унибит-1" };

            var a = new FamilyMember() { Name = "101"};
            var b = new FamilyMember() { Name = "102"};
            var c = new FamilyMember() { Name = "202"};

            a.Members.Add(new MemberOfFamilyMember() { Name = "U1-101-1"});
            b.Members.Add(new MemberOfFamilyMember() { Name = "U1-102-1"});
            c.Members.Add(new MemberOfFamilyMember() { Name = "U1-202-1"});

            family1.Members.Add(a);
            family1.Members.Add(b);
            family1.Members.Add(c);
            families.Add(family1);

            Family family2 = new Family() { Name = "Унибит-2" };
            family2.Members.Add(b);
            family2.Members.Add(c);
            families.Add(family2);

            trvFamilies.ItemsSource = families;
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

    public class FamilyMember
    {
        public string Name { get; set; }

        public ObservableCollection<MemberOfFamilyMember> Members { get; set; }

        public FamilyMember()
        {
            this.Members = new ObservableCollection<MemberOfFamilyMember>();
        }
    }

    public class MemberOfFamilyMember
    {
        public string Name { get; set; }
    }
}
